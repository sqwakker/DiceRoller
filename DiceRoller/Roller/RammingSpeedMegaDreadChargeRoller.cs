namespace DiceRoller.Roller;

class RammingSpeedMegaDreadChargeRoller : RollerBase
{

    public override string Description => "Megadread on steriods, a 4d6-discard lowest dice charge with reroll";
    public override bool Success(int target)
    {
        var r = RollDices(target);
        return r ? r : RollDices(target);
    }

    protected override bool RollDices(int target)
    {
        var a = GetDiceRoll();
        var b = GetDiceRoll();
        var c = GetDiceRoll();
        var d = GetDiceRoll();

        var r = a + b + c +d;

        var min = Math.Min(Math.Min(Math.Min(a, b), c),d);
        return (r - min) >= target;
    }
}