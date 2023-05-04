using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class FeeDetails
    {
        public FixedFee fixed_fee { get; set; }
        public VariableFee variable_fee { get; set; }
    }
}
