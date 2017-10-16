using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Core.Factories
{
    public class TailsFactory : ITailsFactory
    {
        public Course CreateCourse()
        {
            return new Course();
        }

        public Exam CreateExam()
        {
            return new Exam();
        }

        public Hall CreateHall()
        {
            return new Hall();
        }

        public Seat CreateSeat()
        {
            return new Seat();
        }

        public Student CreateStudent()
        {
            return new Student();
        }
    }
}
