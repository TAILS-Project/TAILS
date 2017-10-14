using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;
using Tails.Models.Model;

namespace Tails.Core.Factories
{
    public class TailsFactory : ITailsFactory
    {
        public ICourse CreateCourse(int id, string courseName)
        {
            return new Course(id, courseName);
        }

        public IExam CreateExam(int courseId, DateTime dateTime)
        {
            return new Exam(courseId, dateTime);
        }

        public IHall CreateHall(int id, int capacity, string name, string pictures)
        {
            return new Hall(id, capacity, name, pictures);
        }

        // Seats are not finnished
        public ISeat CreateSeat()
        {
            return new Seat();
        }

        public IStudent CreateStudent(int id, string firstName, string lastName, string username)
        {
            return new Student(id, firstName, lastName, username);
        }
    }
}
