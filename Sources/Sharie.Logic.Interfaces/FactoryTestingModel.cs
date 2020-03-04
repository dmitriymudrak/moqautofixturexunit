using Sharie.Models;

namespace Sharie.Logic.Interfaces
{
    public interface IFactoryTestingModel
    {
        TestingModel Create(string operationType, int randomValue, int value);
        TestingModel Empty();
    }
}
