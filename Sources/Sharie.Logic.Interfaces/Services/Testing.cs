using System.Threading.Tasks;
using Sharie.Models;

namespace Sharie.Logic.Interfaces.Services
{
    public interface ITestingService
    {
        Task<TestingModel> CalculateSomethingRandom(int a, int b);
    }
}