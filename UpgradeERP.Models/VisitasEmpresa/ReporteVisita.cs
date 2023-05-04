using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Personas;

namespace UpgradeERP.Models.VisitasEmpresa
{
    public class ReporteVisita
    {
        private int numero;
        private Cliente cliente;
        private Diagnostico diagnostico;
        private Intervencion intervencion;
        private Sugerencias sugerencias;


        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int Numero { get => numero; set => numero = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Diagnostico Diagnostico { get => diagnostico; set => diagnostico = value; }
        public Intervencion Intervencion { get => intervencion; set => intervencion = value; }
        public Sugerencias Sugerencias { get => sugerencias; set => sugerencias = value; }
    }
}
