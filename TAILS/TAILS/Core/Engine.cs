using System;
using System.IO;
using TAILS.Data;
using System.Linq;
using Bytes2you.Validation;
using TAILS.Core.Providers;

namespace TAILS.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string Delimiter = "--------------------";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser parser;
        private readonly ITAILSEntities context;

        public Engine(IReader reader, IWriter writer, ICommandParser parser, ITAILSEntities context)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
            this.context = context;
        }

        public void Start()
        {
            if (context.Courses.Count() == 0 &&
                context.Exams.Count() == 0 &&
                context.Halls.Count() == 0 &&
                context.Seats.Count() == 0 &&
                context.Students.Count() == 0)
            {
                InitDatabase();
            }

            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }
                    this.ProcessCommand(commandAsString);
                    Console.WriteLine(Delimiter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void InitDatabase()
        {
            string[] JSONFilesNames = Directory.GetFiles("../../App_Data/JSON_Data");
            foreach (string s in JSONFilesNames)
            {
                Console.WriteLine(s);
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);
            var result = command.Execute(parameters);
            Console.WriteLine(result);
        }
    }
}
