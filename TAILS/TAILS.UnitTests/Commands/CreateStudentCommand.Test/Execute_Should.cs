using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TAILS.Data;
using TAILS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TAILS.UnitTests.Commands.CreateStudentCommand.Test
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShouldCreateAddStudentToDatabase()
        {
            // Arrange

            var contextMock = new Mock<ITAILSEntities>();
            //var dbsetMock = new Mock<DbSet>();

            var firstName = "Mi";
            var lastName = "Iv";
            var username = "migldg";
            var input = new List<string>() { firstName, lastName, username };

            var studentDbSet = new Mock<DbSet<Student>>();

            var studentMock = new Mock<Student>();
            var courseId = 1;

            var courses = new HashSet<Course>();

            var courseMi = new Course();
            courseMi.Id = courseId;

            studentMock.Setup(x => x.Courses).Returns(courses);
            contextMock.SetupGet(c => c.Students)
                   .Returns(studentDbSet.Object);

            studentMock.Object.Courses.Add(courseMi);

            //Act
            var command = new TAILS.Commands.CreateStudentCommand(contextMock.Object);
            command.Execute(input);

            //Assert
            Assert.AreEqual(1, contextMock.Object.Students.Count());

        }
               
    }
}

