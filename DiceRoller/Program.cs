// See https://aka.ms/new-console-template for more information

using DiceRoller.Csv;
using DiceRoller.Roller;

Console.WriteLine("Running monte-carlo");

var fileName = @"c:\temp\successful_charges.xlsx";
var iterations = 1000000;
var printTempl = "Roller={0},Target={1}, Rate={2}";
var maxTarget = 11;

var rollers = new List<IRoller>
{
    new NormalChargeRoller(),
    new RerollableChargeRoller(),
    new RerollOneDiceChargeRoller(),
    new ThreeD6PickHighestChargeRoller(),
    new ThreeD6PickHighestRerollableChargeRoller(),
    new ThreeNormalChargesMakeOneRoller(),
    new ThreeNormalChargesMakeTwoRoller(),
    new OneNormalOneThreeD6PickHighestMakeOneChargeRoller(),
    new OneNormalOneThreeD6PickHighestMakeTwoChargeRoller(),
    new TwoNormalOneThreeD6PickHighestMakeOneChargeRoller(),
    new TwoNormalOneThreeD6PickHighestMakeTwoChargeRoller(),
    new HonourThePrinceChargeRoller(), 
    new HonourThePrinceRerollableChargeRoller(),
    new RammingSpeedMegaDreadChargeRoller()
};

var resultDict = new Dictionary<IRoller, Dictionary<int,double>>();

foreach (var roller in rollers)
{
    resultDict[roller] = new Dictionary<int, double>();
    foreach (var target in Enumerable.Range(2, maxTarget-1)) // 2, ..., 11
    {
        int i = iterations;
        var success = 0;
        while (i-- > 0)
        {
            if (roller.Success(target))
            {
                success++;
            }
        }
        var rate = (success / 1.0) / (iterations / 1.0); //force double
        resultDict[roller][target] = rate;
        Console.Out.WriteLine(printTempl, roller.Name, target, rate);
    }

    WriteExcel.WriteRowsToFile(fileName,resultDict);
}

