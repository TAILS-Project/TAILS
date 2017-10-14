using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Hall : IHall
    {
        private int id;
        private int capacity;
        private string name;
        private string picture;  //Pict string ??

        public Hall(int id, int capacity, string name, string picture)
        {
            this.Id = id;
            this.Capacity = capacity;
            this.Name = name;
            this.Picture = picture;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                Guard.WhenArgument(id, "id").IsLessThan(1).Throw();
                this.id = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                Guard.WhenArgument(capacity, "capacity").IsLessThan(1).Throw();
                this.capacity = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Guard.WhenArgument(name, "name").IsNotNullOrEmpty().Throw();
                this.name = value;
            }
        }

       // ?? Pict Valid
        public string Picture { get; }
    }
}
