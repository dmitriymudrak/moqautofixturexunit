using System.Threading.Tasks;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic
{
    public class AsyncExecutor: IAsyncExecutor
    {
        public async Task<T> Create<T>(T model) => await Task<T>.Factory.StartNew(() => model).ConfigureAwait(false);
    }
}
