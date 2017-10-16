using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Core.Contracts;
using Tails.Core.Factories;
using Tails.Core.Providers;
using Tails.Data;

namespace Tails.Commands
{
    public class CreateStudent : ICommand
    {
        private readonly ITailsContext context;
        private readonly IDatabase database;
        private readonly ITailsFactory factory;

        public CreateStudent(ITailsContext context, IDatabase database, ITailsFactory factory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.database = database;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            int id;
            string firstName;
            string lastName;
            string username;

            try
            {
                id = int.Parse(parameters[0]);
                firstName = parameters[1];
                lastName = parameters[2];
                username = parameters[3];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateStudent command parameters.");
            }

            var student = this.factory.CreateStudent();
            this.database.Students.Add(student);

            this.context.Students.Add(student); // tuk ne sum sigurna kude gresha

            try
            {
                this.context.SaveChanges();
            }
            catch
            {
            }

            return $"Student ......(имената му ?)....was created.";
        }
    }
}
