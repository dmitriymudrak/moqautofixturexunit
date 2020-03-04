using System.Threading.Tasks;

namespace Sharie.Logic.Interfaces
{
    public interface IAsyncExecutor
    {
        Task<T> FromResult<T>(T model);
        Task Delay(int milliseconds);
    }
}
