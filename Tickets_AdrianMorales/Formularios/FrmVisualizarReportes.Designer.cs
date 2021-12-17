
namespace Tickets_AdrianMorales.Formularios
{
    partial class FrmVisualizarReportes
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
            this.CrvVisualizador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvVisualizador
            // 
            this.CrvVisualizador.ActiveViewIndex = -1;
            this.CrvVisualizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVisualizador.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVisualizador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvVisualizador.Location = new System.Drawing.Point(0, 0);
            this.CrvVisualizador.Name = "CrvVisualizador";
            this.CrvVisualizador.Size = new System.Drawing.Size(800, 450);
            this.CrvVisualizador.TabIndex = 0;
            // 
            // FrmVisualizarReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrvVisualizador);
            this.Name = "FrmVisualizarReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de reportes";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVisualizador;
    }
}