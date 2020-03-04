using System.Diagnostics;
using System.Threading.Tasks;
using Sharie.Logic;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Sharie.Tests.Logic.Executors
{
    public class AsyncExecutorTests
    {
        [Theory]
        [MoqAutoData]
        public async Task FromResultTest(int actual, AsyncExecutor sut)
        {
            //act
            var expected = await sut.FromResult(actual);

            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MoqInlineAutoData(2000, 2100)]
        public async Task DelayTest(int minMilliseconds, int maxMilliseconds, AsyncExecutor sut)
        {
            //arrange
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //act
            await sut.Delay(minMilliseconds);

            //assert
            stopWatch.Stop();
            Assert.InRange(stopWatch.ElapsedMilliseconds, minMilliseconds, maxMilliseconds);
        }
    }
}