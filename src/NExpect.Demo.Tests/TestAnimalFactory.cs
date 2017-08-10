using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NExpect.Demo.Tests
{
    [TestFixture]
    public class TestAnimalFactory
    {
        [Test]
        public void CreateFlamingo_ShouldReturnAFlamingo()
        {
            // Arrange
            var sut = Create();

            // Pre-Assert

            // Act
            var result = sut.CreateFlamingo();

            // Assert
            Expect(result).Not.To.Be.Null();
            Expect(result as Flamingo).Not.To.Be.Null();
            Expect(result.Legs).To.Equal(2);
            Expect(result.Colors).To.Contain.Exactly(1).Equal.To(Colors.Pink);
        }


        protected static IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }
}