
namespace Tickets_AdrianMorales.Formularios
{
    partial class FrmUsuarioRecuperarContrasenia
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.BtnEnviarCodigo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigoEnviado = new System.Windows.Forms.TextBox();
            this.TxtPass1 = new System.Windows.Forms.TextBox();
            this.TxtPass2 = new System.Windows.Forms.TextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DE USUARIO / EMAIL";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(40, 54);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(274, 22);
            this.TxtUsuario.TabIndex = 1;
            this.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnEnviarCodigo
            // 
            this.BtnEnviarCodigo.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnEnviarCodigo.FlatAppearance.BorderSize = 0;
            this.BtnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarCodigo.ForeColor = System.Drawing.Color.White;
            this.BtnEnviarCodigo.Location = new System.Drawing.Point(58, 80);
            this.BtnEnviarCodigo.Name = "BtnEnviarCodigo";
            this.BtnEnviarCodigo.Size = new System.Drawing.Size(240, 23);
            this.BtnEnviarCodigo.TabIndex = 2;
            this.BtnEnviarCodigo.Text = "Enviar código de recuperación";
            this.BtnEnviarCodigo.UseVisualStyleBackColor = false;
            this.BtnEnviarCodigo.Click += new System.EventHandler(this.BtnEnviarCodigo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código de verificación enviado";
            // 
            // TxtCodigoEnviado
            // 
            this.TxtCodigoEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoEnviado.Location = new System.Drawing.Point(40, 180);
            this.TxtCodigoEnviado.MaxLength = 8;
            this.TxtCodigoEnviado.Name = "TxtCodigoEnviado";
            this.TxtCodigoEnviado.Size = new System.Drawing.Size(274, 22);
            this.TxtCodigoEnviado.TabIndex = 4;
            this.TxtCodigoEnviado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPass1
            // 
            this.TxtPass1.Location = new System.Drawing.Point(40, 249);
            this.TxtPass1.Name = "TxtPass1";
            this.TxtPass1.Size = new System.Drawing.Size(274, 20);
            this.TxtPass1.TabIndex = 6;
            this.TxtPass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPass2
            // 
            this.TxtPass2.Location = new System.Drawing.Point(40, 332);
            this.TxtPass2.Name = "TxtPass2";
            this.TxtPass2.Size = new System.Drawing.Size(274, 20);
            this.TxtPass2.TabIndex = 8;
            this.TxtPass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnAceptar.FlatAppearance.BorderSize = 0;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Location = new System.Drawing.Point(40, 382);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 9;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Red;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(239, 382);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 10;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nueva contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Repetir contraseña";
            // 
            // FrmUsuarioRecuperarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(354, 437);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtPass2);
            this.Controls.Add(this.TxtPass1);
            this.Controls.Add(this.TxtCodigoEnviado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnEnviarCodigo);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuarioRecuperarContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsuarioRecuperarContrasenia";
            this.Load += new System.EventHandler(this.FrmUsuarioRecuperarContrasenia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEnviarCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigoEnviado;
        private System.Windows.Forms.TextBox TxtPass1;
        private System.Windows.Forms.TextBox TxtPass2;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtUsuario;
    }
}