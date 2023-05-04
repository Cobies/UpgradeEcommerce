using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Sucursales
{
    public class Caja
    {

        private bool activo;
        private string nombre;
        private Sede sede;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Sede Sede { get => sede; set => sede = value; }
    }
}
