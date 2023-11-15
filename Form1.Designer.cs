namespace WindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRetroceder = new Button();
            btnEliminar = new Button();
            afoto = new PictureBox();
            btnAvanzar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnNuevo = new Button();
            label5 = new Label();
            txtNumero = new TextBox();
            txtPrecio = new TextBox();
            txtProfesional = new TextBox();
            txtCalidad = new TextBox();
            txtMarca = new TextBox();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)afoto).BeginInit();
            SuspendLayout();
            // 
            // btnRetroceder
            // 
            btnRetroceder.Location = new Point(243, 332);
            btnRetroceder.Name = "btnRetroceder";
            btnRetroceder.Size = new Size(94, 29);
            btnRetroceder.TabIndex = 0;
            btnRetroceder.Text = "Retroceder\r\n";
            btnRetroceder.UseVisualStyleBackColor = true;
            btnRetroceder.Click += button1_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(243, 387);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // afoto
            // 
            afoto.Location = new Point(383, 51);
            afoto.Name = "afoto";
            afoto.Size = new Size(336, 204);
            afoto.SizeMode = PictureBoxSizeMode.Zoom;
            afoto.TabIndex = 2;
            afoto.TabStop = false;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(428, 332);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(94, 29);
            btnAvanzar.TabIndex = 3;
            btnAvanzar.Text = "Avanzar";
            btnAvanzar.UseVisualStyleBackColor = true;
            btnAvanzar.Click += Avanzar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 62);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 4;
            label1.Text = "Numero: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 104);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 5;
            label2.Text = "Precio: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 150);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 6;
            label3.Text = "Profesional:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 195);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 7;
            label4.Text = "Calidad:";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(428, 387);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 237);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 9;
            label5.Text = "Marca:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(212, 51);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(125, 27);
            txtNumero.TabIndex = 11;
            txtNumero.TextChanged += txtNumero_TextChanged;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(212, 97);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(125, 27);
            txtPrecio.TabIndex = 12;
            // 
            // txtProfesional
            // 
            txtProfesional.Location = new Point(212, 143);
            txtProfesional.Name = "txtProfesional";
            txtProfesional.Size = new Size(125, 27);
            txtProfesional.TabIndex = 13;
            // 
            // txtCalidad
            // 
            txtCalidad.Location = new Point(212, 188);
            txtCalidad.Name = "txtCalidad";
            txtCalidad.Size = new Size(125, 27);
            txtCalidad.TabIndex = 14;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(212, 234);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(125, 27);
            txtMarca.TabIndex = 16;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(578, 360);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 17;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOk);
            Controls.Add(txtMarca);
            Controls.Add(txtCalidad);
            Controls.Add(txtProfesional);
            Controls.Add(txtPrecio);
            Controls.Add(txtNumero);
            Controls.Add(label5);
            Controls.Add(btnNuevo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAvanzar);
            Controls.Add(afoto);
            Controls.Add(btnEliminar);
            Controls.Add(btnRetroceder);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)afoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRetroceder;
        private Button btnEliminar;
        private PictureBox afoto;
        private Button btnAvanzar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnNuevo;
        private Label label5;
        private TextBox txtNumero;
        private TextBox txtPrecio;
        private TextBox txtProfesional;
        private TextBox txtCalidad;
        private TextBox txtMarca;
        private Button btnOk;
    }
}