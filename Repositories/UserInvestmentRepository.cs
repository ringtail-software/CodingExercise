using System;
using System.Collections.Generic;
using System.Linq;

using KrummertNuix.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KrummertNuix.Repositories
{
    public class UserInvestmentRepository
    {
        public MyEntities _Context;

        public UserInvestmentRepository() : this(new MyEntities()) { }
        public UserInvestmentRepository(MyEntities context)
        {
            _Context = context;
        }

        public List<Portfolio> Get(Guid userId)
        {
            return _Context.Portfolios.Where(m => m.MyUserId == userId).ToList();
        }
        public Portfolio Get(Guid userId, Guid investmentId)
        {
            return _Context.Portfolios
                .Include("StocksAtPurchase")
                .Include("StocksAtPurchase.StocksAtCurrent")
                .FirstOrDefault(m => m.MyUserId == userId && m.Id == investmentId);
        }
    }    
} 