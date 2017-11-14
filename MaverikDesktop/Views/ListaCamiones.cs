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
    public partial class ListaCamiones : Form
    {
        private Models.RootObject colaDeCarga1 = new Models.RootObject();
        public Models.RootObject ColaDeCarga1 { get => colaDeCarga1; set => colaDeCarga1 = value; }
        private Models.ColaDeCarga colaDeCarga2 = new Models.ColaDeCarga();
        public Models.ColaDeCarga ColaDeCarga2 { get => colaDeCarga2; set => colaDeCarga2 = value; }

        public ListaCamiones(Models.RootObject value)
        {
            InitializeComponent();
            ColaDeCarga1 = value;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            string identificador = Regex.Match(sender.ToString(), @"\d+").Value;
            foreach (Models.ColaDeCarga cdc in colaDeCarga1.cola_de_carga)
            {
                foreach (Models.Remito r in cdc.remitos)
                {
                    {
                       
                            if (r.unidad_de_distribucion_id == Int32.Parse(identificador))
                            {
                                    colaDeCarga2 = cdc;
                                    break;
                            }
                        
                    }
                }

            }

            ColaDeCarga colaDeCarga = new ColaDeCarga(colaDeCarga2);
            colaDeCarga.Show();
        }

        private void ListaCamiones_Load(object sender, EventArgs e)
        {
            string unidad = "";
            List<Button> buttons = new List<Button>();
            int x = 50; int y = 50; int contador = 0;
            foreach (Models.ColaDeCarga cdc in colaDeCarga1.cola_de_carga)
            {

                Button newButton = new Button();
                foreach(Models.Remito r in cdc.remitos)
                {
                    unidad = r.unidad_de_distribucion_id.ToString();
                }
                newButton.Text = "Unidad " + unidad;
                newButton.Font = new Font(newButton.Font.FontFamily, 13);
                newButton.Location = new Point(x, y);
                newButton.Name = unidad;
                newButton.Click += Button_Click;
                newButton.Size = new Size(100, 75);
                buttons.Add(newButton);
                this.Controls.Add(newButton);
                if (contador < 5)
                {
                    x = x + 100;
                }
                else
                {
                    y = y + 75;
                    x = 50;
                    contador = 0;
                }

                contador++;
            }
        } 
    }
}
