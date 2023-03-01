using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Roller
{
    internal interface IRoller
    {
        bool Roll(int target);
    }

    abstract class RollerBase : IRoller
    {
        protected Random Rand { get; }

        protected RollerBase()
        {
            Rand = new Random((int)(DateTime.Now.Ticks));
        }

        public abstract bool Roll(int target);
    }

    class NormalChargeRoller : RollerBase
    {

        public override bool Roll(int target)
        {
            var a = Rand.Next(6)+1;
            var b = Rand.Next(6)+1;
            return (a + b) >= target;
        }
    }

    class RerollableChargeRoller : RollerBase
    {

        public override bool Roll(int target)
        {
            var a = Rand.Next(6) + 1;
            var b = Rand.Next(6) + 1;
            if ((a + b) < target)
            {
                a = Rand.Next(6) + 1;
                b = Rand.Next(6) + 1;
            }

            return (a + b) >= target;
        }
    }
}
