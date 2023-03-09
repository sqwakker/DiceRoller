namespace DiceRoller.Roller;

class ThreeNormalChargesMakeOneRoller : NormalChargeRoller
{


    public override string Description => "Three normal 2d6 charges, make at least one";

    public override bool Success(int target)
    {
        var d1 = RollDices(target) ? 1:0;
        var d2 = RollDices(target) ? 1 : 0;
        var d3 = RollDices(target) ? 1 : 0;
        return (d1 + d2 + d3) >= 1;
    }

}