using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Refund
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string charge_id { get; set; }
        public long creation_date { get; set; }
        public int amount { get; set; }
        public string[] reason { get; set; }
        public Metadata metadata { get; set; }
        public string status { get; set; }
        public long last_modified { get; set; }
    }
}
