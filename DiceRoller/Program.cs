// See https://aka.ms/new-console-template for more information

using CsvHelper.Excel;
using DiceRoller.Csv;
using DiceRoller.Roller;
using DocumentFormat.OpenXml.Office2013.Word;

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
    foreach (var target in Enumerable.Range(2, 10)) // max is 11
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


var csvRows = new List<RowDto>();

foreach (var resultDictKey in resultDict.Keys)
{
    var csvRow = new RowDto() {RollerName = resultDictKey};
    csvRow.Target2Rate = resultDict[resultDictKey][2];
    csvRow.Target3Rate = resultDict[resultDictKey][3];
    csvRow.Target4Rate = resultDict[resultDictKey][4];
    csvRow.Target5Rate = resultDict[resultDictKey][5];
    csvRow.Target6Rate = resultDict[resultDictKey][6];
    csvRow.Target7Rate = resultDict[resultDictKey][7];
    csvRow.Target8Rate = resultDict[resultDictKey][8];
    csvRow.Target9Rate = resultDict[resultDictKey][9];
    csvRow.Target10Rate = resultDict[resultDictKey][10];
    csvRow.Target11Rate = resultDict[resultDictKey][11];
    csvRows.Add(csvRow);
}

using (var writer = new ExcelWriter(@"c:\temp\result.xlsx"))
{
    writer.WriteRecords(csvRows);
}