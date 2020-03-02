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
            var mockedExternalService = new Mock<IExternalSleepyService>();
            mockedExternalService.Setup(x => x.SleepForATime()).Returns(Task.FromResult(true));

            var mockedTestingService = new Mock<ITestingService>(mockedRandomService, mockedExternalService);
            mockedTestingService.Setup(x => x.CalculateSomethingRandom(1, 1)).Throws(new Exception());

            //var result = 
            ////arrange



        }
    }
}
