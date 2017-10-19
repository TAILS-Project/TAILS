using TAILS.Data;
using TAILS.Core;
using TAILS.Models;
using TAILS.Commands;
using Ninject.Modules;
using TAILS.Core.Factories;
using TAILS.Core.Providers;
using TAILS.Commands.Contracts;

namespace TAILS.Ninject
{
    public class TAILSModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITAILSEntities>().To<TAILSEntities>();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<ICommandParser>().To<CommandParser>();

            this.Bind<ICommandFactory>().To<CommandFactory>();

            this.Bind<IEngine>().To<Engine>();

            this.Bind<ICommand>().To<PrintHelpCommand>().Named("PrintHelp");
            this.Bind<ICommand>().To<ListSeatsCommand>().Named("ListSeats");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
            this.Bind<ICommand>().To<DeleteStudentByIdCommand>().Named("DeleteStudent");
            this.Bind<ICommand>().To<GenerateSeatsMappingCommand>().Named("GenerateSeatsMapping");
            this.Bind<ICommand>().To<UpdateExamDateTimeCommand>().Named("UpdateExamDateTime");

            this.Bind<IFileReader<Exam>>().To<XMLReader<Exam>>().Named("ExamReaderXML");
            this.Bind<IFileReader<Hall>>().To<JSONReader<Hall>>().Named("HallReaderJSON");
            this.Bind<IFileReader<Seat>>().To<JSONReader<Seat>>().Named("SeatReaderJSON");
            this.Bind<IFileReader<Course>>().To<XMLReader<Course>>().Named("CoursesReaderXML");
            this.Bind<IFileReader<Student>>().To<JSONReader<Student>>().Named("StudentReaderJSON");
        }
    }
}
