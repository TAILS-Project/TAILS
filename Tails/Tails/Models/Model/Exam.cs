using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Exam : IExam
    {

        private int courseId;
        private DateTime dateTime;

        public Exam(int courseId, DateTime dateTime)
        {
            this.CourseId = courseId;
            this.DateTime = dateTime;
        }

        public int CourseId
        {
            get
            {
                return this.courseId;
            }
            private set
            {
                Guard.WhenArgument(courseId, "courseId").IsLessThan(1).Throw();
                this.courseId = value;
            }
        }

        //Validation ?? DateTime
        public DateTime DateTime { get; }

    }
}
