using TAILS.Data;
using System.Text;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class PrintHelpCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public PrintHelpCommand(ITAILSEntities context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            //print info for all 5 commands (what parameters does each one take and what does it do) 
            return sb.ToString();
        }
    }
}
