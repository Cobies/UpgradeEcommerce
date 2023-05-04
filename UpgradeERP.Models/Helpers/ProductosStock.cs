using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;

namespace UpgradeERP.Models.Helpers
{
    public class ProductosStock
    {
        private Producto producto;
        private List<Articulo> articulos;
        private long cantidad;
        public Producto Producto { get => producto; set => producto = value; }
        public List<Articulo> Articulos { get => articulos; set => articulos = value; }
        public long Cantidad { get => cantidad; set => cantidad = value; }
    }
}
