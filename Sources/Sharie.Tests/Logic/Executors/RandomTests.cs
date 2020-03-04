using Moq;
using Sharie.Logic.Executors;
using Sharie.Logic.Factories;
using Sharie.Logic.Interfaces;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Executors
{
    public class RandomExecutorTests
    {
        [Theory]
        [MoqAutoData]
        public void ConstructorTest(int seed, Mock<IFactoryRandom> factory)
        {
            //arrange
            factory.Setup(service => service.GenerateSeed()).Returns(seed);


            //act
            var sut = new RandomExecutor(factory.Object);

            //assert
            factory.Verify(service=>service.GenerateSeed(), Times.AtLeastOnce);
            factory.Verify(service => service.Create(seed), Times.AtLeastOnce);
        }

        [Theory]
        [MoqInlineAutoData(0, 1000)]
        public void NextTest(int min, int max, FactoryRandom factory)
        {
            //arrange
            var sut = new RandomExecutor(factory);

            //act
            var expected = sut.Next(min, max);

            //assert
            Assert.InRange(expected, min, max);
        }
    }
}