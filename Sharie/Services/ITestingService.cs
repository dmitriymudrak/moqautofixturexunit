using Sharie.Services.ExternalService;
using Sharie.Services.RandomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharie.Services
{
    public interface ITestingService
    {
        public TestingModel CalculateSomethingRandom(int a, int b);
    }

    public class TestingService : ITestingService
    {
        private IExternalSleepyService Sleepy { get; }
        private IRandomService RandomService { get; }
        public TestingService(IExternalSleepyService sleepy, IRandomService randomService)
        {
            Sleepy = sleepy;
            RandomService = randomService;
        }

        public TestingModel CalculateSomethingRandom(int a, int b)
        {
            var value = RandomService.GenerateRandomValue(1, 1000);

            if (value<250 && value > 0)
            {
                return new TestingModel()
                {
                    OperationType = "Plus",
                    RandomValue = value.ToString(),
                    Value = a + b
                };    
            }

            if (value <= 500  && value > 250)
            {
                return new TestingModel()
                {
                    OperationType = "Minus 10",
                    RandomValue = value.ToString(),
                    Value = a + b - 10
                };
            }

            if (value < 750 && value >= 500)
            {
                return new TestingModel()
                {
                    OperationType = "Plus 10",
                    RandomValue = value.ToString(),
                    Value = a + b + 10
                };
            }

            if (value <= 1000 && value >= 750)
            {
                return new TestingModel()
                {
                    OperationType = "Plus 20",
                    RandomValue = value.ToString(),
                    Value = a + b + 20
                };
            }

            throw new Exception();
        }
    }
}
