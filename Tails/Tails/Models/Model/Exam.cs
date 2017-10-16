using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tails.Models.Model
{
    public class Exam
    {
                
        public Exam()
        {
        }

        [Range(1, 1000)]
        public int CourseId { get; set; }
       
        public DateTime DateTime { get; set; }

    }
}
