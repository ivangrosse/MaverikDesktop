namespace MaverikDesktop.Views
{
    partial class ColaDeCarga
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.detalleRemito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // detalleRemito
            // 
            this.detalleRemito.AutoSize = true;
            this.detalleRemito.Location = new System.Drawing.Point(33, 285);
            this.detalleRemito.Name = "detalleRemito";
            this.detalleRemito.Size = new System.Drawing.Size(35, 13);
            this.detalleRemito.TabIndex = 0;
            this.detalleRemito.Text = "label1";
            // 
            // ColaDeCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 378);
            this.Controls.Add(this.detalleRemito);
            this.Name = "ColaDeCarga";
            this.Text = "Cola de carga";
            this.Load += new System.EventHandler(this.ColaDeCarga_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label detalleRemito;
    }
}