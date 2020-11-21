using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using InvPerfWebApi.Models;
using System.Threading.Tasks;

namespace InvPerfWebApi
{
    //The data model is flat for simplicity. I am also generating the data randomly. The data generator needs some work to 
    //be able to generate multiple rows for the same user or investment. Currently it creates 10 unique users and 10 unique investments
    //I also made async methods. Ideally the methods should be async all the way to the data layer including
    public class InvestmentDataProvider
    {
        List<InvestmentData> investmentData = new List<InvestmentData>();
        
        public InvestmentDataProvider()
                    {

            for (int i = 0; i < 10; i ++ )
            {
                InvestmentData temp = new InvestmentData();
                temp.userName = "User" + i;
                temp.invId = i;
                temp.invName = "Investment" + i;
                Random random = new Random();
                temp.numShares = random.Next(1,10);
                temp.costBasisPerShare = random.Next(10, 100);
                temp.currentPrice = random.Next(10, 100);
                temp.currentValue = temp.numShares * temp.currentPrice;
                int term = random.Next(0, 1);
                if (term == 0)
                    temp.term = "short";
                else temp.term = "long";
                temp.totalGainLoss = temp.currentValue - (temp.numShares * temp.costBasisPerShare);

                investmentData.Add(temp);
            }
         
        }

        public List<UserInvestment> getUserInvestments(string userName)
        {
            var userInvestments = new List<UserInvestment>();
            try {
                userInvestments = investmentData
                    .Select(u => new UserInvestment { userName = u.userName, invId = u.invId, invName = u.invName })
                    .Where(u => u.userName == userName).ToList();
            }
            catch (Exception ex)
            {
                //log the exception
            }
            return userInvestments;
        }

        public async Task<List<UserInvestment>> GetAsync(string userName)
        {
            return getUserInvestments(userName);
        }

        public List<UserInvestmentDetail> getUserInvestmentDetail(string userName, string investmentName)
        {
            var userInvestmentDetail = new List<UserInvestmentDetail>();
            try
            {
                userInvestmentDetail = investmentData
                    .Select(i => new UserInvestmentDetail
                    {
                        userName = i.userName,
                        invName = i.invName,
                        numShares = i.numShares,
                        costBasisPerShare = i.costBasisPerShare,
                        currentPrice = i.currentPrice,
                        currentValue = i.currentValue,
                        term = i.term,
                        totalGainLoss = i.totalGainLoss
                    })
                    .Where(i => i.userName == userName && i.invName == investmentName).ToList();
            }
            catch (Exception ex)
            { 
                //log the exception
            }
            return userInvestmentDetail;
        }

        public async Task<List<UserInvestmentDetail>> GetAsync(string userName, string investmentName)
        {
            return getUserInvestmentDetail(userName, investmentName);
        }

    }
}