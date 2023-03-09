using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Csv
{
    public class RowDto
    {
        public string? RollerName { get; set; }
        public string? RollerDescription { get; set; }
        public  double ChargeRange_2_Inches { get; set; }
        public double ChargeRange_3_Inches { get; set; }
        public double ChargeRange_4_Inches { get; set; }
        public double ChargeRange_5_Inches { get; set; }
        public double ChargeRange_6_Inches { get; set; }
        public double ChargeRange_7_Inches { get; set; }
        public double ChargeRange_8_Inches { get; set; }
        public double ChargeRange_9_Inches { get; set; }
        public double ChargeRange_10_Inches { get; set; }
        public double ChargeRange_11_Inches { get; set; }
    }
}
