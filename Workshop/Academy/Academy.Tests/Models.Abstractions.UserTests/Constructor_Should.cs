using Academy.Tests.Models.Abstractions.UserTests.Fakes;
using NUnit.Framework;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssign_PassedValues()
        {
            // Arrange
            string username = "bat Gosho";

            // Act
            var user = new FakeUser(username);

            // Assert
            Assert.AreEqual(username, user.Username);
        }
    }
}