using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaverikDesktop.Models
{
    public class ColaDeCarga
    {
        public int id { get; set; }
        public string estado_remito { get; set; }
        public DateTime fecha_hora_entrega { get; set; }
        public DateTime tiempo_estimado_entrega { get; set; }
        public UbicacionRemito ubicacion_remito { get; set; }
        public ZonaRemito zona_remito { get; set; }
    }
}
