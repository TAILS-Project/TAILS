using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Core.Factories
{
    public interface ITailsFactory
    {
        ICourse CreateCourse(int id, string courseName);

        IExam CreateExam(int courseId, DateTime dateTime);

        IHall CreateHall(int id, int capacity, string name, string pictures);

        ISeat CreateSeat();

        IStudent CreateStudent(int id, string firstName, string lastName, string username);
    }
}
