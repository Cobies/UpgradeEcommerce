using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Logistica
{
    public class CargaYDescargaProductosDetalle
    {
        private Articulo articulo;
        private int cantidad;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
 