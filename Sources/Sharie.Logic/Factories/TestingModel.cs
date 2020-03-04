using Sharie.Logic.Interfaces;
using Sharie.Models;

namespace Sharie.Logic.Factories
{
    public class FactoryTestingModel:IFactoryTestingModel
    {
        public TestingModel Create(string operationType, int randomValue, int value)
        {
            return new TestingModel
            {
                OperationType = operationType,
                RandomValue = randomValue.ToString(),
                Value = value
            };
        }

        public TestingModel Empty() => new TestingModel();
    }
}
