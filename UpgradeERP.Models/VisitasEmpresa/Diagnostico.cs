using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.VisitasEmpresa
{
    public class Diagnostico
    {
        private List<ProductoRevisado> productoRevisado;
         
        public List<ProductoRevisado> ProductoRevisado { get => productoRevisado; set => productoRevisado = value; }
    }
}
