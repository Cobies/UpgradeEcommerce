using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class VariableFee
    {
        string[] currency_code { get; set; }
        double? commision { get; set; }
        int? total { get; set; }
    }
}
