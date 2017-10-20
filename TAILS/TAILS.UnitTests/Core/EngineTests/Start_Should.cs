using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAILS.Commands;
using TAILS.Commands.Contracts;
using TAILS.Core.Providers;
using TAILS.Data;
using TAILS.Models;

namespace TAILS.UnitTests.Engine.EngineTests
{
    [TestClass]
    public class Start_Should
    {


        [TestMethod]
        public void AddStudentToContext_WhenCorrectParametersAreGivenAndDbIsInitialized()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var contextMock = new Mock<ITAILSEntities>();
            var createStudentCommandMock = new Mock<ICommand>();
            var students = ContextHelper.GetQueryableMockDbSet<Student>(new Student { FirstName = "Tozi", LastName = "Onzi", Username = "toziOnzev" });
            var courses = ContextHelper.GetQueryableMockDbSet<Course>();
            var halls = ContextHelper.GetQueryableMockDbSet<Hall>();
            var exams = ContextHelper.GetQueryableMockDbSet<Exam>();
            var seats = ContextHelper.GetQueryableMockDbSet<Seat>();
            

            var engineInstance =
                new TAILS.Core.Engine(readerMock.Object, writerMock.Object, parserMock.Object, contextMock.Object);

            readerMock.SetupSequence(x => x.ReadLine())
                .Returns("CreateStudent Martin Ivanov tstorm 1")
                .Returns("Exit");
            parserMock.Setup<ICommand>(x => x.ParseCommand(It.IsAny<string>())).Returns(createStudentCommandMock.Object);
            parserMock.Setup<IList<string>>(x => x.ParseParameters(It.IsAny<string>())).Returns(It.IsAny<IList<string>>());
            contextMock.SetupGet(x => x.Students).Returns(students);
            contextMock.SetupGet(x => x.Courses).Returns(courses);
            contextMock.SetupGet(x => x.Halls).Returns(halls);
            contextMock.SetupGet(x => x.Exams).Returns(exams);
            contextMock.SetupGet(x => x.Seats).Returns(seats);

            //Act
            engineInstance.Start();

            //Assert
            createStudentCommandMock.Verify(x => x.Execute(It.IsAny<IList<string>>()),Times.Once);
            writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }



        [TestMethod]
        public void AddStudentToContext_WhenEmptyParametersAreGiven()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var contextMock = new Mock<ITAILSEntities>();
            var students = ContextHelper.GetQueryableMockDbSet<Student>(new Student { FirstName = "Tozi", LastName = "Onzi", Username = "toziOnzev" });
            var courses = ContextHelper.GetQueryableMockDbSet<Course>();
            var halls = ContextHelper.GetQueryableMockDbSet<Hall>();
            var exams = ContextHelper.GetQueryableMockDbSet<Exam>();
            var seats = ContextHelper.GetQueryableMockDbSet<Seat>();


            var engineInstance =
                new TAILS.Core.Engine(readerMock.Object, writerMock.Object, parserMock.Object, contextMock.Object);

            readerMock.SetupSequence(x => x.ReadLine())
                .Returns("")
                .Returns("Exit");
            parserMock.Setup<IList<string>>(x => x.ParseParameters(It.IsAny<string>())).Returns(It.IsAny<IList<string>>());
            contextMock.SetupGet(x => x.Students).Returns(students);
            contextMock.SetupGet(x => x.Courses).Returns(courses);
            contextMock.SetupGet(x => x.Halls).Returns(halls);
            contextMock.SetupGet(x => x.Exams).Returns(exams);
            contextMock.SetupGet(x => x.Seats).Returns(seats);

            //Act
            engineInstance.Start();

            //Assert
            writerMock.Verify(x=>x.WriteLine("Value cannot be null.\r\nParameter name: Command cannot be null or empty."), Times.Once);
        }
    }
}
