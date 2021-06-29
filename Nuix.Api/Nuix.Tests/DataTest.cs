using System;
using System.Linq;
using Nuix.Data.Repository;
using Xunit;

namespace Nuix.Tests
{
    // Arrange! Act! Assert!

    public class DataTest
    {
        public DataTest()
        {
            _sut = new Repository();
        }

        [Fact(Skip =  "Just playing.")]
        [Trait("Category", "Ignore")]
        public async void HereBeDragoons()
        {
            Assert.True(false);
        }

        [Fact]
        [Trait("Category", "Data")]
        public async void HasData()
        {
            var result = await _sut.GetUserInvestments("Mark");

            Assert.True(result.Any());
        }

        [Fact]
        [Trait("Category", "Data")]
        public async void IsCaseInsensitive()
        {
            var result = await _sut.GetUserInvestments("mArK");

            Assert.True(result.Any());
        }

        [Fact]
        [Trait("Category", "Data")]
        public async void HasNoData()
        {
            var result = await _sut.GetUserInvestments("jim");

            Assert.False(result.Any());
        }

        [Fact]
        [Trait("Category", "Data")]
        public async void HasMoreThanOneInvestment()
        {
            var result = await _sut.GetUserInvestments("mark");

            Assert.True(result.Count() > 1);
        }

        // System under test.
        private readonly IRepository _sut;
    }
}