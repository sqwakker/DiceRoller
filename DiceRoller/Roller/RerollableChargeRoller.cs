namespace DiceRoller.Roller;

class RerollableChargeRoller : NormalChargeRoller
{

    public override string Description => "A normal 2d6 charge with command reroll";
    public override bool Success(int target)
    {
        var r = RollDices(target);
        return r ? r : RollDices(target);
    }
}