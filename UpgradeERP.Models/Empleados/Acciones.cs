using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Empleados
{
    public class Acciones
    {

        private string nombre;
        private int puntaje;
        private DateTime fechaCreado;
        private bool activo;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
