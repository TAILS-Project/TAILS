using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tails.Models.Abstractions
{
    public interface ICourse
    {
        int Id { get; }

        string CourseName { get; }
      }
}
