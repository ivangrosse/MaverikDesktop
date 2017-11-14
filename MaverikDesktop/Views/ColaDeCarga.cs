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
            Button boton = (Button)sender;
            string identificador = Regex.Match(boton.Name, @"\d+").Value;
            
            
            
                foreach(Models.Remito r in colaDeCarga1.remitos)
                {
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

        private void ColaDeCarga_Load(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();            
            
            
                int contador = 0;
                int x = 50; int y = 50;
                
                foreach (Models.Remito r in colaDeCarga1.remitos)
                {

                    int contadorSeccoCola = 0;
                    int contadorSeccoLimon = 0;
                    int contadorSeccoPomelo = 0;
                    int contadorSeccoTradicional = 0;                    
                    {                        
                        for(int i = 0; i< r.paquetes.cantidad_paquetes_total; i++)
                        {
                            contador++;
                            
                            Button newButton = new Button();
                            if (contadorSeccoCola < r.paquetes.cantidad_cola)
                            {
                                newButton.Text = "SC";
                                contadorSeccoCola++;
                            }
                            else
                            {
                                if (contadorSeccoLimon < r.paquetes.cantidad_limon)
                                {
                                    newButton.Text = "SL";
                                    contadorSeccoLimon++;
                                }
                                else
                                {
                                    if(contadorSeccoPomelo < r.paquetes.cantidad_pomelo)
                                    {
                                        newButton.Text = "SP";
                                        contadorSeccoPomelo++;
                                    }
                                    else
                                    {
                                        if(contadorSeccoTradicional < r.paquetes.cantidad_pomelo)
                                        {
                                            newButton.Text = "ST";
                                            contadorSeccoTradicional++;
                                        }
                                    }
                                }
                            }                            
                            newButton.Font = new Font(newButton.Font.FontFamily, 15);
                            newButton.Location = new Point(x, y);
                            newButton.Name = r.id.ToString();
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
            int unidad = 0;
            foreach(Models.Remito r in colaDeCarga1.remitos)
            {
                unidad = r.unidad_de_distribucion_id;                
            }
            graph.DrawString("Cola de Carga" , new XFont("Verdana", 18, XFontStyle.Bold),
                XBrushes.Black, new XRect(0, -400, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.Center);
            graph.DrawString("Unidad de Distribucion "+unidad, new XFont("Verdana", 10, XFontStyle.Bold),
                XBrushes.Black, new XRect(0, -350, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.Center);
            int x = -200; int y = -200;
            int aux = 0;           
            {
                foreach(Models.Remito r in colaDeCarga1.remitos)
                {
                    int contadorSeccoCola = 0;
                    int contadorSeccoLimon = 0;
                    int contadorSeccoPomelo = 0;
                    int contadorSeccoTradicional = 0;
                    for (int i=0; i<r.paquetes.cantidad_paquetes_total; i++)
                    {
                        int idPaquete = i+1;
                        aux = aux + 1;
                        if (contadorSeccoCola < r.paquetes.cantidad_cola)
                        {
                            graph.DrawString("Paquete: " + idPaquete + " SC " + " Remito: " 
                                + r.id.ToString(), font, XBrushes.Black, 
                                new XRect(x, y, pdfPage.Width.Point, pdfPage.Height.Point), 
                                XStringFormats.Center);
                            contadorSeccoCola++;
                        }
                        else
                        {
                            if (contadorSeccoLimon < r.paquetes.cantidad_limon)
                            {
                                graph.DrawString("Paquete: " + idPaquete + " SL "+" Remito: " 
                                    + r.id.ToString(), font, XBrushes.Black,
                                    new XRect(x, y, pdfPage.Width.Point, pdfPage.Height.Point),
                                    XStringFormats.Center);
                                contadorSeccoLimon++;
                            }
                            else
                            {
                                if (contadorSeccoPomelo < r.paquetes.cantidad_pomelo)
                                {
                                    graph.DrawString("Paquete: " + idPaquete + " SP "+" Remito: "
                                        + r.id.ToString(), font, XBrushes.Black,
                                        new XRect(x, y, pdfPage.Width.Point, pdfPage.Height.Point),
                                        XStringFormats.Center);
                                    contadorSeccoPomelo++;
                                }
                                else
                                {
                                    if (contadorSeccoTradicional < r.paquetes.cantidad_pomelo)
                                    {
                                        graph.DrawString("Paquete: " + idPaquete + " ST "+" Remito: "
                                            + r.id.ToString(), font, XBrushes.Black,
                                            new XRect(x, y, pdfPage.Width.Point, pdfPage.Height.Point),
                                            XStringFormats.Center);
                                        contadorSeccoTradicional++;
                                    }
                                }
                            }
                        }                   
                        y = y + 25;
                        if (aux == 20)
                        {
                            x = x + 200;
                            aux = 0;
                            y = -200;
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
