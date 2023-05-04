using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Sucursales;

namespace UpgradeERP.Models.Logistica
{
    public class Articulo
    {
        private DateTime fecha;
        private string serie;
        private double volumen;
        private string observaciones;
        private Producto producto;
        private Almacen almacen;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Serie { get => serie; set => serie = value; }
        public double Volumen { get => volumen; set => volumen = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public Almacen Almacen { get => almacen; set => almacen = value; }
        public Producto Producto { get => producto; set => producto = value; }
    }
}
