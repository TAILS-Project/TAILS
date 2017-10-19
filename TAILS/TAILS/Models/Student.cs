using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAILS.Models
{
    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Student's first name shouldn't be longer than 40 symbols.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Student's last name shouldn't be longer than 40 symbols.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Student's user name shouldn't be longer than 40 symbols.")]
        public string Username { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
    }
}
