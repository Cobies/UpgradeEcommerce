using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Ubicacion
{
    public class Provincia
    {
        private string nombre;
        private Departamento departamento;
        private string ubigeo;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Departamento Departamento { get => departamento; set => departamento = value; }
        public string Ubigeo { get => ubigeo; set => ubigeo = value; }
    }
}
