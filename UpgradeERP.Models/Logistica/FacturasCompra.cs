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
    public class FacturasCompra
    {
        private string numero;
        private DocumentoTipo documentoTipo;
        private Cliente proveedor;
        private Almacen almacen;
        private DateTime fechaCreado;
        private DateTime fecha;
        private DateTime fechaLlegada;
        private int dias;
        private Moneda moneda;
        private Impuesto impuesto;
        private double subTotal;
        private double totalFactura;
        private double descuento;
        private double pagos;
        private double saldo;
        private FormaDePago formaDePago;
        private List<FacturasCompraDetalle> facturasCompraDetalles;
        private bool ingresado;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Numero { get => numero; set => numero = value; }
        public DocumentoTipo DocumentoTipo { get => documentoTipo; set => documentoTipo = value; }
        public Cliente Proveedor { get => proveedor; set => proveedor = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
        public int Dias { get => dias; set => dias = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public Impuesto Impuesto { get => impuesto; set => impuesto = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public double TotalFactura { get => totalFactura; set => totalFactura = value; }
        public List<FacturasCompraDetalle> FacturasCompraDetalles { get => facturasCompraDetalles; set => facturasCompraDetalles = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Pagos { get => pagos; set => pagos = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public FormaDePago FormaDePago { get => formaDePago; set => formaDePago = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public bool Ingresado { get => ingresado; set => ingresado = value; }
    }
}
