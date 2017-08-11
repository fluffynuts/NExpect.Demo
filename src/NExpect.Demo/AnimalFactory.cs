using System.Linq;
using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using PeanutButter.RandomGenerators;

namespace NExpect.Demo
{
    public interface IAnimalFactory
    {
        Animal CreateFlamingo();
        Animal[] CreateBirds();
        Animal[] CreateBears();
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

        public Animal[] CreateBears()
        {
            return new Animal[]
            {
                new BrownBear(),
                new PolarBear()
            }.Randomize().ToArray();
        }
    }
}