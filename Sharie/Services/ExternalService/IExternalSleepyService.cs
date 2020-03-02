using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharie.Services.ExternalService
{
    public interface IExternalSleepyService
    {
        Task<bool> SleepForATime();
    }
}
