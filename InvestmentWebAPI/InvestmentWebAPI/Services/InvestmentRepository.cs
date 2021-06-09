using Investment.API.DbContexts;
using Investment.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Investment.API.Services
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly InvestmentContext _context;
        private readonly ILogger<InvestmentRepository> _logger;

        public InvestmentRepository(InvestmentContext context, ILogger<InvestmentRepository> logger )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new AggregateException(nameof(logger));
        }

        #region Securities

        public IEnumerable<Security> GetSecurities()
        {
            _logger.LogInformation($"Getting all securities from database.");

            return _context.Securities;
        }

        #endregion Securities

        #region Users

        public IEnumerable<User> GetUsers()
        {
            _logger.LogInformation($"Getting all users from database.");

            return _context.Users;
        }

        public User GetUser(Guid userName)
        {
            _logger.LogInformation($"Getting user with userName {userName} from database.");
            
            IQueryable<User> query = _context.Users
                                                .Include(u => u.Investments)
                                                .Where(u => u.UserName == userName);

            return query.FirstOrDefault();
        }

        #endregion Users

        #region Investments

        public IEnumerable<Entities.Investment> GetInvestments()
        {
            _logger.LogInformation($"Getting all investments from database.");

            IQueryable<Entities.Investment> query = _context.Investments
                                                .Include(i => i.Security);

            return query.ToList();
        }

        public Entities.Investment GetInvestment(long investmentId)
        {
            _logger.LogInformation($"Getting investment with id {investmentId} from database.");

            IQueryable<Entities.Investment> query = _context.Investments
                                                .Include(i => i.Security)
                                                .Where(i => i.Id == investmentId);

            return query.FirstOrDefault();
        }

        #endregion Investments
    }
}
