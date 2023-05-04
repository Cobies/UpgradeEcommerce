using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Order
    {
        public string @object { get; set; }
        public string id { get; set; }
        public int? amount { get; set; }
        public string payment_code { get; set; }
        public string currency_code { get; set; }
        public string description { get; set; }
        public string order_number { get; set; }
        public string state { get; set; }
        public int total_fee { get; set; }
        public int net_amount { get; set; }
        public FeeDetails fee_details { get; set; }
        public long? creation_date { get; set; }
        public long? expiration_date { get; set; }
        public int updated_at { get; set; }
        public int paid_at { get; set; }
        public long available_on { get; set; }
        public Metadata metadata { get; set; }
        public string qr { get; set; }
        public string cuotealo { get; set; }
        public string url_pe { get; set; }
    }
}
