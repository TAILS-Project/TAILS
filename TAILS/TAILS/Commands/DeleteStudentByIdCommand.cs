using System;
using TAILS.Data;
using System.Linq;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class DeleteStudentByIdCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public DeleteStudentByIdCommand(ITAILSEntities context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new ArgumentException("Invalid number of parameters.");
            }
            int id = 0;
            if (!int.TryParse(parameters[0], out id))
            {
                throw new ArgumentException("Invalid StudentId.");
            }
            var delSt = context.Students.First(st => st.Id == id);

            context.Students.Remove(delSt);
            context.SaveChanges();

            return $"Deleted student with Username {delSt.Username} and Id {id}.";
        }
    }
}
