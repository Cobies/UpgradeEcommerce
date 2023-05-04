using UpgradeERP.Models.Empleados;
using UpgradeERP.Models.Personas;

namespace UpgradeERP.Models
{
    public class Semaforo
    {
        private Empleado vendedor;
        private List<ClienteVendedor> clienteVendedors;
        private int totalpuntos;

        public Empleado Vendedor { get => vendedor; set => vendedor = value; }
        public List<ClienteVendedor> ClienteVendedors { get => clienteVendedors; set => clienteVendedors = value; }
        public int Totalpuntos { get => totalpuntos; set => totalpuntos = value; }
    }
}
