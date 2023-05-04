using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UpgradeERP.Models.ApiCulqi.Token;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Iin
    {
        public string @object { get; set; }
        public string bin { get; set; }
        public string card_brand { get; set; }
        public string card_type { get; set; }
        public string card_category { get; set; }
        public Issuer issuer { get; set; }
        public List<int?> installments_allowed { get; set; }
    }
}
