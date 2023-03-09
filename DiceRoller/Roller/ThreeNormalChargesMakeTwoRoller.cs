namespace DiceRoller.Roller;

class ThreeNormalChargesMakeTwoRoller : NormalChargeRoller
{

    public override string Description => "Three normal 2d6 charges, make at least two";

    public override bool Success(int target)
    {
        var d1 = RollDices(target) ? 1:0;
        var d2 = RollDices(target) ? 1 : 0;
        var d3 = RollDices(target) ? 1 : 0;
        return (d1 + d2 + d3) >= 2;
    }

}