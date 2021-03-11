using CodingExercise.DAL;
using CodingExercise.DAL.Models;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using CodingExercise.BLL;
using CodingExercise.Models;

namespace CodingExercise.Tests
{
    public class Tests
    {
        private IRepository _repo;
        private IEnumerable<InvestmentModel> _expectedResult1;
        private InvestmentModel _expectedResult2;
        private IInvestmentLogic _logic;
        private Result<LinkCollectionWrapper<Investment>> _expectedResult3;
        private Result<InvestmentDetail> _expectedResult4;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository> mrepo = new Mock<IRepository>();
            mrepo.Setup(x => x.GetUserInvestments(1)).Returns(new List<InvestmentModel>
            {
                new InvestmentModel
                {
                    Id = 1001,
                    Name = "Investment A",
                    PriceAtPurchase = 1.23m,
                    NumShares = 500,
                    CurrentPrice = 4.56m,
                    PurchaseDate = new System.DateTime(2020,5,1)
                },
                new InvestmentModel
                {
                    Id = 1002,
                    Name = "Investment B",
                    PriceAtPurchase = 7.89m,
                    NumShares = 725,
                    CurrentPrice = 9.01m,
                    PurchaseDate = new System.DateTime(2019,3,10)
                }
            });
            mrepo.Setup(x => x.GetUserInvestmentDetail(1, 1001)).Returns(new InvestmentModel
            {
                Id = 1001,
                Name = "Investment A",
                PriceAtPurchase = 1.23m,
                NumShares = 500,
                CurrentPrice = 4.56m,
                PurchaseDate = new System.DateTime(2020, 5, 1)
            });
            _repo = mrepo.Object;
            Mock<IInvestmentLogic> logic = new Mock<IInvestmentLogic>();
            logic.Setup(x => x.GetInvestmentsForUser(1)).Returns(new Result<LinkCollectionWrapper<Investment>>() 
            {
                Data = new LinkCollectionWrapper<Investment> 
                {
                    Links = new List<Link>() 
                    {
                        new Link("http://localhost:5000/api/Investment/1", "Self", "GET")
                    },
                    Values = new List<Investment>
                    {
                        new Investment
                        {
                            Id = 1001,
                            Name = "Investment A",
                            Links = new List<Link>()
                            {
                                new Link("http://localhost:5000/api/Investment/1/Details/1001","Details", "GET")
                            }
                        },
                        new Investment
                        {
                            Id = 1002,
                            Name = "Investment B",
                            Links = new List<Link>()
                            { 
                                new Link("http://localhost:5000/api/Investment/1/Details/1002","Details","GET")
                            }
                        }
                    }
                },
                Success = true,
                ErrorMessage = ""
            });
            logic.Setup(x => x.GetInvestmentDetail(1, 1001)).Returns(new Result<InvestmentDetail>
            {
                Data = new InvestmentDetail
                {
                    Id = 1001,
                    Name = "Investment A",
                    NumShares = 500,
                    CostBasisPerShare = "$1.23",
                    CurrentValue = "2280.00",
                    CurrentPrice = "$4.56",
                    Term = "Short",
                    TotalGainLoss = "+$1665.00",
                    Links = new List<Link>()
                    {
                        new Link("http://localhost:5000/api/Investment/1/Details/1001","Self","GET")
                    }
                },
                ErrorMessage = "",
                Success = true
            });
            _logic = logic.Object;
            #region ExpectedResults
            _expectedResult1 = new List<InvestmentModel>()
            {
                new InvestmentModel
                {
                    Id = 1001,
                    Name = "Investment A",
                    PriceAtPurchase = 1.23m,
                    NumShares = 500,
                    CurrentPrice = 4.56m,
                    PurchaseDate = new System.DateTime(2020,5,1)
                },
                new InvestmentModel
                {
                    Id = 1002,
                    Name = "Investment B",
                    PriceAtPurchase = 7.89m,
                    NumShares = 725,
                    CurrentPrice = 9.01m,
                    PurchaseDate = new System.DateTime(2019,3,10)
                }
            };
            _expectedResult2 = new InvestmentModel
            {
                Id = 1001,
                Name = "Investment A",
                PriceAtPurchase = 1.23m,
                NumShares = 500,
                CurrentPrice = 4.56m,
                PurchaseDate = new System.DateTime(2020, 5, 1)
            };
            _expectedResult3 = new Result<LinkCollectionWrapper<Investment>>()
            {
                Data = new LinkCollectionWrapper<Investment>
                {
                    Links = new List<Link>()
                    {
                        new Link("http://localhost:5000/api/Investment/1", "Self", "GET")
                    },
                    Values = new List<Investment>
                    {
                        new Investment
                        {
                            Id = 1001,
                            Name = "Investment A",
                            Links = new List<Link>()
                            {
                                new Link("http://localhost:5000/api/Investment/1/Details/1001","Details", "GET")
                            }
                        },
                        new Investment
                        {
                            Id = 1002,
                            Name = "Investment B",
                            Links = new List<Link>()
                            {
                                new Link("http://localhost:5000/api/Investment/1/Details/1002","Details","GET")
                            }
                        }
                    }
                },
                Success = true,
                ErrorMessage = ""
            };
            _expectedResult4 = new Result<InvestmentDetail>
            {
                Data = new InvestmentDetail
                {
                    Id = 1001,
                    Name = "Investment A",
                    NumShares = 500,
                    CostBasisPerShare = "$1.23",
                    CurrentValue = "2280.00",
                    CurrentPrice = "$4.56",
                    Term = "Short",
                    TotalGainLoss = "+$1665.00",
                    Links = new List<Link>()
                    {
                        new Link("http://localhost:5000/api/Investment/1/Details/1001","Self","GET")
                    }
                },
                ErrorMessage = "",
                Success = true
            };
            #endregion ExpectedResults
        }

        [Test]
        public void TestUserInvestments1()
        {
            var data = _repo.GetUserInvestments(1);
            Assert.AreEqual(_expectedResult1, data);
        }

        [Test]
        public void TestUserInvestmentDetail1()
        {
            var data = _repo.GetUserInvestmentDetail(1, 1001);
            Assert.AreEqual(_expectedResult2, data);
        }

        [Test]
        public void TestInvestmentsForUserLogic()
        {
            var data = _logic.GetInvestmentsForUser(1);
            Assert.AreEqual(_expectedResult3, data);
        }

        [Test]
        public  void TestUserInvestmentDetailLogic1()
        {
            var data = _logic.GetInvestmentDetail(1, 1001);
            Assert.AreEqual(_expectedResult4, data);
        }
    }
}