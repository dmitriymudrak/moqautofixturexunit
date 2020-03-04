using System;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic
{
    public class RandomExecutor: IRandomExecutor
    {
        public RandomExecutor()
        {
            var seed = Factory.GenerateSeed();
            Random = Factory.Create(seed);
        }

        public int Next(int min, int max) => Random.Next(min, max);

        Random Random { get; }

        IFactoryRandom Factory { get; }
    }
}