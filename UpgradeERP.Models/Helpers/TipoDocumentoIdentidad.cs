using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Helpers
{
    public class TipoDocumentoIdentidad
    {

        private bool activo;
        private string nombre;
        private string abreviatura;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Abreviatura { get => abreviatura; set => abreviatura = value; }
    }
}
