using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Core.Providers
{
    public interface IDatabase
    {
        IList<Course> Courses { get; }
        IList<Exam> Exams { get; }
        IList<Hall> Halls { get; }
        IList<Seat> Seats { get; }
        IList<Student> Students { get; }
    }
}
