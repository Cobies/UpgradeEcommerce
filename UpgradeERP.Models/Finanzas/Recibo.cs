using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.HelpersSelect;
using UpgradeERP.Models.Ventas;

namespace UpgradeERP.Models.Finanzas
{
    public class Recibo
    {

        private bool activo;
        private Caja caja;
        private int numero;
        private DateTime fecha;
        private Moneda moneda;
        private double monto;
        private double montoEntrada;
        private double montoSalida;
        private TipoDeRecibo tipoDeRecibo;
        private string observaciones;
        private NotaPedidoReducido notapedido;
        private Caja cajaDestino;
        private DepositosCliente depositoCliente;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public Caja Caja { get => caja; set => caja = value; }
        public int Numero { get => numero; set => numero = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public double Monto { get => monto; set => monto = value; }
        public double MontoEntrada { get => montoEntrada; set => montoEntrada = value; }
        public double MontoSalida { get => montoSalida; set => montoSalida = value; }
        public TipoDeRecibo TipoDeRecibo { get => tipoDeRecibo; set => tipoDeRecibo = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public NotaPedidoReducido Notapedido { get => notapedido; set => notapedido = value; }
        public Caja CajaDestino { get => cajaDestino; set => cajaDestino = value; }
        public DepositosCliente DepositoCliente { get => depositoCliente; set => depositoCliente = value; }
    }
}
