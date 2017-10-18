using System.Text;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class PrintHelpCommand : ICommand
    {
        public PrintHelpCommand()
        {
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            //print info for all 5 commands (what parameters does each one take and what does it do) 
            return sb.ToString();
        }
    }
}
