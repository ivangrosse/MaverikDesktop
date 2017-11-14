using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaverikDesktop.Views
{
    public partial class ColaDeCarga : Form
    {
        private Models.ColaDeCarga colaDeCarga1 = new Models.ColaDeCarga();
        public Models.ColaDeCarga ColaDeCarga1 { get => colaDeCarga1; set => colaDeCarga1 = value; }

        public ColaDeCarga(Models.ColaDeCarga value)
        {
            InitializeComponent();
            ColaDeCarga1 = value;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string identificador = Regex.Match(sender.ToString(), @"\d+").Value;
            //foreach (Models.ColaDeCarga cdc in colaDeCarga1.cola_de_carga)
            {
                foreach(Models.Remito r in colaDeCarga1.remitos)
                {
                    {
                        //for (int i = 0; i < r.cantidad_paquetes; i++)
                        {
                            if (r.id == Int32.Parse(identificador))
                            {
                                    detalleRemito.Text = "Detalle de Remito: " + r.id.ToString() +
                                    "\n" + "Estado: " + r.estado_remito +
                                    "\n" + "Ubicacion: " + r.ubicacion_remito_domicilio +
                                    "\n" + "Zona: " + r.zona_remito_descripcion;                                    
                            }
                        }
                    }
                }                
            }
        }

        private void ColaDeCarga_Load(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();            
            //foreach (Models.ColaDeCarga cdc in colaDeCarga1.cola_de_carga)
            {
                int contador = 0;
                int x = 50; int y = 50;
                foreach (Models.Remito r in colaDeCarga1.remitos)
                {
                    
                   
                    //foreach (Models.Remito r in cdc.remito)
                    {                        
                        for(int i = 0; i< r.cantidad_paquetes; i++)
                        {
                            contador++;
                            Button newButton = new Button();
                            newButton.Text = r.id.ToString();
                            newButton.Font = new Font(newButton.Font.FontFamily, 15);
                            newButton.Location = new Point(x, y);
                            newButton.Name = "paquete" + r.id.ToString();
                            newButton.Click += Button_Click;
                            newButton.Size = new Size(60, 30);
                            buttons.Add(newButton);
                            this.Controls.Add(newButton);
                            if (contador < 18)
                            {
                                x = x + 60;
                            }
                            else
                            {
                                y = y + 40;
                                x = 50;
                                contador = 0;
                            }
                            //contador++;
                        }                        
                    }
                }                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Cola de Carga";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            int x = -200; int y = -400;
            int aux = 0;
           // foreach(Models.ColaDeCarga cdc in ColaDeCarga1.cola_de_carga)
            {
                foreach(Models.Remito r in colaDeCarga1.remitos)
                {
                    for(int i=0; i<r.cantidad_paquetes; i++)
                    {
                        int idPaquete = i+1;
                        aux = aux + 1;
                        graph.DrawString("Paquete: " + idPaquete + " Remito: "+ r.id.ToString(), font, XBrushes.Black, new XRect(x, y, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
                        //agregar aquello que se necesite en el pdf//
                        y = y + 25;
                        if (aux == 20)
                        {
                            x = x + 200;
                            aux = 0;
                            y = -400;
                        }
                    }
                }
            }            
            string pdfFilename = "ColaDeCarga.pdf";
            pdf.Save(pdfFilename);
            System.Diagnostics.Process.Start(pdfFilename);
        }
    }
}
