using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;

namespace UpgradeERP.Models.Ecommerce
{
    public class ProductoEcommerce
    {
        private bool activo;
        private Producto producto;
        private double precio;
        private bool oferta;
        private double precioOferta;
        private ImagenesEcommerce imagenesEcommerce;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public double Precio { get => precio; set => precio = value; }
        public bool Oferta { get => oferta; set => oferta = value; }
        public double PrecioOferta { get => precioOferta; set => precioOferta = value; }
        public ImagenesEcommerce ImagenesEcommerce { get => imagenesEcommerce; set => imagenesEcommerce = value; }
    }
}
