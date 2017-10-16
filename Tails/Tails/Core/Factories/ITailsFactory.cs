using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Model;

namespace Tails.Core.Factories
{
    public interface ITailsFactory
    {
        Course CreateCourse();

        Exam CreateExam();

        Hall CreateHall();

        Seat CreateSeat();

        Student CreateStudent();
    }
}
