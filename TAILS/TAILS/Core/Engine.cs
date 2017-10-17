using System;
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

        public Engine(IReader reader, IWriter writer, ICommandParser parser)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
        }

        public void Start()
        {
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
