using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Ubicacion;

namespace UpgradeERP.Models.Sucursales
{
    public class Sede
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private Distrito distrito;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public Distrito Distrito { get => distrito; set => distrito = value; }
    }
}
