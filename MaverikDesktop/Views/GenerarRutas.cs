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
                foreach(Models.ColaDeCarga cdc in dataObject.cola_de_carga)
                {
                    foreach(Models.Remito r in cdc.remitos)
                    {
                        //foreach(Models.Remito r in cdc.remito)
                        {
                            Console.WriteLine(r.id.ToString());
                            Console.WriteLine(r.cantidad_paquetes);
                        }
                        
                    }
                }
                ColaDeCarga colaDeCarga = new ColaDeCarga(dataObject);
                colaDeCarga.Show();
                this.Hide();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
