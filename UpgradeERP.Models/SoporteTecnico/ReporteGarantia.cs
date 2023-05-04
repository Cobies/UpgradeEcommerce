using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.SoporteTecnico
{
    public class ReporteGarantia
    {
        private Cliente cliente;
        private Articulo articulo;
        private Empleado encargado;
        private DateTime fechaRecepcion;
        private DateTime fechaEnvio;
        private DateTime fechaRetorno;
        private DateTime fechaEntrega;
        private Almacen almacen;
        private string descripcion;
        private string objetosDejados;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Empleado Encargado { get => encargado; set => encargado = value; }
        public DateTime FechaRecepcion { get => fechaRecepcion; set => fechaRecepcion = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public string ObjetosDejados { get => objetosDejados; set => objetosDejados = value; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
        public DateTime FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public DateTime FechaRetorno { get => fechaRetorno; set => fechaRetorno = value; }
    }
}