using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Logistica
{
    public class GuiasRemision
    {
        private int numero;
        private string serie;
        private Almacen almacenOrigen;
        private Almacen almacenDestino;
        private Cliente cliente;
        private DateTime fecha;
        private DateTime fechaTraslado;
        private string tipoTransporte;
        private string motivoTraslado;
        private Cliente transportista;
        private string vehiculo;
        private Cliente chofer;
        private bool recepcionado;
        private string observacion;
        private string urlPdf;
        private List<GuiasRemisionDetalle> guiaRemisionDetalles;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int Numero { get => numero; set => numero = value; }
        public string Serie { get => serie; set => serie = value; }
        public Almacen AlmacenOrigen { get => almacenOrigen; set => almacenOrigen = value; }
        public Almacen AlmacenDestino { get => almacenDestino; set => almacenDestino = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaTraslado { get => fechaTraslado; set => fechaTraslado = value; }
        public string MotivoTraslado { get => motivoTraslado; set => motivoTraslado = value; }
        public Cliente Transportista { get => transportista; set => transportista = value; }
        public string Vehiculo { get => vehiculo; set => vehiculo = value; }
        public Cliente Chofer { get => chofer; set => chofer = value; }
        public bool Recepcionado { get => recepcionado; set => recepcionado = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string UrlPdf { get => urlPdf; set => urlPdf = value; }
        public List<GuiasRemisionDetalle> GuiaRemisionDetalles { get => guiaRemisionDetalles; set => guiaRemisionDetalles = value; }
        public string TipoTransporte { get => tipoTransporte; set => tipoTransporte = value; }
    }
}
