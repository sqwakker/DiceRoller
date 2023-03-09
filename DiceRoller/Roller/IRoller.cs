using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Roller
{
    internal interface IRoller
    {
        string Name { get; }
        string Description { get; }
        bool Success(int target);
    }
}
