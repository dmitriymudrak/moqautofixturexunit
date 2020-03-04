using System.Threading.Tasks;
using Sharie.Logic.Interfaces;
using Sharie.Logic.Interfaces.Services;
using Sharie.Models;

namespace Sharie.Logic.Services
{
    public class TestingService : ITestingService
    {
        public TestingService(IExternalSleepyService sleepy, IRandomService randomService, IFactoryTestingModel factoryTestingModel, IFactoryException factoryException, IAsyncExecutor asyncExecutor)
        {
            Sleepy = sleepy;
            RandomService = randomService;
            FactoryTestingModel = factoryTestingModel;
            FactoryException = factoryException;
            AsyncExecutor = asyncExecutor;
        }

        public async Task<TestingModel> CalculateSomethingRandom(int a, int b)
        {
            var value = RandomService.GenerateRandomValue(1, 1000);

            var sleep = await Sleepy.SleepForATime();
            if (!sleep) FactoryException.Create();

            var result = FactoryTestingModel.Empty();
            if (value < 250 && value > 0) result = FactoryTestingModel.Create("Plus", value, a + b);
            if (value <= 500 && value > 250) result = FactoryTestingModel.Create("Minus 10", value, a + b - 10);
            if (value < 750 && value >= 500) result = FactoryTestingModel.Create("Plus 10", value, a + b + 10);
            if (value <= 1000 && value >= 750) result = FactoryTestingModel.Create("Plus 20", value, a + b + 20);
            else FactoryException.Create("Out of range");
            return await AsyncExecutor.FromResult(result);
        }

        IExternalSleepyService Sleepy { get; }
        IRandomService RandomService { get; }
        IFactoryTestingModel FactoryTestingModel { get; }
        IFactoryException FactoryException { get; }
        IAsyncExecutor AsyncExecutor { get; }
    }
}