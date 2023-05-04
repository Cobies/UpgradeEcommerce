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
    public class Empleado
    {
        private bool activo;
        private string nombreUsuario;
        private string password;
        private DateTime fechaRegistro;
        private RolDeUsuario rolDeUsuario;
        private int nivel;
        private Almacen almacen;
        private string emailCorporativo;
        private Persona persona;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Pass { get => password; set => password = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public RolDeUsuario RolDeUsuario { get => rolDeUsuario; set => rolDeUsuario = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public string EmailCorporativo { get => emailCorporativo; set => emailCorporativo = value; }
        public Persona Persona { get => persona; set => persona = value; }
    }

}
