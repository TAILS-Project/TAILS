using System;
using System.ComponentModel.DataAnnotations;

namespace TAILS.Models
{
    public class Seat
    {
        public Seat()
        {
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Required]
        [Range(1, 9000)]
        public int X { get; set; }

        [Required]
        [Range(1, 9000)]
        public int Y { get; set; }

        [Range(1, 1000)]
        public int? HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
