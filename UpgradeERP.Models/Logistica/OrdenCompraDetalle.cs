using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Logistica
{
    public class OrdenCompraDetalle
    {
        private Producto producto;
        private double cantidad;
        private double precioUnitario;
        private int facturar;
        private int facturando;
        private bool facturado;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Producto Producto { get => producto; set => producto = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Facturar { get => facturar; set => facturar = value; }
        public int Facturando { get => facturando; set => facturando = value; }
        public bool Facturado { get => facturado; set => facturado = value; }
    }
}
