using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tails.Models.Model
{
    public class Seat
    {
        public Seat()
        {
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Range(1, 1000)]
        public int HallId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
