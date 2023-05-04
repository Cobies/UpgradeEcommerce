using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

namespace UpgradeERP.Models.ApiCulqi.Post
{
    public class PostCharge
    {
        [Required]
        public int amount { get; set; }
        [Required]
        public string currency_code { get; set; }
        [Required]
        public string email { get; set;}
        [Required]
        public string source_id { get; set;}
        public bool capture { get; set;}
        [Range(5,50)]
        public string description { get; set;}
        [Range(2, 48)]
        public string installments { get; set;}
        public Metadata metadata { get; set;}
        public AntifraudDetails antifraud_details { get; set;}
        public Authentication3DS authentication_3DS { get; set;}

    }
}
