using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeERP.Models.Empleados
{
    public  class ClienteVendedorDetalle
    {
        private Acciones acciones;
        private DateTime fechaCreado;
        private string descripcion;
        private string telefono;
        private string email;
        private string contacto;
        private bool calendario;
        private DateTime fechaCalendario;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Acciones Acciones { get => acciones; set => acciones = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public bool Calendario { get => calendario; set => calendario = value; }
        public DateTime FechaCalendario { get => fechaCalendario; set => fechaCalendario = value; }
    }
}
