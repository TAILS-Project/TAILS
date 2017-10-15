using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Hall : IHall
    {
       
        public Hall(int id, int capacity, string name, string picture)
        {
            this.Id = id;
            this.Capacity = capacity;
            this.Name = name;
            this.Picture = picture;
        }

        [Range(1, 1000)]
        public int Id { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        public string Name { get; set; }
                     
        public string Picture { get; set; }
    }
}
