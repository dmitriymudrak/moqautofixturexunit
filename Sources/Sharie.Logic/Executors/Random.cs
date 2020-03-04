using System;
using Sharie.Logic.Interfaces;
using Sharie.Logic.Interfaces.Executors;

namespace Sharie.Logic.Executors
{
    public class RandomExecutor: IRandomExecutor
    {
        public RandomExecutor(IFactoryRandom factory)
        {
            var seed = factory.GenerateSeed();
            Random = factory.Create(seed);
        }

        public int Next(int min, int max) => Random.Next(min, max);

        Random Random { get; }
    }
}