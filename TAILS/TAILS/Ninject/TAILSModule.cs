using Newtonsoft.Json;
using Ninject.Modules;
using TAILS.Commands;
using TAILS.Commands.Contracts;
using TAILS.Core;
using TAILS.Core.Factories;
using TAILS.Core.Providers;
using TAILS.Data;
using TAILS.Models;

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

            this.Bind<ITAILSEntities>().To<ITAILSEntities>();
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
