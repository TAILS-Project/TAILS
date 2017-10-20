using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAILS.Core.Factories;
using TAILS.Core.Providers;

namespace TAILS.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnObject_WhenProperArgumentsIsGiven()
        {
            //Arrange
            var factoryMock = new Mock<ICommandFactory>();

            //Act
            var commandParserInstance =
                new CommandParser(factoryMock.Object);

            //Assert
            Assert.IsNotNull(commandParserInstance);
        }

        [TestMethod]
        public void ReturnObject_WhenNullArgumentGiven()
        {
            //Arrange && Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
