using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Course : ICourse
    {
        public Course(int id, string courseName)
        {
            this.Id = id;
            this.CourseName = courseName;
        }

        [Range(1, 1000)]
        public int Id { get; set; }
        
        public string CourseName { get; set; }
       

    }
}
