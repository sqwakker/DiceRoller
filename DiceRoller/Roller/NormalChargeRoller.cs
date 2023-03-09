namespace DiceRoller.Roller;

class NormalChargeRoller : RollerBase
{

    protected override bool RollDices(int target)
    {
        var a = GetDiceRoll();
        var b = GetDiceRoll();
        return (a + b) >= target;
    }

    public override string Description => "A normal 2d6 charge";

    public override bool Success(int target)
    {
        return RollDices(target);
    }

}