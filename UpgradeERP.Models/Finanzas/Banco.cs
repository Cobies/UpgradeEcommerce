using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Finanzas
{
    public class Banco
    {
        private bool activo;
        private DateTime fechaCreado;
        private string nombre;
        private string codigoLegal;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string CodigoLegal { get => codigoLegal; set => codigoLegal = value; }
    }
}
