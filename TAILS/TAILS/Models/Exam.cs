using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAILS.Models
{
    public class Exam
    {
        public Exam()
        {
        }

        [ForeignKey("Course")]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public virtual Course Course { get; set; }
    }
}
