using System;
using System.ComponentModel.DataAnnotations;

namespace TAILS.Models
{
    public class Exam
    {
        public Exam()
        {
        }

        [Range(1, 1000)]
        public int CourseId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public virtual Course Course { get; set; }
    }
}
