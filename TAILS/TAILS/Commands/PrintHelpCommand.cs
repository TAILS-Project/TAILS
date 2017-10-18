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
            sb.AppendLine("DeleteStudent -> Input parameters: Id");
            sb.AppendLine("GenerateSeatsMapping -> Input parameters: ExamId HallId");
            sb.AppendLine("UpdateExamDateTime -> Input parameters: ExamId NewDateTime");
            sb.Append("CreateStudent -> Input parameters: FirstName LastName Username CourseIds");

            return sb.ToString();
        }
    }
}
