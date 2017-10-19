using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TAILS.Data;
using TAILS.Models;
using System.Collections.Generic;

namespace TAILS.UnitTests.Commands.CreateStudentCommand.Test
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ShouldCreateAddStudentToDatabase()
        //ReturnSuccessMessage_WhenParametersAreValid()
        {
            // Arrange
            var contextMock = new Mock<ITAILSEntities>();

            var firstName = "Mi";
            var lastName = "Iv";
            var username = "Iv";

            var studentMock = new Mock<Student>(firstName,lastName,username);

            List<string> courseList = new List<string>();

            var courseId = 8;


            seasonMock.SetupGet(s => s.Courses)
                .Returns(seasonCourses);

            databaseMock.SetupGet(d => d.Seasons)
                .Returns(databaseSeasons);


        }
    }
}
