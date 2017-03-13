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

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedCourseForm_IsInvalid()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseMock.Object });

            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            engineMock.Setup(e => e.Students).Returns(new List<IStudent> { student1Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0",
                "0",
                "invalid form"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void CorrectlyAddFoundStudent_IntoCourseInOnlineForm()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseMock.Object });

            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            engineMock.Setup(e => e.Students).Returns(new List<IStudent> { student1Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0",
                "0",
                "online"
            };

            int onlineStudentsCountBeforeAdding = seasonMock.Object.Courses[0].OnlineStudents.Count;

            // Act
            command.Execute(parameters);
            int onlineStudentsCountAfterAdding = seasonMock.Object.Courses[0].OnlineStudents.Count;

            // Assert
            Assert.Greater(onlineStudentsCountAfterAdding, onlineStudentsCountBeforeAdding);
        }

        [Test]
        public void CorrectlyAddFoundStudent_IntoCourseInOnsiteForm()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseMock.Object });

            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            engineMock.Setup(e => e.Students).Returns(new List<IStudent> { student1Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0",
                "0",
                "onsite"
            };

            int onsiteStudentsCountBeforeAdding = seasonMock.Object.Courses[0].OnsiteStudents.Count;

            // Act
            command.Execute(parameters);
            int onsiteStudentsCountAfterAdding = seasonMock.Object.Courses[0].OnsiteStudents.Count;

            // Assert
            Assert.Greater(onsiteStudentsCountAfterAdding, onsiteStudentsCountBeforeAdding);
        }

        [Test]
        public void ReturnSuccessMsg_ContainingStudentUsernameAndSeasonId()
        {
            // Arrange
            var student1Mock = new Mock<IStudent>();
            student1Mock.SetupGet(st => st.Username).Returns("bat Kolio");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseMock.Object });

            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            engineMock.Setup(e => e.Students).Returns(new List<IStudent> { student1Mock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            IList<string> parameters = new List<string>
            {
                "bat Kolio",
                "0",
                "0",
                "onsite"
            };

            // Act
            var result = command.Execute(parameters);

            // Assert
            StringAssert.Contains(parameters[0], result, "parameter[0]'s value was not found within result string!");
            StringAssert.Contains(parameters[1], result, "parameter[1]'s value was not found within result string!");
        }
    }
}
