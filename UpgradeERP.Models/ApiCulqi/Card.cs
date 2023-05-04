using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Card
    {
        public string @object { get; set; }
        public string id { get; set; }
        public bool? active { get; set; }
        public long? creation_date { get; set; }
        public string customer_id { get; set; }
        public Source source { get; set; }
        public Metadata metadata { get; set; }
    }
}
