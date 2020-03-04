using System;
using Sharie.Logic.Factories;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Factories
{
    public class FactoryRandomTests
    {
        [Theory]
        [MoqAutoData]
        public void CreateTest(int seed, FactoryRandom sut)
        {
            //act
            var expected = sut.Create(seed);

            //assert
            Assert.NotNull(expected);
            Assert.IsType<Random>(expected);
        }

        [Theory]
        [MoqInlineAutoData(0, 1000)]
        public void GetSeedTest(int min, int max, FactoryRandom sut)
        {
            //act
            var expected = sut.GenerateSeed();

            //assert
            Assert.InRange(expected, min, max);
        }
    }
}
