using System.Threading.Tasks;
using Sharie.Logic.Interfaces.Services;

namespace Sharie.Logic.Services
{
    public class ExternalSleepyService : IExternalSleepyService
    {
        public async Task<bool> SleepForATime()
        {
            await Task.Delay(2000);
            return await Task.FromResult(true);
        }
    }
}
