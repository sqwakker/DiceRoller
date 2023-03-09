namespace DiceRoller.Roller;

class HonourThePrinceRerollableChargeRoller : RerollableChargeRoller
{

    protected override bool RollDices(int target)
    {
        var a = GetDiceRoll();
        var b =6;
        return (a + b) >= target;
    }

    public override string Description => "A EC honour the prince d6+6 charge with command reroll";



}