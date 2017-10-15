using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Data
{
    public interface ITailsContext 
    {
        IDbSet<Course> Courses { get; set; }
        IDbSet<Exam> Exams { get; set; }
        IDbSet<Hall> Halls { get; set; }
        IDbSet<Seat> Saets { get; set; }
        IDbSet<Student> Students { get; set; }

        int SaveChanges();
    }
}
