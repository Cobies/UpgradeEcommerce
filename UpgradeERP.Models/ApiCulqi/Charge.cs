using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Charge
    {
        public string @object { get; set; }
        public string id { get; set; }
        public long creation_date { get; set; }
        public int? amount { get; set; }
        public int amount_refunded { get; set; }
        public int? current_amount { get; set; }
        public int installments { get; set; }
        public int? installments_amount { get; set; }
        public List<string> currency_code { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public Source source { get; set; }
        public Outcome outcome { get; set; }
        public int? fraud_score { get; set; }
        public AntifraudDetails antifraud_details { get; set; }
        public bool? dispute { get; set; }
        public bool capture { get; set; }
        public string reference_code { get; set; }
        public bool? duplicated { get; set; }
        public Metadata metadata { get; set; }
        public FeeDetails fee_details { get; set; }
        public bool? paid { get; set; }
        public string statement_descriptor { get; set; }
        public Operations operations { get; set; }
    }
}
