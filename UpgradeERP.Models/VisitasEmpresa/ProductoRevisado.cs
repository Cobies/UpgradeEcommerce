using MongoDB.Bson.Serialization.Attributes;
using UpgradeERP.Models.Logistica;

namespace UpgradeERP.Models.VisitasEmpresa
{
    public class ProductoRevisado
    {
        private ProductoDto producto;
        private string serie;
        private Marca marca;
        private Linea linea;
        private bool defectuoso;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public ProductoDto Producto { get => producto; set => producto = value; }
        public string Serie { get => serie; set => serie = value; }
        public Marca Marca { get => marca; set => marca = value; }
        public Linea Linea { get => linea; set => linea = value; }
        public bool Defectuoso { get => defectuoso; set => defectuoso = value; }
    }
}
