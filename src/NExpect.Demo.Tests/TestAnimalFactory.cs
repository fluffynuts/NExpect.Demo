using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using NExpect.Interfaces;
using NExpect.MatcherLogic;
using NUnit.Framework;
using System.Linq;
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
            Expect(result).To.Be.A.Flamingo();
        }

        private static IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }

    public static class MatcherExtensions
    {
        public static void Flamingo<T>(this IA<T> an)
        {
            an.AddMatcher(item =>
            {
                var asFlamingo = item as Flamingo;
                var passed = asFlamingo != null &&
                             asFlamingo.Legs == 2 &&
                             asFlamingo.Colors.Contains(Colors.Pink);
                var not = passed ? "" : "not ";
                return new MatcherResult(
                    passed,
                    $"Expected {item} {not}to be a flamingo"
                );
            });
        }
    }
}