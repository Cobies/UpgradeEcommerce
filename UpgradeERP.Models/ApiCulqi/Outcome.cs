using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Outcome
    {
        public string type { get; set; }
        public string[] code { get; set; }
        public string decline_code { get; set; }
        public string merchant_message { get; set; }
        public string user_message { get; set; }
    }
}
