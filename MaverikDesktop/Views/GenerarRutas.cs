using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaverikDesktop.Views
{
    public partial class GenerarRutas : Form
    {
        private const string URL = "http://maverik-project.com";
        private string urlParameters = "/api/v1/rutas/generar_cola_de_carga"; 

        public GenerarRutas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //This code lists the RESTful service response//
            var response = client.GetAsync(urlParameters).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                Models.RootObject dataObject = JsonConvert.DeserializeObject<Models.RootObject>(jsonString.Result);
                foreach (Models.ColaDeCarga d in dataObject.cola_de_carga)
                {                    
                    Console.WriteLine("{0}", d.id);
                    Console.WriteLine("{0}", d.estado_remito);
                    Console.WriteLine("{0}", d.fecha_hora_entrega);
                    Console.WriteLine("{0}", d.tiempo_estimado_entrega);
                    Console.WriteLine("{0}", d.ubicacion_remito.id);
                    Console.WriteLine("{0}", d.ubicacion_remito.domicilio);
                    Console.WriteLine("{0}", d.zona_remito.id);
                    Console.WriteLine("{0}", d.zona_remito.descripcion);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
