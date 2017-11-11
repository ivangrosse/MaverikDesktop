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
        private Models.RootObject colaDeCarga1;
        public Models.RootObject ColaDeCarga1 { get => colaDeCarga1; set => colaDeCarga1 = value; }

        public ColaDeCarga(Models.RootObject value)
        {
            InitializeComponent();
            ColaDeCarga1 = value;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string identificador = Regex.Match(sender.ToString(), @"\d+").Value;
            foreach (Models.ColaDeCarga d in colaDeCarga1.cola_de_carga)
            {
                if (d.id == Int32.Parse(identificador))
                {
                    detalleRemito.Text = "Detalle de remito: " + d.id.ToString() +
                        "\n" + "Estado: " + d.estado_remito +
                        "\n" + "Ubicacion: " + d.ubicacion_remito.domicilio +
                        "\n" + "Zona: " + d.zona_remito.descripcion;
                }
            }
        }

        private void ColaDeCarga_Load(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();
            int x = 50; int y = 50; int contador=0;
            foreach (Models.ColaDeCarga d in colaDeCarga1.cola_de_carga)
            {

                Button newButton = new Button();
                newButton.Text = d.id.ToString();
                newButton.Font = new Font(newButton.Font.FontFamily, 15);
                newButton.Location = new Point(x, y);
                newButton.Name = "paquete" + d.id.ToString();
                newButton.Click += Button_Click;
                newButton.Size = new Size(60, 60);
                buttons.Add(newButton);
                this.Controls.Add(newButton);
                if (contador<5)
                {
                    x = x + 60;
                }
                else
                {
                    y = y + 60;
                    x = 50;
                    contador = 0;
                }
                
                contador++;
            }
        }
    }
}
