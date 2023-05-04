using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Helpers
{
    public class DocumentoTipo
    {

        private string nombre;
        private string abreviatura;
        private int tipoOse;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Abreviatura { get => abreviatura; set => abreviatura = value; }
        public int TipoOse { get => tipoOse; set => tipoOse = value; }
    }
}
