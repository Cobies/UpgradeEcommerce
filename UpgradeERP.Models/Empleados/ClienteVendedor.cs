using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Personas;

namespace UpgradeERP.Models.Empleados
{
    public class ClienteVendedor
    {
        private Cliente cliente;
        private Empleado vendedor;
        private List<ClienteVendedorDetalle> clienteVendedorDetalles;
        private bool activo;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Empleado Vendedor { get => vendedor; set => vendedor = value; }
        public List<ClienteVendedorDetalle> ClienteVendedorDetalles { get => clienteVendedorDetalles; set => clienteVendedorDetalles = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
