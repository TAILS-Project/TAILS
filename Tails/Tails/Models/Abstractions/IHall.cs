using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tails.Models.Abstractions
{
    public interface IHall
    {
        int Id { get; }

        int Capacity { get; }

        string Name { get; }

        string Picture { get; }
    }
}
