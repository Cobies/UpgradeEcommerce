using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;
using UpgradeERP.Models.Ventas;

namespace UpgradeERP.Models.Logistica
{
    public class SolicitudCompra
    {
        private DateTime fecha;
        private Producto producto;
        private NotaPedidoDetalle notaPedidoDetalle;
        private Almacen almacen;
        private int cantidad;
        private bool estado;
        private bool ordenCompra;
        private Empleado empleado;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public NotaPedidoDetalle NotaPedidoDetalle { get => notaPedidoDetalle; set => notaPedidoDetalle = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public bool OrdenCompra { get => ordenCompra; set => ordenCompra = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
