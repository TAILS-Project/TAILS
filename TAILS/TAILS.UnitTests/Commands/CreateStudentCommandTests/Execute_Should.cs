//using Moq;
//using TAILS.Data;
//using TAILS.Commands;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TAILS.UnitTests.Commands.CreateStudentCommandTests
//{
//    [TestClass]
//    public class Execute_Should
//    {
//        [TestMethod]
//        public void ShouldCallSaveChanges_WhenParametersAreCorrect()
//        {
//            // Arrange
//            var contextMock = new Mock<ITAILSEntities>();

//            var firstName = "Viktor";
//            var lastName = "Tsvetkov";
//            var username = "Viktor.Tsvetkov";
//            var courseId = "1";
//            var parameters = new List<string>() { firstName, lastName, username, courseId };

//            CreateStudentCommand command = new CreateStudentCommand(contextMock.Object);
//            //string expectedResult = $"Created student with Username {username} and Id 1.";


//            //Act
//            string actualResult = command.Execute(parameters);

//            //Assert
//            contextMock.Verify(m => m.SaveChanges(), Times.Once());
//            //Assert.AreEqual(expectedResult, actualResult);
//        }
//    }
//}
