using System.Threading.Tasks;

namespace Sharie.Logic.Interfaces.Services
{
    public interface ITestingService
    {
        Task<TestingModel> CalculateSomethingRandom(int a, int b);
    }
}