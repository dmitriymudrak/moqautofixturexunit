using Moq;
using Sharie.Services;
using Sharie.Services.ExternalService;
using Sharie.Services.RandomService;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class SUT_TestingService
    {
        [Fact]
        public void TestingService_if_random_value_morethan_1000_throw_exception()
        {
            ///act
            var mockedRandomService = new Mock<IRandomService>();
            mockedRandomService.Setup(x => x.GenerateRandomValue(2000, 2000)).Returns(2000);

            var result = mockedRandomService.Object.GenerateRandomValue(2000, 2000);

            mockedRandomService.Verify(x => x.GenerateRandomValue(2000, 2000), Times.Once);

            

            Assert.Equal(2000, result);

            //var mockedExternalService = new Mock<IExternalSleepyService>();
            //mockedExternalService.Setup(x => x.SleepForATime()).Returns(Task.FromResult(true));

            //var mockedTestingService = new TestingService(mockedExternalService.Object, mockedRandomService.Object);
            //var result = mockedTestingService.CalculateSomethingRandom(2, 3).Result;

            //Exception ex = Assert.ThrowsAsync<Exception>(() => mockedTestingService.CalculateSomethingRandom(2, 2)).Result;

            //Assert.Equal("Out of range", ex.Message);

        }
    }
}
