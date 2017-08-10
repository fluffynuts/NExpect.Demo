using NExpect.Demo.Animals;
using NExpect.Demo.Animals.Implementations;
using NUnit.Framework;
using static NUnit.StaticExpect.Expectations;

namespace NExpect.Demo.Tests
{
    [TestFixture]
    public class TestAnimalFactory_TestingEvolution
    {
        [TestFixture]
        public class YerTestsAreOlde
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
        }

        [TestFixture]
        public class UsingAssertThatIsBetterThanYeOldeMethods
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
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<Flamingo>());
                Assert.That(result.Legs, Is.EqualTo(2));
                Assert.That(result.Colors, Does.Contain(Colors.Pink));
            }
        }

        [TestFixture]
        public class AssertionHelperIsDeadAndForcingInheritenceForTestFixturesSucksAnyway : AssertionHelper
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
                Expect(result, Is.Not.Null);
                Expect(result, Is.InstanceOf<Flamingo>());
                Expect(result.Legs, Is.EqualTo(2));
                Expect(result.Colors, Does.Contain(Colors.Pink));
            }
        }

        [TestFixture]
        public class UsingNunitStaticExpect
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
                Expect(result, Is.Not.Null);
                Expect(result, Is.InstanceOf<Flamingo>());
                Expect(result.Legs, Is.EqualTo(2));
                Expect(result.Colors, Does.Contain(Colors.Pink));
            }

            protected static IAnimalFactory Create()
            {
                return new AnimalFactory();
            }
        }

        protected static IAnimalFactory Create()
        {
            return new AnimalFactory();
        }
    }
}