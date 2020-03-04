using System;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic.Factories
{
    public class FactoryRandom:IFactoryRandom
    {
        public Random Create(int seed) => new Random(seed);

        public int GenerateSeed() => DateTime.UtcNow.Millisecond;
    }
}