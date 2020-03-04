using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Sharie.Logic.Interfaces;
using Sharie.Logic.Interfaces.Executors;
using Sharie.Logic.Interfaces.Services;
using Sharie.Logic.Services;
using Sharie.Models;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Services
{
    public class TestingServiceTests
    {
        [Theory]
        [MoqAutoData]
        public async Task CalculateSomethingRandomSleepForATimeExceptionTest(int a, int b,
            [Frozen] Mock<IRandomService> randomService, [Frozen] Mock<IExternalSleepyService> sleepy,
            [Frozen] Mock<IFactoryException> factoryException, TestingService sut)
        {
            //arrange
            sleepy.Setup(service => service.SleepForATime()).ReturnsAsync(false);
            factoryException.Setup(service => service.Create()).Throws<Exception>();

            //act
            var exception = await Assert.ThrowsAsync<Exception>(async () => await sut.CalculateSomethingRandom(a, b));

            //assert
            randomService.Verify(service => service.GenerateRandomValue(1, 1000));
            sleepy.Verify(service => service.SleepForATime(), Times.AtLeastOnce);
            factoryException.Verify(service => service.Create(), Times.AtLeastOnce);
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Exception of type 'System.Exception' was thrown.", exception.Message);
        }

        [Theory]
        [MoqInlineAutoData(1, 250, "Plus", 0)]
        [MoqInlineAutoData(250, 500, "Minus 10", -10)]
        [MoqInlineAutoData(500, 750, "Plus 10", 10)]
        [MoqInlineAutoData(750, 1000, "Plus 20", 20)]
        public async Task CalculateSomethingRandomValueTest(int min, int max, string operationType, int delta, int a, int b,
            TestingModel actual, [Frozen] Mock<IRandomService> randomService,
            [Frozen] Mock<IExternalSleepyService> sleepy, [Frozen] Mock<IFactoryTestingModel> factoryTestingModel,
            [Frozen] Mock<IAsyncExecutor> asyncExecutor, TestingService sut)
        {
            //arrange
            var rnd = new Random(DateTime.Now.Millisecond);
            var actualRandomValue = rnd.Next(min, max);

            randomService.Setup(service => service.GenerateRandomValue(1, 1000)).Returns(actualRandomValue);
            sleepy.Setup(service => service.SleepForATime()).ReturnsAsync(true);
            factoryTestingModel.Setup(service => service.Create(operationType, actualRandomValue, a + b + delta))
                .Returns(actual);
            asyncExecutor.Setup(service => service.FromResult(actual)).ReturnsAsync(actual);

            //act
            var expected = await sut.CalculateSomethingRandom(a, b);

            //assert
            randomService.Verify(service => service.GenerateRandomValue(1, 1000), Times.AtLeastOnce);
            sleepy.Verify(service => service.SleepForATime(), Times.AtLeastOnce);
            factoryTestingModel.Verify(service=>service.Empty(), Times.AtLeastOnce);
            factoryTestingModel.Verify(service => service.Create(operationType, actualRandomValue, a + b + delta),
                Times.AtLeastOnce);
            asyncExecutor.Verify(service => service.FromResult(actual));
            expected.Should().BeEquivalentTo(actual);
        }

        [Theory]
        [MoqInlineAutoData(1001, 2000)]
        public async Task CalculateSomethingExceptionOutOfRangeTest(int min, int max, int a, int b,
            [Frozen] Mock<IRandomService> randomService, [Frozen] Mock<IExternalSleepyService> sleepy,
            [Frozen] Mock<IFactoryTestingModel> factoryTestingModel, [Frozen] Mock<IFactoryException> factoryException,
            TestingService sut)
        {
            //arrange
            var rnd = new Random(DateTime.Now.Millisecond);
            var actualRandomValue = rnd.Next(min, max);

            randomService.Setup(service => service.GenerateRandomValue(1, 1000)).Returns(actualRandomValue);
            sleepy.Setup(service => service.SleepForATime()).ReturnsAsync(true);
            factoryException.Setup(service => service.Create("Out of range")).Throws(new Exception("Out of range"));

            //act
            var exception = await Assert.ThrowsAsync<Exception>(async () => await sut.CalculateSomethingRandom(a, b));

            //assert
            randomService.Verify(service => service.GenerateRandomValue(1, 1000), Times.AtLeastOnce);
            sleepy.Verify(service => service.SleepForATime(), Times.AtLeastOnce);
            factoryTestingModel.Verify(service=>service.Empty(), Times.AtLeastOnce);
            factoryException.Verify(service => service.Create("Out of range"), Times.AtLeastOnce);
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Out of range", exception.Message);
        }
    }
}