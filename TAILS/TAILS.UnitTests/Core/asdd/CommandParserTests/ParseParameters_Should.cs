using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TAILS.Core.Factories;
using TAILS.Core.Providers;

namespace TAILS.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {

        [TestMethod]
        [DataRow("CreateStudent Martin Ivanov tstorm",3)]
        [DataRow("DeleteStudent 1",1)]
        [DataRow("DeleteStudent", 0)]
        [DataRow("", 0)]
        public void ReturnParametersList_WhenProperArgumentIsGiven(string fullCommand, int listLength)
        {
            //Arrange 
            var factoryMock = new Mock<ICommandFactory>();
            var parser = new CommandParser(factoryMock.Object);

            //Act
            var result = parser.ParseParameters(fullCommand);

            //Assert
            Assert.AreEqual(result.Count, listLength);
        }

    }
}
