using System;
using TAILS.Data;
using System.Linq;
using TAILS.Models;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class UpdateExamDateTimeCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public UpdateExamDateTimeCommand(ITAILSEntities context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int examId = 0;
            if (!int.TryParse(parameters[0], out examId))
            {
                throw new ArgumentException("Invalid ExamId.");
            }

            Exam examToFind = context.Exams.Find(examId);
            if(examToFind == null)
            {
                throw new ArgumentException("No exam with the provided ExamId fround in the DB.");
            }

            DateTime newDateTime;
            var joinedDate = string.Join(" ", parameters.Skip(1));
            if (!DateTime.TryParse(joinedDate, out newDateTime))
            {
                throw new ArgumentException("Invalid DateTime.");
            }

            examToFind.DateTime = newDateTime;
            context.SaveChanges();

            return $"Updated exam with Id {examId}'s DateTime to {newDateTime.ToString()}.";
        }
    }
}
