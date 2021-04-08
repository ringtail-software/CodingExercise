using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace RingTail {
    public static class Common {
        internal static IConfiguration Configuration { get; set; } // init during startup
        public static IServiceProvider ServiceProvider { get; set; } // init during startup
        internal static ILogger DbLoggerProvider { get; set; }


        public static string GetDatabaseConnectionString() {
            return GetConnectionString("DefaultConnection");
        }

        private static string GetConnectionString(string connectionName) {
            if (string.IsNullOrWhiteSpace(connectionName))
                return string.Empty;
            var configVal = Configuration[$"ConnectionStrings:{connectionName}"];

            var connStr = Nuix.General.DecryptB64(configVal);

            if (!int.TryParse(Configuration["ConnectionStringDefaults:minPoolSize"], out var minPoolSize))
                minPoolSize = 5;
            if (!int.TryParse(Configuration["ConnectionStringDefaults:maxPoolSize"], out var maxPoolSize))
                maxPoolSize = 100;

            var connBldr = new NpgsqlConnectionStringBuilder(connStr) {
                Pooling = true, MinPoolSize = minPoolSize, MaxPoolSize = maxPoolSize
            };
            return connBldr.ToString();
        }

        internal static bool IsValidApi(string apiKey) {
            using var conn = new NpgsqlConnection(GetDatabaseConnectionString());
            const string sql = "SELECT * FROM nuix_is_valid_api_key(@api_key)";
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@api_key", apiKey);
            conn.Open();
            return int.TryParse(cmd.ExecuteScalar()?.ToString(), out var result) && result == 1;
        }
    }
}