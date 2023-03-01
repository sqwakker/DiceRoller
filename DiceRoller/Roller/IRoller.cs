using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Roller
{
    internal interface IRoller
    {
        bool Success(int target);
    }

    abstract class RollerBase : IRoller
    {
        protected Random Rand { get; }

        protected RollerBase()
        {
            Rand = new Random((int)(DateTime.Now.Ticks));
        }

        public abstract bool Success(int target);

        protected int GetDiceRoll()
        {
            return Rand.Next(1, 7);
        }

        protected abstract bool RollDices(int target);
    }

    class NormalChargeRoller : RollerBase
    {

        protected override bool RollDices(int target)
        {
            var a = GetDiceRoll();
            var b = GetDiceRoll();
            return (a + b) >= target;
        }

        public override bool Success(int target)
        {
            return RollDices(target);
        }

    }

    class RerollableChargeRoller : NormalChargeRoller
    {

        public override bool Success(int target)
        {
            var r = RollDices(target);
            return r ? r : RollDices(target);
        }
    }

    class RerollOneDiceChargeRoller : NormalChargeRoller
    {
        protected override bool RollDices(int target)
        {
            var a = GetDiceRoll();
            var b = GetDiceRoll();

            var r = a + b;

            if (r >= target)
            {
                return true;
            }

            if (a <= b)
            {
                a = GetDiceRoll();
            }
            else
            {
                b = GetDiceRoll();
            }

            return (a+b) >= target;
        }
    }


    class ThreeD6PickHighestChargeRoller : NormalChargeRoller
    {

        protected override bool RollDices(int target)
        {
            var a = GetDiceRoll();
            var b = GetDiceRoll();
            var c = GetDiceRoll();

            var r = a + b + c;

            var min = Math.Min(Math.Min(a, b), c);
            return (r-min) >= target;
        }
    }

    class ThreeD6PickHighestRerollableChargeRoller : ThreeD6PickHighestChargeRoller
    {
  
        public override bool Success(int target)
        {
            var r = RollDices(target);
            return r ? r : RollDices(target);
        }

    }
}
