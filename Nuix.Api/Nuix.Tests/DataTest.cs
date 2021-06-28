using System;
using System.Linq;
using Nuix.Data.Repository;
using Xunit;

namespace Nuix.Tests
{
    public class DataTest
    {
        [Fact]
        public async void HasData()
        {
            var sut = new Repository();

            var result = await sut.GetUserInvestments("Mark");

            Assert.True(result.Any());
        }

        [Fact]
        public async void IsCaseInsensitive()
        {
            var sut = new Repository();

            var result = await sut.GetUserInvestments("mArK");

            Assert.True(result.Any());
        }

        [Fact]
        public async void HasNoData()
        {
            var sut = new Repository();

            var result = await sut.GetUserInvestments("jim");

            Assert.False(result.Any());
        }

        [Fact]
        public async void HasMoreThanOneInvestment()
        {
            var sut = new Repository();

            var result = await sut.GetUserInvestments("mark");

            Assert.True(result.Count() > 1);
        }
    }
}
