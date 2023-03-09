using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Excel;
using DiceRoller.Roller;

namespace DiceRoller.Csv
{
    internal class WriteExcel
    {
        internal  static void WriteRowsToFile(string fileName, Dictionary<IRoller, Dictionary<int, double>> resultDict)
        {



            var csvRows = new List<RowDto>();

            foreach (var resultDictKey in resultDict.Keys)
            {
                var csvRow = new RowDto
                {
                    RollerName = resultDictKey.Name,
                    RollerDescription = resultDictKey.Description,
                    C_2_Inches = FormatRate(resultDict[resultDictKey][2]),
                    C_3_Inches = FormatRate(resultDict[resultDictKey][3]),
                    C_4_Inches = FormatRate(resultDict[resultDictKey][4]),
                    C_5_Inches = FormatRate(resultDict[resultDictKey][5]),
                    C_6_Inches = FormatRate(resultDict[resultDictKey][6]),
                    C_7_Inches = FormatRate(resultDict[resultDictKey][7]),
                    C_8_Inches = FormatRate(resultDict[resultDictKey][8]),
                    C_9_Inches = FormatRate(resultDict[resultDictKey][9]),
                    C_10_Inches = FormatRate(resultDict[resultDictKey][10]),
                    C_11_Inches = FormatRate(resultDict[resultDictKey][11])
                };
                csvRows.Add(csvRow);
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using var writer = new ExcelWriter(fileName);
            writer.WriteRecords(csvRows);

            

        }
        static string FormatRate(double rate)
        {
            return $"{(rate*100.0):N2}%";
        }

    }
}
