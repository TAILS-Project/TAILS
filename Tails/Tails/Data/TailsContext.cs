using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Data
{
    public class TailsContext: DbContext, ITailsContext
    {
        public TailsContext()
            : base("TailsConnection")
        {
        }

        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Exam> Exams { get; set; }
        public IDbSet<Hall> Halls { get; set; }
        public IDbSet<Seat> Saets { get; set; }
        public IDbSet<Student> Students { get; set; }
    }
}
