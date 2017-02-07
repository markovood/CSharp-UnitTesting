using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class CourseClassTests
    {
        [TestMethod]
        public void Test_CreatingNewInstanceShouldInitializeStudentsProperty()
        {
            // Arrange & Act
            var course = new Course();

            // Assert
            Assert.IsNotNull(course.Students, "Students property is not initialized!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_JoinStudentWithStudentSetToNullShouldThrowException()
        {
            // Arrange
            var course = new Course();

            // Act
            course.JoinStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_JoinSameStudentShouldThrowException()
        {
            // Arrange
            var course = new Course();
            var studentGosho = new Student("Gosho", 10001);

            // Act
            course.JoinStudent(studentGosho);
            course.JoinStudent(studentGosho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_JoinStudentToCourseThatHas30StudentsShouldThrowException()
        {
            // Arrange
            var course = new Course();

            // Act
            for (int i = 0, j = 10000; i <= 30; i++, j++)
            {
                course.JoinStudent(new Student(string.Format("Student'sName{0}", i + 1), j));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_JoinStudentToCourseThatExceeds30StudentsShouldThrowException()
        {
            // Arrange
            var course = new Course();

            // Act
            for (int i = 0, j = 10000; i < 31; i++, j++)
            {
                course.JoinStudent(new Student(string.Format("Student'sName{0}", i + 1), j));
            }
        }

        [TestMethod]
        public void Test_LeaveStudentFromCourseShouldRemoveItFromCollection()
        {
            // Arrange
            var course = new Course();

            // Act
            for (int i = 0, j = 10000; i < 20; i++, j++)
            {
                course.JoinStudent(new Student(string.Format("Student'sName{0}", i + 1), j));
            }

            var studentToRemove = new Student("Student'sName10", 10009);
            course.LeaveStudent(studentToRemove);

            // Assert
            Assert.IsFalse(course.Students.Contains(studentToRemove), "This course still contains the student which had to leave!");
        }
    }
}
