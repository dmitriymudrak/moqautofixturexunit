using System;
using Sharie.Logic.Interfaces;

namespace Sharie.Logic
{
    public class RandomExecutor: IRandomExecutor
    {
        public RandomExecutor() => Random = new Random(DateTime.Now.Millisecond);

        public int Next(int min, int max) => Random.Next(min, max);

        private Random Random { get; }
    }
}