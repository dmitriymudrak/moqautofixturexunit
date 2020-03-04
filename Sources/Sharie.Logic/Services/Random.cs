using System;
using Sharie.Logic.Interfaces;
using Sharie.Logic.Interfaces.Executors;
using Sharie.Logic.Interfaces.Services;

namespace Sharie.Logic.Services
{
    public class RandomService : IRandomService
    {
        public RandomService(IRandomExecutor random)
        {
            Random = random;
        }

        public int GenerateRandomValue(int min, int max)
        {
            return Random.Next(min-500, max-500);
        }

        IRandomExecutor Random { get; }
    }
}
