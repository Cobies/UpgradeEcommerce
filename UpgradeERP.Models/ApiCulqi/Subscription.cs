using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Subscription
    {
        public string @object { get; set; }
        public string id { get; set; }
        public long? creation_date { get; set; }
        public string status { get; set; }
        public int? current_period { get; set; }
        public int? total_period { get; set; }
        public long? current_period_start { get; set; }
        public long? current_period_end { get; set; }
        public bool? cancel_at_period_end { get; set; }
        public object cancel_at { get; set; }
        public long? ended_at { get; set; }
        public long? next_billing_date { get; set; }
        public long? trial_start { get; set; }
        public long? trial_end { get; set; }
        public List<Charge> charges { get; set; }
        public Plan plan { get; set; }
        public Card card { get; set; }
        public Metadata metadata { get; set; }
    }
}
