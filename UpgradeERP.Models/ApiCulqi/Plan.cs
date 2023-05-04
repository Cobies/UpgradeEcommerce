using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Plan
    {
        public string @object { get; set; }
        public string id { get; set; }
        public long? creation_date { get; set; }
        public string name { get; set; }
        public int? amount { get; set; }
        public string currency_code { get; set; }
        public int? interval_count { get; set; }
        public string interval { get; set; }
        public int? limit { get; set; }
        public int? trial_days { get; set; }
        public int? total_subscriptions { get; set; }
        public Metadata metadata { get; set; }
    }
}
