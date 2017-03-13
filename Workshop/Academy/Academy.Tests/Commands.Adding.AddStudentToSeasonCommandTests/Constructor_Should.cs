using Academy.Commands.Adding;
using Academy.Commands.Adding.Fakes;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFactoryProvider_IsNull()
        {
            // Arrange
            var engineStub = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEngineProvider_IsNull()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryStub.Object, null));
        }

        [Test]
        public void CorrectlyAssignPassedFactoryValue()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act
            var command = new FakeAddStudendToSeasonCommand(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreEqual(factoryStub.Object, command.Factory);
        }

        [Test]
        public void CorrectlyAssignPassedEngineValue()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act
            var command = new FakeAddStudendToSeasonCommand(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreEqual(engineStub.Object, command.Engine);
        }
    }
}
