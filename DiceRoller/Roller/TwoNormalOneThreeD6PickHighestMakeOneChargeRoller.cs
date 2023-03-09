namespace DiceRoller.Roller;

class TwoNormalOneThreeD6PickHighestMakeOneChargeRoller : NormalChargeRoller
{

    public override string Description => "Two normal and one 3d6-discard lowest dice charge, make at least one";


    protected override bool RollDices(int target)
    {
        var a = GetDiceRoll();
        var b = GetDiceRoll();
        var c = GetDiceRoll();

        var r = a + b + c;

        var min = Math.Min(Math.Min(a, b), c);
        return (r-min) >= target;
    }

    public override bool Success(int target)
    {
        var _3d6Roll =  RollDices(target) ? 1:0;
        var normalRoll1 = base.RollDices(target) ? 1:0;
        var normalRoll2 = base.RollDices(target) ? 1 : 0;

        return (_3d6Roll + normalRoll1 + normalRoll2) >= 1;

    }
}