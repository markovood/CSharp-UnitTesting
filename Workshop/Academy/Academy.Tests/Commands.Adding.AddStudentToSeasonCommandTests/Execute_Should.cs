using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
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
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedStudent_IsAlreadyInTheSeason()
        {
            // Arrange
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("bat Gosho");
            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(s => s.Students).Returns(new List<IStudent> { studentMock.Object });

            var factoryStub = new Mock<IAcademyFactory>();

            var engineMock = new Mock<IEngine>();
            engineMock.Setup(s => s.Students).Returns(new List<IStudent> { studentMock.Object });
            engineMock.Setup(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object});

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Gosho",
                "0"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void CorrectlyAdd_FoundStudentIntoTheSeason()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Gosho");
            var student2Mock = new Mock<IStudent>();
            student2Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(s => s.Students).Returns(new List<IStudent> { student1Mock.Object });
            
            var factoryStub = new Mock<IAcademyFactory>();

            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { student2Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });
            
            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0"
            };

            int listCountBeforeAdding = seasonMock.Object.Students.Count;

            // Act
            command.Execute(parameters);
            int listCountAfterAdding = seasonMock.Object.Students.Count;

            // Assert
            Assert.Greater(listCountAfterAdding, listCountBeforeAdding);
        }

        [Test]
        public void ReturnSuccessMsg_ContainingStudentUsernameAndSeasonId()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Gosho");
            var student2Mock = new Mock<IStudent>();
            student2Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(s => s.Students).Returns(new List<IStudent> { student1Mock.Object });

            var factoryStub = new Mock<IAcademyFactory>();

            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { student2Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0"
            };

            // Act
            string result = command.Execute(parameters);

            // Assert
            StringAssert.Contains(parameters[0], result, "parameters[0]'s value is not found within result string!");
            StringAssert.Contains(parameters[1], result, "parameters[1]'s value is not found within result string!");
        }
    }
}
