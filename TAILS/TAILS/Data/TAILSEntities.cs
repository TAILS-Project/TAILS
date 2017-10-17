using TAILS.Models;
using System.Data.Entity;

namespace TAILS.Data
{
    public class TAILSEntities : DbContext, ITAILSEntities
    {
        public TAILSEntities()
            : base("TAILSConnection")
        {
        }

        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Exam> Exams { get; set; }
        public IDbSet<Hall> Halls { get; set; }
        public IDbSet<Seat> Seats { get; set; }
        public IDbSet<Student> Students { get; set; }
    }
}
