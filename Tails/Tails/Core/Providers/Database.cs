using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly List<ICourse> courses;
        private readonly List<IExam> exams;
        private readonly List<IHall> halls;
        private readonly List<ISeat> seats;
        private readonly List<IStudent> students;

        public Database()
        {
            this.courses = new List<ICourse>();
            this.exams = new List<IExam>();
            this.halls = new List<IHall>();
            this.seats = new List<ISeat>();
            this.students = new List<IStudent>();
        }

        public IList<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public IList<IExam> Exams
        {
            get
            {
                return this.exams;
            }
        }

        public IList<IHall> Halls
        {
            get
            {
                return this.halls;
            }
        }

        public IList<ISeat> Seats
        {
            get
            {
                return this.seats;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return this.students;
            }
        }

    }
}
