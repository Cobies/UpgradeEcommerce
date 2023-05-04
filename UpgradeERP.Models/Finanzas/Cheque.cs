using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.HelpersSelect;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;
using UpgradeERP.Models.Ventas;

namespace UpgradeERP.Models.Finanzas
{
    public class Cheque
    {

        private DateTime fechaCreado;
        private int numero;
        private DateTime fecha;
        private DateTime fechaDiferida;
        private Moneda moneda;
        private Cliente cliente;
        private Almacen almacen;
        private double total;
        private bool aprobado;
        private Empleado aprobadoPor;
        private string Tipo;
        private NotaPedidoReducido notapedido;
        private LetraClienteReducido letracliente;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public int Numero { get => numero; set => numero = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaDiferida { get => fechaDiferida; set => fechaDiferida = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public double Total { get => total; set => total = value; }
        public bool Aprobado { get => aprobado; set => aprobado = value; }
        public Empleado AprobadoPor { get => aprobadoPor; set => aprobadoPor = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public NotaPedidoReducido Notapedido { get => notapedido; set => notapedido = value; }
        public LetraClienteReducido Letracliente { get => letracliente; set => letracliente = value; }
    }
}
