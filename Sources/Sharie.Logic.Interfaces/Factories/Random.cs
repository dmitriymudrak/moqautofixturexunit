using System;
using System.Collections.Generic;
using System.Text;

namespace Sharie.Logic.Interfaces
{
    public interface IFactoryRandom
    {
        Random Create(int seed);
        int GenerateSeed();
    }
}
