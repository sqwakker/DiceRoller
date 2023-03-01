// See https://aka.ms/new-console-template for more information

using DiceRoller.Roller;

Console.WriteLine("Hello, World!");

var iterations = 1000;
var printTempl = "Roller={0},Target={1}, Rate={2}";
var rollers = new List<IRoller>();
rollers.Add(new NormalChargeRoller());
rollers.Add(new RerollableChargeRoller());

foreach (var roller in rollers)
{
    foreach (var target in Enumerable.Range(2, 11))
    {

        int i = iterations;
        var success = 0;
        while (i-- > 0)
        {
            if (roller.Roll(target))
            {
                success++;
            }
        }

        var rate = (success / 1.0) / (iterations / 1.0);

        Console.Out.WriteLine(string.Format(printTempl, roller.GetType().Name, target, rate));
    }
}