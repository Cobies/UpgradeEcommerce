using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Customer
    {
        public string ip { get; set; }
        public string ip_country { get; set; }
        public string ip_country_code { get; set; }
        public string browser { get; set; }
        public string device_fingerprint { get; set; }
        public string device_type { get; set; }
    }
}
