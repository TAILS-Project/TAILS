using Moq;
using System;
using TAILS.Core;
using TAILS.Data;
using TAILS.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TAILS.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnObject_WhenProperArgumentsAreGiven()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var contextMock = new Mock<ITAILSEntities>();

            //Act
            var engineInstance =
                new TAILS.Core.Engine(readerMock.Object, writerMock.Object, parserMock.Object, contextMock.Object);

            //Assert
            Assert.IsNotNull(engineInstance);
        }

        [TestMethod]
        public void ThrowError_WhenNullReaderIsGiven()
        {
            //Arrange
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var contextMock = new Mock<ITAILSEntities>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new TAILS.Core.Engine(null, writerMock.Object, parserMock.Object, contextMock.Object));
        }

        [TestMethod]
        public void ThrowError_WhenNullWriterIsGiven()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var parserMock = new Mock<ICommandParser>();
            var contextMock = new Mock<ITAILSEntities>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new TAILS.Core.Engine(readerMock.Object, null, parserMock.Object, contextMock.Object));
        }

        [TestMethod]
        public void ThrowError_WhenNullCommandParserIsGiven()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var contextMock = new Mock<ITAILSEntities>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new TAILS.Core.Engine(readerMock.Object, writerMock.Object, null, contextMock.Object));
        }

        [TestMethod]
        public void ThrowError_WhenNullContextIsGiven()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new TAILS.Core.Engine(readerMock.Object, writerMock.Object, parserMock.Object, null));
        }
    }
}