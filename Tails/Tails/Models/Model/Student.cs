using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;

        public Student(int id, string firstName, string lastName, string username)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
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

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Guard.WhenArgument(firstName, "firstName").IsNotNullOrEmpty().Throw();
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Guard.WhenArgument(lastName, "lastName").IsNotNullOrEmpty().Throw();
                this.lastName = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Guard.WhenArgument(username, "username").IsNotNullOrEmpty().Throw();
                this.username = value;
            }
        }

    }
}
