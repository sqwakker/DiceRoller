namespace DiceRoller.Roller;

class ThreeD6PickHighestChargeRoller : NormalChargeRoller
{

    public override string Description => "A 3d6-discard lowest dice charge";


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