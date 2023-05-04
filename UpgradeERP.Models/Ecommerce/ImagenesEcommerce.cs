using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;

namespace UpgradeERP.Models.Ecommerce
{
    public class ImagenesEcommerce
    {
        private string principalImgUrl;
        private List<string> imagenesUrl;
        private ProductoDto producto;
        private List<DescripcionProducto> descripcionProducto;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string PrincipalImgUrl { get => principalImgUrl; set => principalImgUrl = value; }
        public List<string> ImagenesUrl { get => imagenesUrl; set => imagenesUrl = value; }
        public ProductoDto Producto { get => producto; set => producto = value; }
        public List<DescripcionProducto> DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
    }
}
