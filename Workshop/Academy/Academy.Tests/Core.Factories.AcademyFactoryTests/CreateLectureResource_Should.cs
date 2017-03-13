using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;

namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    [TestFixture]
    public class CreateLectureResource_Should
    {
        [TestCase("invalid type")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("type")]
        public void ThrowArgumentException_WhenPassedTypeIsInvalid(string type)
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string name = "some name";
            string url = "some url";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => academyFactory.CreateLectureResource(type, name, url));
        }

        [Test]
        public void ReturnVideoResourceInstance_WhenVideoTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "video";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.IsInstanceOf<VideoResource>(lectureResource);
        }

        [Test]
        public void CorrectlyAssignPassedData_WhenVideoTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "video";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.AreEqual(name, lectureResource.Name, "Name parameter was not assigned correctly!");
            Assert.AreEqual(url, lectureResource.Url, "URL parameter was not assigned correctly!");
        }

        [Test]
        public void ReturnPresentationResourceInstance_WhenPresentationTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "presentation";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.IsInstanceOf<PresentationResource>(lectureResource);
        }

        [Test]
        public void CorrectlyAssignPassedData_WhenPresentationTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "presentation";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.AreEqual(name, lectureResource.Name, "Name parameter was not assigned correctly!");
            Assert.AreEqual(url, lectureResource.Url, "URL parameter was not assigned correctly!");
        }

        [Test]
        public void ReturnDemoResourceInstance_WhenDemoTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "demo";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.IsInstanceOf<DemoResource>(lectureResource);
        }

        [Test]
        public void CorrectlyAssignPassedData_WhenDemoTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "demo";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.AreEqual(name, lectureResource.Name, "Name parameter was not assigned correctly!");
            Assert.AreEqual(url, lectureResource.Url, "URL parameter was not assigned correctly!");
        }

        [Test]
        public void ReturnHomeworkResourceInstance_WhenHomeworkTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "homework";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.IsInstanceOf<HomeworkResource>(lectureResource);
        }

        [Test]
        public void CorrectlyAssignPassedData_WhenHomeworkTypeIsPassed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;
            string type = "homework";
            string name = "some name";
            string url = "some url";

            // Act
            var lectureResource = academyFactory.CreateLectureResource(type, name, url);

            // Assert
            Assert.AreEqual(name, lectureResource.Name, "Name parameter was not assigned correctly!");
            Assert.AreEqual(url, lectureResource.Url, "URL parameter was not assigned correctly!");
        }
    }
}
