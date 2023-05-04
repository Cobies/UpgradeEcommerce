using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Finanzas
{
    public class Caja
    {
        private bool activo;
        private Almacen almacen;
        private string nombre;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
