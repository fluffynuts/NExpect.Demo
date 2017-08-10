using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using NExpect.Interfaces;
using NExpect.MatcherLogic;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
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

        [Test]
        public void CreateBirds_ShouldReturnAFlamingoAndOstrichAndPenguin_InOrder()
        {
            // Arrange
            var sut = Create();

            // Pre-Assert

            // Act
            var result = sut.CreateBirds();

            // Assert
            Expect(result.Length).To.Equal(3);
            Expect(result[0]).To.Be.A.Flamingo();
            Expect(result[1]).To.Be.An.Ostrich();
            Expect(result[2]).To.Be.A.Penguin();
        }

        private static IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }

    public static class MatcherExtensions
    {
        public static void Flamingo<T>(this IA<T> a)
        {
            a.AddMatcher(item =>
            {
                var asFlamingo = item as Flamingo;
                var passed = asFlamingo != null &&
                             asFlamingo.Legs == 2 &&
                             asFlamingo.Habitat == Habitats.Wetlands &&
                             asFlamingo.Colors.Contains(Colors.Pink);
                var not = passed
                    ? ""
                    : "not ";
                return new MatcherResult(
                    passed,
                    $"Expected {item} {not}to be a flamingo"
                );
            });
        }

        public static void Penguin<T>(this IA<T> a)
        {
            a.AddMatcher(item =>
            {
                var asPenguin = item as Penguin;
                var passed = asPenguin != null &&
                             asPenguin.Legs == 2 &&
                             asPenguin.Habitat == Habitats.Polar &&
                             asPenguin.Colors.Contains(Colors.Black) &&
                             asPenguin.Colors.Contains(Colors.White) &&
                             !asPenguin.Colors.Contains(Colors.Pink);
                var not = passed
                    ? ""
                    : "not ";
                return new MatcherResult(
                    passed,
                    $"Expected {item} {not}to be a penguin"
                );
            });
        }

        public static void Ostrich<T>(this IAn<T> an)
        {
            an.AddMatcher(item =>
            {
                var asOstrich = item as Ostrich;
                var passed = asOstrich != null &&
                             asOstrich.Legs == 2 &&
                             asOstrich.Habitat == Habitats.Savanna &&
                             asOstrich.Colors.Contains(Colors.Black) &&
                             asOstrich.Colors.Contains(Colors.White) &&
                             !asOstrich.Colors.Contains(Colors.Pink);
                var not = passed
                    ? ""
                    : "not ";
                return new MatcherResult(
                    passed,
                    $"Expected {item} {not}to be an ostrich"
                );
            });
        }
    }
}