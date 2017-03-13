using Academy.Tests.Models.Abstractions.UserTests.Fakes;
using NUnit.Framework;
using System;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class Username_Should
    {
        [TestCase("b")]
        [TestCase("bat Kooooooooooooooooooooooooooooooooooolio")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedValueIsInvalid(string testUsername)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new FakeUser(testUsername));
        }

        [Test]
        public void NotThrowException_WhenPassedValueIsValid()
        {
            // Arrange
            string testUsername = "bat Kolio";

            // Act & Assert
            Assert.DoesNotThrow(() => new FakeUser(testUsername));
        }

        [Test]
        public void CorrectlyAssign_PassedValue()
        {
            // Arrange
            string testUsername = "bat Kolio";

            // Act
            var user = new FakeUser(testUsername);

            // Assert
            Assert.AreEqual(testUsername, user.Username);
        }
    }
}