using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAILS.Models
{
    public class Hall
    {
        private ICollection<Seat> seats;

        public Hall()
        {
            this.seats = new HashSet<Seat>();
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The Name's length should be between 5 and 40 symbols long.")]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Seat> Seats
        {
            get
            {
                return this.seats;
            }
            set
            {
                this.seats = value;   
            }
        }
    }
}
