using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Finanzas
{
    public class DepositosCliente
    {
        private bool activo;
        private CuentasBancarias cuentabancaria;
        private Cliente cliente;
        private double monto;
        private double montoUsado;
        private string observacion;
        private DateTime fechaCreado;
        private DateTime fechaAprobacion;
        private Empleado aprobadoPorEmpleado;
        private Almacen almacen;
        private string operacion;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public bool Activo { get => activo; set => activo = value; }
        public CuentasBancarias Cuentabancaria { get => cuentabancaria; set => cuentabancaria = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public double Monto { get => monto; set => monto = value; }
        public double MontoUsado { get => montoUsado; set => montoUsado = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        public DateTime FechaAprobacion { get => fechaAprobacion; set => fechaAprobacion = value; }
        public Empleado AprobadoPorEmpleado { get => aprobadoPorEmpleado; set => aprobadoPorEmpleado = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public string Operacion { get => operacion; set => operacion = value; }
    }
}
