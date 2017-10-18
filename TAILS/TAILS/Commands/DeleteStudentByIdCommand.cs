using TAILS.Data;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;
using System.Linq;

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
            var temp = int.Parse(parameters[0]);
            var delSt = context.Students.First(st => st.Id == temp);

            context.Students.Remove(delSt);
            context.SaveChanges();
            return "Student Deleted.";
        }
    }
}
