using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class AntifraudDetails
    {
        public string address { get; set; }
        public string address_city { get; set; }
        [Range(0,2)]
        public string country_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
    }
}
