// See https://aka.ms/new-console-template for more information

using CsvHelper.Excel;
using DiceRoller.Csv;
using DiceRoller.Roller;
using DocumentFormat.OpenXml.Office2013.Word;

Console.WriteLine("Hello, World!");

var fileName = @"c:\temp\successful_charges.xlsx";

var iterations = 1000000;
var printTempl = "Roller={0},Target={1}, Rate={2}";
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
        resultDict[roller][target] = rate;
        Console.Out.WriteLine(string.Format(printTempl, roller.GetType().Name, target, rate));
    }
}


var csvRows = new List<RowDto>();

foreach (var resultDictKey in resultDict.Keys)
{
    var csvRow = new RowDto
    {
        RollerName = resultDictKey.Name,
        RollerDescription = resultDictKey.Description,
        C_2_Inches = resultDict[resultDictKey][2],
        C_3_Inches = resultDict[resultDictKey][3],
        C_4_Inches = resultDict[resultDictKey][4],
        C_5_Inches = resultDict[resultDictKey][5],
        C_6_Inches = resultDict[resultDictKey][6],
        C_7_Inches = resultDict[resultDictKey][7],
        C_8_Inches = resultDict[resultDictKey][8],
        C_9_Inches = resultDict[resultDictKey][9],
        C_10_Inches = resultDict[resultDictKey][10],
        C_11_Inches = resultDict[resultDictKey][11]
    };
    csvRows.Add(csvRow);
}

if (File.Exists(fileName))
{
    File.Delete(fileName);
}

using (var writer = new ExcelWriter(fileName))
{
    writer.WriteRecords(csvRows);
}