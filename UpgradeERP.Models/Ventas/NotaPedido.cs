using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Ventas
{
    public class NotaPedido
    {
        private DateTime fecha;
        private Empleado vendedor;
        private Cliente cliente;
        private Moneda moneda;
        private Venta venta;
        private Impuesto impuesto;
        private FormaDePago formaDePago;
        private int numero;
        private List<NotaPedidoDetalle> notaPedidoDetalle;
        private Almacen almacen;
        private string observacion;
        private bool aprobado;
        private string aprobadoCredito;
        private DateTime fechaEntrega;
        private double montoCobrar;
        private double montoCobrado;
        private double totalMinimo;
        private double subtotal;
        private double total;
        private double utilidad;
        private bool descargado;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Empleado Vendedor { get => vendedor; set => vendedor = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public Venta Venta { get => venta; set => venta = value; }
        public Impuesto Impuesto { get => impuesto; set => impuesto = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Aprobado { get => aprobado; set => aprobado = value; }
        public string AprobadoCredito { get => aprobadoCredito; set => aprobadoCredito = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public double MontoCobrar { get => montoCobrar; set => montoCobrar = value; }
        public double MontoCobrado { get => montoCobrado; set => montoCobrado = value; }
        public double TotalMinimo { get => totalMinimo; set => totalMinimo = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Total { get => total; set => total = value; }
        public List<NotaPedidoDetalle> NotaPedidoDetalle { get => notaPedidoDetalle; set => notaPedidoDetalle = value; }
        public FormaDePago FormaDePago { get => formaDePago; set => formaDePago = value; }
        public double Utilidad { get => utilidad; set => utilidad = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public bool Descargado { get => descargado; set => descargado = value; }

    }
}
