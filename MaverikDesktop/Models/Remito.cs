using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaverikDesktop.Models
{
    public class Remito
    {
        public int unidad_de_distribucion_id { get; set; }
        public int id { get; set; }
        public string estado_remito { get; set; }
        public DateTime fecha_hora_entrega { get; set; }
        public DateTime tiempo_estimado_entrega { get; set; }
        public Paquetes paquetes { get; set; }
        public int ubicacion_remito_id { get; set; }
        public string ubicacion_remito_domicilio { get; set; }
        public int zona_remito_id { get; set; }
        public string zona_remito_descripcion { get; set; }
    }
}
