using System.Threading.Tasks;
using Sharie.Logic.Interfaces;
using Sharie.Logic.Interfaces.Executors;
using Sharie.Logic.Interfaces.Services;

namespace Sharie.Logic.Services
{
    public class ExternalSleepyService : IExternalSleepyService
    {
        public ExternalSleepyService(IAsyncExecutor asyncExecutor)
        {
            AsyncExecutor = asyncExecutor;
        }

        public async Task<bool> SleepForATime()
        {
            await AsyncExecutor.Delay(2000);
            return await AsyncExecutor.FromResult(true);
        }

        IAsyncExecutor AsyncExecutor { get; }
    }
}
