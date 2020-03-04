using System;
using Sharie.Logic.Factories;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Factories
{
    public class FactoryExceptionTests
    {
        [Theory]
        [MoqAutoData]
        public void CreateTest(FactoryException sut)
        {
            //act 
            var expected = Assert.Throws<Exception>(sut.Create);

            //assert
            Assert.NotNull(expected);
            Assert.IsType<Exception>(expected);
            Assert.Equal("Exception of type 'System.Exception' was thrown.", expected.Message);
        }

        [Theory]
        [MoqAutoData]
        public void CreateWithMessageTest(string message, FactoryException sut)
        {
            //act 
            var expected = Assert.Throws<Exception>(() => sut.Create(message));

            //assert
            Assert.NotNull(expected);
            Assert.IsType<Exception>(expected);
            Assert.Equal(expected.Message, message);
        }
    }
}