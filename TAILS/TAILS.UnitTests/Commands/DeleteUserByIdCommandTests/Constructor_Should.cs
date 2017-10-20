using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TAILS.Commands;
using TAILS.Data;

namespace TAILS.UnitTests.Commands.DeleteUserByIdCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnObject_WhenProperArgumentIsGiven()
        {
            //Arrange
            var contextMock = new Mock<ITAILSEntities>();

            //Act
            var commandInstance =
                new DeleteStudentByIdCommand(contextMock.Object);

            //Assert
            Assert.IsNotNull(commandInstance);
        }

        [TestMethod]
        public void ThrowError_WhenNullContextIsGiven()
        {
            //Arrange && Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new DeleteStudentByIdCommand(null));
        }

    }
}
