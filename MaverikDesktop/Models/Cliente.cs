using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaverikDesktop.Models
{
    class Cliente
    {
        private string nombre;
        private string cuit_cuil;
        private string telefono;

       
        public string Cuit_Cuil { get => cuit_cuil; set => cuit_cuil=value; }
        public string Telefono { get => telefono; set => telefono=value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
