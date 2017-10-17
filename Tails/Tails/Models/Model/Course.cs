using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tails.Models.Model
{
    public class Course
    {
        public Course()
        {
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        public string CourseName { get; set; }
       

    }
}
