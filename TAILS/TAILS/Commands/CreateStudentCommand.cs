using TAILS.Data;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;
using TAILS.Models;
using System.Linq;

namespace TAILS.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public CreateStudentCommand(ITAILSEntities context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            string userName = parameters[2];

            Student newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Username = userName
            };

            List<string> courseList = parameters.Skip(3).ToList();
            foreach(string course in courseList)
            {
                var courseId = int.Parse(course);
                newStudent.Courses.Add(context.Courses.First(x => x.Id == courseId));
            }

            context.Students.Add(newStudent);
            context.SaveChanges();


            return "Student created";
        }
    }
}
