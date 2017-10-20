using System;
using TAILS.Data;
using System.Linq;
using TAILS.Models;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

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
            if (parameters.Count() < 3)
            {
                throw new ArgumentException("Invalid number of parameters.");
            }

            string firstName = parameters[0];
            string lastName = parameters[1];
            string username = parameters[2];

            Student newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username
            };

            List<string> courseList = parameters.Skip(3).ToList();
            foreach(string course in courseList)
            {
                var courseId = int.Parse(course);
                newStudent.Courses.Add(context.Courses.First(x => x.Id == courseId));
            }

            context.Students.Add(newStudent);
            context.SaveChanges();

            int id = context.Students.OrderByDescending(s => s.Id).FirstOrDefault().Id;

            return $"Created student with Username {username} and Id {id}.";
        }
    }
}
