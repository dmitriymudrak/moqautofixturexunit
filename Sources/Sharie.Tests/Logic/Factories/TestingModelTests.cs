using Sharie.Logic.Factories;
using Sharie.Models;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Factories
{
    public class FactoryTestingModelTests
    {
        [Theory]
        [MoqAutoData]
        public void EmptyTest(FactoryTestingModel sut)
        {
            //act
            var expected = sut.Empty();

            //assert
            Assert.NotNull(expected);
            Assert.IsType<TestingModel>(expected);
            Assert.Null(expected.OperationType);
            Assert.Null(expected.RandomValue);
            Assert.Equal(0, expected.Value);
        }

        [Theory]
        [MoqAutoData]
        public void CreateTest(string operationType, int randomValue, int value, FactoryTestingModel sut)
        {
            //act
            var expected = sut.Create(operationType, randomValue, value);

            //assert
            Assert.NotNull(expected);
            Assert.IsType<TestingModel>(expected);
            Assert.Equal(expected.OperationType, operationType);
            Assert.Equal(expected.RandomValue, randomValue.ToString());
            Assert.Equal(expected.Value, value);
        }
    }
}