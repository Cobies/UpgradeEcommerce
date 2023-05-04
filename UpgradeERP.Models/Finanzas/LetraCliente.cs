using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Finanzas
{
    public class LetraCliente
    {

        private DateTime FechaCreado;
        private DateTime fechaVencimiento;
        private DateTime fechaCobro;
        private double capital;
        private int numero;
        private double totalCobrar;
        private double totalCobrado;
        private double capitalInicial;
        private double aCobrar;
        private double interes;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime FechaCreado1 { get => FechaCreado; set => FechaCreado = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public DateTime FechaCobro { get => fechaCobro; set => fechaCobro = value; }
        public double Capital { get => capital; set => capital = value; }
        public int Numero { get => numero; set => numero = value; }
        public double TotalCobrar { get => totalCobrar; set => totalCobrar = value; }
        public double TotalCobrado { get => totalCobrado; set => totalCobrado = value; }
        public double CapitalInicial { get => capitalInicial; set => capitalInicial = value; }
        public double ACobrar { get => aCobrar; set => aCobrar = value; }
        public double Interes { get => interes; set => interes = value; }
    }
}
