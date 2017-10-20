using System;
using TAILS.Data;
using System.Linq;
using System.Text;
using TAILS.Models;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class ListSeatsCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public ListSeatsCommand(ITAILSEntities context)
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
            int hallId = 0;
            if (!int.TryParse(parameters[0], out hallId))
            {
                throw new ArgumentException("Invalid HallId.");
            }

            StringBuilder sb = new StringBuilder();

            List<Seat> seats = new List<Seat>();
            seats = context.Seats.Where(x => x.HallId == hallId).ToList();
            foreach (Seat seat in seats)
            {
                sb.AppendLine($"SeatId: {seat.Id}; HallId: {seat.HallId}; X: {seat.X}; Y: {seat.Y}");
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
