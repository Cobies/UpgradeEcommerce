using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Logistica;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.SoporteTecnico
{
    public class ReporteTecnico
    {
        private int numero;
        private Almacen almacen;
        private Cliente cliente;
        private Articulo articulo;
        private Empleado recepcion;
        private Empleado encargado;
        private Empleado entrega;
        private DateTime fechaRecepcion;
        private DateTime fechaListoEntregar/* =  new DateTime(0, 0, 0, 0, 0, 0)!*/;
        private DateTime fechaEntrega;
        private string serie;
        private string fallas;
        private string resultado;
        private string tipodemantenimiento;
        private string objetosDejados;
        private List<ServiciosTecnicos> servicios;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int Numero { get => numero; set => numero = value; }
        public string Serie { get => serie; set => serie = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
        public Empleado Recepcion { get => recepcion; set => recepcion = value; }
        public DateTime FechaRecepcion { get => fechaRecepcion; set => fechaRecepcion = value; }
        public string Fallas { get => fallas; set => fallas = value; }
        public string ObjetosDejados { get => objetosDejados; set => objetosDejados = value; }
        public string Tipodemantenimiento { get => tipodemantenimiento; set => tipodemantenimiento = value; }
        public Empleado Encargado { get => encargado; set => encargado = value; }
        public DateTime FechaListoEntregar { get => fechaListoEntregar; set => fechaListoEntregar = value; }
        public string Resultado { get => resultado; set => resultado = value; }
        public List<ServiciosTecnicos> Servicios { get => servicios; set => servicios = value; }
        public Empleado Entrega { get => entrega; set => entrega = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }



    }
}