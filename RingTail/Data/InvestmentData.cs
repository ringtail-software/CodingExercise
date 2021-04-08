using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;

namespace RingTail.Data {
    public static class InvestmentData {
        internal static IEnumerable<object> GetUserStocks(int userId) {
            using var conn = new NpgsqlConnection(Common.GetDatabaseConnectionString());
            const string sql = "SELECT * FROM nuix_get_investments_by_user(@userId)";
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@userId", userId);
            var da = new NpgsqlDataAdapter(cmd);

            conn.Open();
            using var table = new DataTable();
            da.Fill(table);
            return table.AsEnumerable().Select(row => new {
                Id = row["investment_id"].ToString(),
                Name = row["stock_name"].ToString(),
                NameReadable = row["stock_name_readable"].ToString()
            });
        }

        internal static IInvestment GetUserStocks(int userId, int investmentId) {
            using var conn = new NpgsqlConnection(Common.GetDatabaseConnectionString());
            const string sql = "SELECT * FROM nuix_get_investment_details(@userId, @investmentId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@investmentId", investmentId);

            var da = new NpgsqlDataAdapter(cmd);
            conn.Open();
            using var table = new DataTable();
            da.Fill(table);
            foreach (DataRow row in table.Rows) {
                if (row == null) continue;
                return new Stock {
                    Id = row["investment_id"].ToString(),
                    Name = row["investment_name"].ToString(),
                    NameReadable = row["investment_name_readable"].ToString(),
                    CostBasis = decimal.TryParse(row["investment_unit_amount"].ToString(),
                        out var costBasis)
                        ? costBasis
                        : 0.00m,
                    Price = decimal.TryParse(row["price"].ToString(), out var price) ? price : 0.00m,
                    Shares = int.TryParse(row["investment_quantity"].ToString(), out var shares)
                        ? shares
                        : 0,
                    AcquiredDate = DateTime.TryParse(row["investment_date"].ToString(),
                        out var acquiredDate)
                        ? acquiredDate
                        : DateTime.Now
                };
            }

            return null;
        }
    }
}