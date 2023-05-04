using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.VisitasEmpresa
{
    public class Intervencion
    {
        private List<ProductoRevisado> producto;

        public List<ProductoRevisado> Producto { get => producto; set => producto = value; }
    }
}
