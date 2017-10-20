using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAILS.Commands.Contracts;
using TAILS.Core.Factories;
using TAILS.Core.Providers;

namespace TAILS.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {

        [TestMethod]
        [DataRow("CreateStudent Martin Ivanov tstorm", "CreateStudent")]
        [DataRow("DeleteStudent 1", "DeleteStudent")]
        public void ReturnCommand_WhenParameterIsCorrect(string fullCommand, string commandName)
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            factoryMock.Setup(m => m.CreateCommand(commandName)).Returns(commandMock.Object);

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseCommand(fullCommand);

            // Assert
            Assert.AreEqual(commandMock.Object, result);
        }

        [TestMethod]
        [DataRow("Something something", "CreateStudent")]
        [DataRow("bla bla", "DeleteStudent")]
        [DataRow("", "DeleteStudent")]
        public void ReturnCommand_WhenParameterIsIncorrect(string fullCommand, string commandName)
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            factoryMock.Setup(m => m.CreateCommand(commandName)).Returns(commandMock.Object);

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseCommand(fullCommand);

            // Assert
            Assert.IsNull(result);
        }
    }
}
