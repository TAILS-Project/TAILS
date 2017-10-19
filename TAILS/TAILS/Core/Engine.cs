using System;
using System.IO;
using TAILS.Data;
using System.Linq;
using TAILS.Models;
using Bytes2you.Validation;
using TAILS.Core.Providers;
using System.Collections.Generic;

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
            writer.WriteLine("Welcome to TAILS (Telerik Academy Internal Learning System! Type PrintHelp for the full list of commands available.");

            if (context.Courses.Count() == 0 &&
                context.Exams.Count() == 0 &&
                context.Halls.Count() == 0 &&
                context.Seats.Count() == 0 &&
                context.Students.Count() == 0)
            {
                writer.WriteLine("Your database is empty. Initializing database. Please wait.");
                InitDatabase();
                writer.WriteLine("Your database is no longer empty. Initializing database completed.");
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
                    writer.WriteLine(Delimiter);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void InitDatabase()
        {
            JSONReader<Seat> seatsReader = new JSONReader<Seat>();
            List<Seat> seats = seatsReader.ReadFile("../../App_Data/JSON_Data/Seats.json");
            foreach (Seat seat in seats)
            {
                context.Seats.Add(seat);
            }

            JSONReader<Student> studentsReader = new JSONReader<Student>();
            List<Student> students = studentsReader.ReadFile("../../App_Data/JSON_Data/Students.json");
            foreach (Student student in students)
            {
                context.Students.Add(student);
            }

            XMLReader<Course> coursesReader = new XMLReader<Course>();
            List<Course> courses = coursesReader.ReadFile("../../App_Data/XML_Data/Courses.xml");
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
                foreach (Student student in students)
                {
                    student.Courses.Add(course);
                }
            }

            XMLReader<Exam> examsReader = new XMLReader<Exam>();
            List<Exam> exams = examsReader.ReadFile("../../App_Data/XML_Data/Exams.xml");
            foreach (Exam exam in exams)
            {
                context.Exams.Add(exam);
            }
            
            JSONReader<Hall> hallsReader = new JSONReader<Hall>();
            List<Hall> halls = hallsReader.ReadFile("../../App_Data/JSON_Data/Halls.json");
            foreach (Hall hall in halls)
            {
                context.Halls.Add(hall);
            }

            context.SaveChanges();
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
            writer.WriteLine(result);
        }
    }
}
