using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using Sharie.Logic.Interfaces.Executors;
using Sharie.Logic.Services;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Services
{
    public class ExternalSleepyServiceTests
    {
        [Theory]
        [MoqAutoData]
        public async Task SleepForATimeTest([Frozen]Mock<IAsyncExecutor> executor, ExternalSleepyService sut)
        {
            //arrange
            executor.Setup(service => service.FromResult(true)).ReturnsAsync(true);

            //act
            var expected = await sut.SleepForATime();

            //assert
            executor.Verify(service=>service.Delay(2000), Times.AtLeastOnce);
            executor.Verify(service => service.FromResult(true), Times.AtLeastOnce);
            Assert.True(expected);
        }
    }
}