using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Personas
{
    public class Cliente
    {


        private string nombreUsuario;
        private string pass; //contraseña
        private DateTime fechaRegistro;
        private Persona persona;
        private int nivel;
        private Sede sede;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Pass { get => pass; set => pass = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public Sede Sede { get => sede; set => sede = value; }
        public Persona Persona { get => persona; set => persona = value; }
    }
}
