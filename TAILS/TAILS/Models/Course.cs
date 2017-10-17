using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAILS.Models
{
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The CourseName's length should be between 5 and 40 symbols long.")]
        public string CourseName { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
