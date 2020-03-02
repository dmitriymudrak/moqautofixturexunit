using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharie.Services.RandomService
{
    public interface IRandomService
    {
        int GenerateRandomValue(int min, int max);
    }

    public class RandomService : IRandomService
    {
        public int GenerateRandomValue(int min, int max)
        {
            throw new NotImplementedException();
        }
    }
}
