using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;

namespace UpgradeERP.Models.Ventas
{
    public class Venta
    {
        private bool activo;
        private int numero;
        private string serie;
        private DateTime fecha;
        private string enlacePdf;
        


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public int Numero { get => numero; set => numero = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string EnlacePdf { get => enlacePdf; set => enlacePdf = value; }
        public string Serie { get => serie; set => serie = value; }
    }
}
