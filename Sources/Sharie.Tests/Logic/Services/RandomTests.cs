using AutoFixture.Xunit2;
using Moq;
using Sharie.Logic.Interfaces.Executors;
using Sharie.Logic.Services;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Services
{
    public class RandomServiceTests
    {
        [Theory]
        [MoqInlineAutoData(0,1000)]
        public void GenerateRandomValueTest(int min, int max, int actual, [Frozen] Mock<IRandomExecutor> executor, RandomService sut)
        {
            //arrange
            executor.Setup(service => service.Next(min - 500, max - 500)).Returns(actual);

            //act
            var expected = sut.GenerateRandomValue(min, max);

            //assert
            executor.Verify(service => service.Next(min - 500, max - 500), Times.AtLeastOnce);
            Assert.Equal(expected, actual);
        }
    }
}