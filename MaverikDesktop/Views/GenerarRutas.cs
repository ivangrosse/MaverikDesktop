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

namespace MaverikDesktop.Views
{
    public partial class GenerarRutas : Form
    {
        private const string URL = "http://maverik-project.com";
        private string urlParameters = "/api/v1/rutas/generar_ruta_de_distribucion"; //

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
            HttpResponseMessage response = client.GetAsync(URL+urlParameters).Result;
            if(response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Models.Remito>>().Result;
                foreach (Models.Remito d in dataObjects)
                {                    
                    Console.WriteLine("{0}", d.Id);
                    Console.WriteLine("{0}", d.Estado);
                    Console.WriteLine("{0}", d.Pedido.Estado);
                    Console.WriteLine("{0}", d.Comercio.Razon_Social);
                    Console.WriteLine("{0}", d.Cliente.Nombre);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
