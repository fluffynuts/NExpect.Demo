using System;
using System.Collections.Generic;
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

        [Test]
        public void CreateBears_ShouldReturnBearsInAnyOrder()
        {
            // Arrange
            var sut = Create();
            // Pre-Assert
            // Act
            var result = sut.CreateBears();
            // Assert
            Expect(result).To.Contain.Exactly(1).BrownBears();
            Expect(result).Not.To.Contain.Any().Birds();
        }

        [Test]
        public void CreateBirds_ShouldReturnFlamingoWithCorrectColors()
        {
            // Arrange
            var sut = Create();

            // Pre-Assert

            // Act
            var result = sut.CreateFlamingo();

            // Assert
            Expect(result).To.Have.Color(Colors.Pink);
            Expect(result).To.Have.Color(Colors.White);
            Expect(result).To.Have.Color(Colors.Black);
            Expect(result).Not.To.Have.Color(Colors.Brown);
        }

        private static IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }

    public static class MatcherExtensions
    {
        public static void Color<T>(
            this IHave<T> have,
            Colors color
        ) where T: Animal
        {
            have.Compose(animal =>
            {
                Expect(animal.Colors).To.Contain.Exactly(1).Equal.To(color);
            });
        }

        public static void BrownBears<T>(this ICountMatchContinuation<IEnumerable<T>> continuation)
        {
            continuation.AddMatcher(collection =>
            {
                var expectedCount = continuation.GetExpectedCount<T>();
                var matchMethod = continuation.GetCountMatchMethod();
                var total = collection.Count();
                var count = collection.Count(o => o is BrownBear);
                var passed = _strategies[matchMethod](total, count, expectedCount);
                var not = passed ? "not " : "";
                return new MatcherResult(
                    passed,
                    $"Expected {not}to match {_messages[matchMethod](expectedCount)} Brown Bears"
                );
            });
        }

        public static void Birds<T>(this ICountMatchContinuation<IEnumerable<T>> continuation)
        {
            continuation.AddMatcher(collection =>
            {
                var expectedCount = continuation.GetExpectedCount<T>();
                var matchMethod = continuation.GetCountMatchMethod();
                var total = collection.Count();
                var count = collection.Count(o => o is Flamingo || o is Penguin);
                var passed = _strategies[matchMethod](total, count, expectedCount);
                var not = passed ? "" : "not ";
                return new MatcherResult(
                    passed,
                    $"Expected {not}to match {_messages[matchMethod](expectedCount)} Birds"
                );
            });
        }

        private static readonly Dictionary<CountMatchMethods, Func<int, int, int, bool>> _strategies = 
            new Dictionary<CountMatchMethods, Func<int, int, int, bool>>
            {
                [CountMatchMethods.Any] = (total, count, expected) => count > 0,
                [CountMatchMethods.All] = (total, count, expected) => count == total,
                [CountMatchMethods.Exactly] = (total, count, expected) => count == expected,
                [CountMatchMethods.Maximum] = (total, count, expected) => count <= expected,
                [CountMatchMethods.Minimum] = (total, count, expected) => count >= expected
            };

        private static Dictionary<CountMatchMethods, Func<int, string>> _messages = 
            new Dictionary<CountMatchMethods, Func<int, string>>
            {
                [CountMatchMethods.Any] = (expected) => "any",
                [CountMatchMethods.All] = (expected) => "all",
                [CountMatchMethods.Exactly] = expected => $"exactly {expected}",
                [CountMatchMethods.Maximum] = expected => $"at most {expected}",
                [CountMatchMethods.Minimum] = expected => $"at least {expected}"
            };

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