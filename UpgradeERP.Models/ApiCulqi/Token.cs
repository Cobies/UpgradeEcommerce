using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Token
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public long creation_date { get; set; }
        public string card_number { get; set; }
        public string last_four { get; set; }
        public bool active { get; set; }
        public Iin iin { get; set; }
        public Customer client { get; set; }
        public Metadata metadata { get; set; }



    }
}
