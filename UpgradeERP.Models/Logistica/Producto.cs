using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeERP.Models.Helpers;

namespace UpgradeERP.Models.Logistica
{
    public class Producto
    {

        private string codigo;
        private string nombre;
        private string descripcion;
        private bool regalo;
        private bool servicio;
        private string productoTipo;
        private Unidad unidad;
        private Marca marca;
        private Linea linea;
        private double peso;
        private int garantia;
        private string codigoSunat;
        private double precio;
        private Moneda moneda;
        private Impuesto impuesto;
        private string urlimagen;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Regalo { get => regalo; set => regalo = value; }
        public string ProductoTipo { get => productoTipo; set => productoTipo = value; }
        public Marca Marca { get => marca; set => marca = value; }
        public string CodigoSunat { get => codigoSunat; set => codigoSunat = value; }
        public double Precio { get => precio; set => precio = value; }
        public Moneda Moneda { get => moneda; set => moneda = value; }
        public Impuesto Impuesto { get => impuesto; set => impuesto = value; }
        public Linea Linea { get => linea; set => linea = value; }
        public double Peso { get => peso; set => peso = value; }
        public int Garantia { get => garantia; set => garantia = value; }
        public bool Servicio { get => servicio; set => servicio = value; }
        public Unidad Unidad { get => unidad; set => unidad = value; }
        public string Urlimagen { get => urlimagen; set => urlimagen = value; }
    }

    public class ProductoDto
    {
        private string codigo;
        private string nombre;

        [BsonElement("id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
