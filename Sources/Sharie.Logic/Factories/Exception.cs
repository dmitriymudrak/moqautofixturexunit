using System;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic.Factories
{
    public class FactoryException:IFactoryException
    {
        public void Create()
        {
            throw new Exception();
        }

        public void Create(string message)
        {
            throw new Exception(message);
        }
    }
}