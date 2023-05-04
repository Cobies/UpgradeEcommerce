using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;

namespace UpgradeERP.Models.Finanzas
{
    public class CuentasBancarias
    {

        private bool activo;
        private DateTime fechaCreado;
        private Moneda moneda;
        private string nombre;
        private string codigo;
        private string numero;
        private Banco banco;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Numero { get => numero; set => numero = value; }
        public Banco Banco { get => banco; set => banco = value; }
    }
}
