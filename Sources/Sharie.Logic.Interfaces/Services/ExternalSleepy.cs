using System.Threading.Tasks;

namespace Sharie.Logic.Interfaces.Services
{
    public interface IExternalSleepyService
    {
        Task<bool> SleepForATime();
    }
}