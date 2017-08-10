using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;

namespace NExpect.Demo
{
    public interface IAnimalFactory
    {
        Animal CreateFlamingo();
    }

    public class AnimalFactory: IAnimalFactory
    {
        public Animal CreateFlamingo()
        {
            return new Flamingo();
        }
    }
}