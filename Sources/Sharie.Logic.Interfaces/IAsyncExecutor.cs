using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharie.Logic.Interfaces
{
    public interface IAsyncExecutor
    {
        Task<T> Create<T>(T model);
    }
}
