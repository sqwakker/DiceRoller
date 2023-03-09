namespace DiceRoller.Roller;

class RerollOneDiceChargeRoller : NormalChargeRoller
{

    public override string Description => "A normal 2d6 charge with single dice reroll (like 'ere we go)";
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