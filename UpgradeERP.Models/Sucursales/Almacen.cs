using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Sucursales
{
    public class Almacen
    {
        private Sede sede;
        private string nombre;
        private string telefono;
        private string abreviatura;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Sede Sede { get => sede; set => sede = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Abreviatura { get => abreviatura; set => abreviatura = value; }

    }
}
