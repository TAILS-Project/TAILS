using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Core.Providers
{
    public class Database
    {
        private readonly List<Course> courses;
        private readonly List<Exam> exams;
        private readonly List<Hall> halls;
        private readonly List<Seat> seats;
        private readonly List<Student> students;

        public Database()
        {
            this.courses = new List<Course>();
            this.exams = new List<Exam>();
            this.halls = new List<Hall>();
            this.seats = new List<Seat>();
            this.students = new List<Student>();
        }

        public IList<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public IList<Exam> Exams
        {
            get
            {
                return this.exams;
            }
        }

        public IList<Hall> Halls
        {
            get
            {
                return this.halls;
            }
        }

        public IList<Seat> Seats
        {
            get
            {
                return this.seats;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }
        }

    }
}
