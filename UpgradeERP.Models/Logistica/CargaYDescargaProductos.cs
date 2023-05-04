using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Sucursales;
using UpgradeERP.Models.Ventas;

namespace UpgradeERP.Models.Logistica
{
    public class CargaYDescargaProductos
    {
        private int numero;
        private Almacen almacen;
        private NotaPedido notapedido;
        private FacturasCompra facturaCompra;
        private DateTime fecha;
        private string observacion;
        private string tipo;
        private List<CargaYDescargaProductosDetalle> cargaYDescargaProductosDetalles;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int Numero { get => numero; set => numero = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public NotaPedido Notapedido { get => notapedido; set => notapedido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public List<CargaYDescargaProductosDetalle> CargaYDescargaProductosDetalles { get => cargaYDescargaProductosDetalles; set => cargaYDescargaProductosDetalles = value; }
        public FacturasCompra FacturaCompra { get => facturaCompra; set => facturaCompra = value; }
    }
}
