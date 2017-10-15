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
    public class Student : IStudent
    {

        public Student(int id, string firstName, string lastName, string username)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
        }

        [Range(1, 100)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Username { get; set; }

    }
}
