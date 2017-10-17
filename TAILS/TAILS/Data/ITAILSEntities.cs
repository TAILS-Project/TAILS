using TAILS.Models;
using System.Data.Entity;

namespace TAILS.Data
{
    public interface ITAILSEntities
    {
        IDbSet<Course> Courses { get; set; }
        IDbSet<Exam> Exams { get; set; }
        IDbSet<Hall> Halls { get; set; }
        IDbSet<Seat> Seats { get; set; }
        IDbSet<Student> Students { get; set; }

        int SaveChanges();
    }
}
