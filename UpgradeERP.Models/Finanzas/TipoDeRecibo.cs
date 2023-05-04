using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Finanzas
{
    public class TipoDeRecibo
    {

        private DateTime fecha;
        private string nombre;
        private bool ingreso;
        private bool predefinido;
        private bool caja;
        private bool banco;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Ingreso { get => ingreso; set => ingreso = value; }
        public bool Predefinido { get => predefinido; set => predefinido = value; }
        public bool Caja { get => caja; set => caja = value; }
        public bool Banco { get => banco; set => banco = value; }
    }
}
