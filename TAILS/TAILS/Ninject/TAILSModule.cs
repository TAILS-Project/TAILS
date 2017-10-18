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
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
            this.Bind<ICommand>().To<DeleteStudentByIdCommand>().Named("DeleteStudent");
            this.Bind<ICommand>().To<GenerateSeatsMappingCommand>().Named("GenerateSeatsMap");
            this.Bind<ICommand>().To<PrintHelpCommand>().Named("PrintHelp");
            this.Bind<ICommand>().To<UpdateExamDateTimeCommand>().Named("UpdateExamDateTime");

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();

            this.Bind<ITAILSEntities>().To<TAILSEntities>();
            this.Bind<IEngine>().To<Engine>();
            this.Bind<ICommandFactory>().To<CommandFactory>();

            this.Bind<ICommandParser>().To<CommandParser>();
            this.Bind<IFileReader<Exam>>().To<XMLReader<Exam>>().Named("ExamReaderXML");
            this.Bind<IFileReader<Course>>().To<XMLReader<Course>>().Named("CoursesReaderXML");
            this.Bind<IFileReader<Hall>>().To<JSONReader<Hall>>().Named("HallReaderJSON");
            this.Bind<IFileReader<Student>>().To<JSONReader<Student>>().Named("StudentReaderJSON");
            this.Bind<IFileReader<Seat>>().To<JSONReader<Seat>>().Named("SeatReaderJSON");
        }
    }
}
