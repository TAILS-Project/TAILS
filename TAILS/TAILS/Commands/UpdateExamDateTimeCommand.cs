using TAILS.Data;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using TAILS.Models;

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
                throw new ArgumentException("examid is invalid");
            }

            Exam examToFind = context.Exams.Find(examId);

            if(examToFind == null)
            {
                throw new ArgumentException("there is no such exam in the DB");
            }

            DateTime newDateTime;
            var joinedDate = string.Join(" ", parameters.Skip(1));

            if (!DateTime.TryParse(joinedDate, out newDateTime))
            {
                throw new ArgumentException("DateTime format is invalid");
            }

            examToFind.DateTime = newDateTime;
            context.SaveChanges();

            return $"Updated exam with id: {examId} to: {newDateTime.ToString()}.";
        }
    }
}
