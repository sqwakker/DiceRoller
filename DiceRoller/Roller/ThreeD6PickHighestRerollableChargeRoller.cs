namespace DiceRoller.Roller;

class ThreeD6PickHighestRerollableChargeRoller : ThreeD6PickHighestChargeRoller
{

    public override string Description => "A 3d6-discard lowest dice charge with command reroll";
    public override bool Success(int target)
    {
        var r = RollDices(target);
        return r ? r : RollDices(target);
    }

}