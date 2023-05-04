using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Logistica
{
    public class GuiasRemisionDetalle
    {
        private Articulo articulo;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
    }
}
