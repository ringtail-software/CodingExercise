using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using ZachAlbertCodingExercise.Models;

namespace ZachAlbertCodingExercise.Domain
{
    public class InvestmentManager
    {
        private readonly InvestmentDal _dal;
        private readonly IExceptionLogger _log;

        public InvestmentManager(InvestmentDal dal)
        {
            _dal = dal;
        }

        public virtual async Task<List<UserInvestment>> GetUserInvestments(int userId)
        {
            try
            {
                var investments = await _dal.RetrieveUserInvestments(userId);

                return investments;
            }
            catch (Exception e)
            {
                //Log.Error(e, "Error retrieving product {ProductId}\n{Message}", id, e.Message);
                return null;
            }
        }

        public virtual async Task<List<UserInvestment>> GetUserInvestments(int userId, int investmentId)
        {
            try
            {
                var investments = await _dal.RetrieveUserInvestments(userId, investmentId);

                return investments;
            }
            catch (Exception e)
            {
                //Log.Error(e, $"Error searching Orders with criteria {criteria}.  Details: {e.Message}");
                return null;
            }
        }
    }
}