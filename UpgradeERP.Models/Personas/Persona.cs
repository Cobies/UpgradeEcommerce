using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Ubicacion;

namespace UpgradeERP.Models.Personas
{
    public class Persona
    {
        private string nombre;
        private string documentoIdentidad;
        private TipoDocumentoIdentidad tipoDocumentoIdentidad;
        private string brevette;
        private string telefono;
        private string email;
        private string direccion;
        private string ubigeo;
        private string genero;
        private string edad;
        private Distrito distrito;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string DocumentoIdentidad { get => documentoIdentidad; set => documentoIdentidad = value; }
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get => tipoDocumentoIdentidad; set => tipoDocumentoIdentidad = value; }
        public string Brevette { get => brevette; set => brevette = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ubigeo { get => ubigeo; set => ubigeo = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Edad { get => edad; set => edad = value; }
        public Distrito Distrito { get => distrito; set => distrito = value; }
    }
}
