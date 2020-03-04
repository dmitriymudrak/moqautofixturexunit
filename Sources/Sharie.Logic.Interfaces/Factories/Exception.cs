using System;

namespace Sharie.Logic.Interfaces
{
    public interface IFactoryException
    {
        void Create();
        void Create(string message);
    }
}
