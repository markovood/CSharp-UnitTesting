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

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedFactoryIsNull()
        {
            // Arrange
            var engineStub = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedEngineIsNull()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryStub.Object, null));
        }

        [Test]
        public void CorrectlyAssign_PassedValues()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act
            var command = new FakeAddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreEqual(factoryStub.Object, command.Factory, "Factory was not assigned correctly!");
            Assert.AreEqual(engineStub.Object, command.Engine, "Engine was not assigned correctly!");
        }
    }
}
