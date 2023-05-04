using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Ubicacion
{
    public class Departamento
    {

        private string nombre; //AMAZONAS
        private Pais pais;
        private string ubigeo; //01

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Pais Pais { get => pais; set => pais = value; }
        public string Ubigeo { get => ubigeo; set => ubigeo = value; }
    }
}
