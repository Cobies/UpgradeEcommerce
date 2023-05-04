using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.ApiCulqi
{
    public class Authentication3DS
    {
        public string xid { get; set; }
        public string cavv { get; set; }
        public string directoryServerTransactionId { get; set; }
        public string eci { get; set; }
        public string protocolVersion { get; set; }
    }
}
