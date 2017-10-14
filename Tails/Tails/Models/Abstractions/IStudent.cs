using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tails.Models.Abstractions
{
    public interface IStudent
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string Username { get; }
    }
}
