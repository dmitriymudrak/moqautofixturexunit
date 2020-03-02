using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharie.Services.ExternalService
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
