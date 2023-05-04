using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Logistica
{
    public class OrdenCompra
    {
        private Cliente proveedor;
        private Almacen almacen;
        private int numero;
        private FormaDePago formaDePago;
        private DateTime fecha;
        private DateTime fechaEntrega;
        private Moneda moneda;
        private Impuesto impuesto;
        private double descuento;
        private List<OrdenCompraDetalle> ordencompradetalle;
        private DateTime fechaCreado;
        private double total;
        private double subtotal;
        private bool aprobado;
        private int dias;
        private string numeroFactura;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Cliente Proveedor { get => proveedor; set => proveedor = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public int Numero { get => numero; set => numero = value; }
        public FormaDePago FormaDePago { get => formaDePago; set => formaDePago = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public Impuesto Impuesto { get => impuesto; set => impuesto = value; }
        public List<OrdenCompraDetalle> Ordencompradetalle { get => ordencompradetalle; set => ordencompradetalle = value; }
        public bool Aprobado { get => aprobado; set => aprobado = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public int Dias { get => dias; set => dias = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public string NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public double Total { get => total; set => total = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
