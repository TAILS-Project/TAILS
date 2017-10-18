﻿using TAILS.Data;
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
            throw new System.NotImplementedException();
        }
    }
}