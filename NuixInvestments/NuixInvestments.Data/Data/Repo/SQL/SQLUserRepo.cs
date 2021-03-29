using Dapper;
using Microsoft.Extensions.Configuration;
using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NuixInvestments.MiddleWare.Data.Repo.SQL
{
    public class SQLUserRepo : IUserRepo
    {
        protected readonly string ConnectionString;

        public SQLUserRepo(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionStrings:Default"];
        }

        public UserInvestment GetSingleInvestmentByUser(int userId, int investmentId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var userInvestment = connection.QueryFirstOrDefault<UserInvestment>(
                    @"EXEC dbo.UserInvestment_GetSingleInvestmentByUser @UserId = @UserId, @InvestmentId = @InvestmentId",
                    new { UserId = userId, InvestmentId = investmentId });

                if (userInvestment != null)
                {
                    var user = connection.QueryFirstOrDefault<User>(
                    @"EXEC dbo.User_GetById @Id = @Id", new { Id = userId });

                    var investment = connection.QueryFirstOrDefault<Investment>(
                        @"EXEC dbo.Investment_GetById @Id = @Id", new { Id = investmentId });

                    userInvestment.User = user;

                    userInvestment.Investment = investment;
                }

                return userInvestment;
            }
        }

        public IEnumerable<UserInvestment> GetAllInvestmentsByUser(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var userInvestments = connection.Query<UserInvestment>(
                    @"EXEC dbo.UserInvestment_GetAllInvestmentsByUser @UserId = @UserId",
                    new { UserId = userId });

                if (userInvestments != null && userInvestments.Count() > 0)
                {
                    var user = connection.QueryFirstOrDefault<User>(
                        @"EXEC dbo.User_GetById @Id = @Id", new { Id = userId });

                    var investments = connection.Query<Investment>(
                        @"EXEC dbo.Investment_GetAll");

                    foreach (var userInvestment in userInvestments)
                    {
                        userInvestment.User = user;
                        var investment = investments.Where(i => i.Id == userInvestment.InvestmentId).FirstOrDefault();
                        userInvestment.Investment = investment;
                    }
                }

                return userInvestments;
            }
        }
    }
}
