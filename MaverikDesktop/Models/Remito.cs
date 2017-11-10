using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaverikDesktop.Models
{
    class Remito
    {
        private int id;
        private string estado;
        private Pedido pedido;
        private Comercio comercio;
        private Cliente cliente;

        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }
        public Comercio Comercio { get => comercio; set => comercio = value; }
        public Cliente Cliente{ get => cliente; set => cliente = value; }
    }
}
