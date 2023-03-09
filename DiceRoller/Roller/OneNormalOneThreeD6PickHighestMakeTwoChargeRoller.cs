namespace DiceRoller.Roller;

class OneNormalOneThreeD6PickHighestMakeTwoChargeRoller : OneNormalOneThreeD6PickHighestMakeOneChargeRoller
{

    public override string Description => "One normal and one 3d6-discard lowest dice charge, make both";



    public override bool Success(int target)
    {
        var _3d6Roll =  RollDices(target) ? 1:0;
        var normalRoll = base.RollDices(target) ? 1:0;

        return (_3d6Roll + normalRoll) >= 2;

    }
}