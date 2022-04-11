using PZCheeseria.Repository;
using Xunit;

namespace PZCheeseria.Tests.RepositoryTests
{
    public class CheeseRepositoryTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GetCheese_ShouldReturnOneCheese(int cheeseId)
        {
            //Arrange
            var sut = new CheeseRepository();

            //Act
            var result = sut.Get(cheeseId);

            //Assert

            Assert.Equal(cheeseId, result.Id);
        }
    }
}
