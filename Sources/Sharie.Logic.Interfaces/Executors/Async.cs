using System.Threading.Tasks;

namespace Sharie.Logic.Interfaces.Executors
{
    public interface IAsyncExecutor
    {
        Task<T> FromResult<T>(T model);
        Task Delay(int milliseconds);
    }
}
