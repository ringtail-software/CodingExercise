using Moq;
using Nuix.Data.Repository;
using Nuix.Data.Repository.MoqData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Nuix.Tests
{
    // Arrange! Act! Assert!

    public class DataTest
    {
        public DataTest()
        {
            var data = new Data.Repository.MoqData.Data().ClientFactory();

            var mockedData = new Mock<IData>();

            mockedData.Setup(x => x.ClientFactory()).Returns(data);

            _sut = new Repository(mockedData.Object);
        }

        [Fact(Skip =  "Just playing.")]
        [Trait("Category", "Ignore")]
        public async void HereBeDragoons()
        {
            // Shut the compiler up.
            await Task.CompletedTask;

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