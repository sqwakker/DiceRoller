// See https://aka.ms/new-console-template for more information

using DiceRoller.Roller;

Console.WriteLine("Hello, World!");

var iterations = 100000;
var printTempl = "Roller={0},Target={1}, Rate={2}";
var rollers = new List<IRoller>();
rollers.Add(new NormalChargeRoller());
rollers.Add(new RerollableChargeRoller());
rollers.Add(new RerollOneDiceChargeRoller());
rollers.Add(new ThreeD6PickHighestChargeRoller());
rollers.Add(new ThreeD6PickHighestRerollableChargeRoller());

var resultDict = new Dictionary<string, Dictionary<int,double>>();

foreach (var roller in rollers)
{
    resultDict[roller.GetType().Name] = new Dictionary<int, double>();
    foreach (var target in Enumerable.Range(2, 11))
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
        resultDict[roller.GetType().Name][target] = rate;
        Console.Out.WriteLine(string.Format(printTempl, roller.GetType().Name, target, rate));

        
    }
}