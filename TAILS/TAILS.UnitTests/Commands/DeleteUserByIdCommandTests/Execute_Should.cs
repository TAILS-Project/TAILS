using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAILS.Commands;
using TAILS.Data;
using TAILS.Models;

namespace TAILS.UnitTests.Commands.DeleteUserByIdCommandTests
{
    [TestClass]
    public class Execute_Should
    {

        [TestMethod]
        public void DeleteStudent_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<ITAILSEntities>();
            var students = ContextHelper.GetQueryableMockDbSet<Student>
                (new Student { Id=1, FirstName = "Ivan", LastName = "Ivanov", Username = "vankata1337" });
            var deleteStudentCommand = new DeleteStudentByIdCommand(contextMock.Object);
            var paramsList = new List<string>() { "1" };
            contextMock.SetupGet(x => x.Students).Returns(students);

            //Act
            deleteStudentCommand.Execute(paramsList);

            //Assert
            contextMock.Verify(x => x.SaveChanges(), Times.Once);
            //contextMock.Verify(x => x.Students.Remove(It.IsAny<Student>()), Times.Once);
            //Assert.AreEqual(contextMock.Object.Students.Count<Student>(), 0);
        }
    }
}
