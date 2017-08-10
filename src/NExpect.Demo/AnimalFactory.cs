using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;

namespace NExpect.Demo
{
    public interface IAnimalFactory
    {
        Animal CreateFlamingo();
        Animal[] CreateBirds();
    }

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateFlamingo()
        {
            return new Flamingo();
        }

        public Animal[] CreateBirds()
        {
            return new Animal[]
            {
                new Flamingo(),
                new Ostrich(),
                new Penguin()
            };
        }
    }
}