using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using NUnit.Framework;

namespace NExpect.Demo.Tests
{
    [TestFixture]
    public class TestAnimalFactory
    {
        [Test]
        public void CreateFlamingo_ShouldReturnFlamingo()
        {
            // Arrange
            var sut = Create();

            // Pre-Assert

            // Act
            var result = sut.CreateFlamingo();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Flamingo>(result);
            Assert.AreEqual(2, result.Legs);
            CollectionAssert.Contains(result.Colors, Colors.Pink);
        }

        private IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }
}
