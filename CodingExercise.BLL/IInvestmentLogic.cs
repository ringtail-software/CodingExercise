using CodingExercise.Models;

namespace CodingExercise.BLL
{
    public interface IInvestmentLogic
    {
        Result<LinkCollectionWrapper<Investment>> GetInvestmentsForUser(int userId);
        Result<InvestmentDetail> GetInvestmentDetail(int userId, int investmentId);
    }
}
