using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;

namespace UpgradeERP.Models.Ventas
{
    public class NotaPedidoDetalle
    {

        private bool regalo;
        private Producto producto;
        private int cantidad;
        private double precioUnitario;
        private int cantidadEntregado;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Regalo { get => regalo; set => regalo = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int CantidadEntregado { get => cantidadEntregado; set => cantidadEntregado = value; }
    }
}
