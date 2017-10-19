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

        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Course's name shouldn't be longer than 40 symbols.")]
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
