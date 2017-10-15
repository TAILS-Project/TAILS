using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Core.Providers
{
    public interface IDatabase
    {
        IList<ICourse> Courses { get; }
        IList<IExam> Exams { get; }
        IList<IHall> Halls { get; }
        IList<ISeat> Seats { get; }
        IList<IStudent> Students { get; }
    }
}
