using System.Threading.Tasks;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic
{
    public class AsyncExecutor: IAsyncExecutor
    {
        public async Task<T> FromResult<T>(T model) => await Task.FromResult(model).ConfigureAwait(false);

        public async Task Delay(int milliseconds) => await Task.Delay(milliseconds).ConfigureAwait(false);
    }
}
