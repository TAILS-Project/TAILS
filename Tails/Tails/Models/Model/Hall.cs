using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tails.Models.Model
{
    public class Hall 
    {

        public Hall()
        {
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
