namespace WindowsFormsApplication1
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtconsultar = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtcargo = new System.Windows.Forms.TextBox();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Button5);
            this.GroupBox2.Controls.Add(this.Button4);
            this.GroupBox2.Controls.Add(this.Button6);
            this.GroupBox2.Controls.Add(this.Button7);
            this.GroupBox2.Controls.Add(this.Button8);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(8, 393);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(570, 100);
            this.GroupBox2.TabIndex = 182;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Mantenimiento";
            // 
            // Button5
            // 
            this.Button5.ForeColor = System.Drawing.Color.Black;
            this.Button5.Image = ((System.Drawing.Image)(resources.GetObject("Button5.Image")));
            this.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button5.Location = new System.Drawing.Point(348, 29);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(100, 50);
            this.Button5.TabIndex = 3;
            this.Button5.Text = "Eliminar";
            this.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Button4
            // 
            this.Button4.ForeColor = System.Drawing.Color.Black;
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button4.Location = new System.Drawing.Point(449, 29);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(113, 50);
            this.Button4.TabIndex = 3;
            this.Button4.Text = "Salir";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button6
            // 
            this.Button6.ForeColor = System.Drawing.Color.Black;
            this.Button6.Image = ((System.Drawing.Image)(resources.GetObject("Button6.Image")));
            this.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button6.Location = new System.Drawing.Point(233, 29);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(113, 50);
            this.Button6.TabIndex = 3;
            this.Button6.Text = "Modificar";
            this.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // Button7
            // 
            this.Button7.ForeColor = System.Drawing.Color.Black;
            this.Button7.Image = ((System.Drawing.Image)(resources.GetObject("Button7.Image")));
            this.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button7.Location = new System.Drawing.Point(119, 29);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(113, 50);
            this.Button7.TabIndex = 3;
            this.Button7.Text = "Grabar";
            this.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // Button8
            // 
            this.Button8.ForeColor = System.Drawing.Color.Black;
            this.Button8.Image = ((System.Drawing.Image)(resources.GetObject("Button8.Image")));
            this.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button8.Location = new System.Drawing.Point(5, 29);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(113, 50);
            this.Button8.TabIndex = 3;
            this.Button8.Text = "Nuevo";
            this.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(48, 212);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(63, 13);
            this.Label6.TabIndex = 176;
            this.Label6.Text = "Seleccionar";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(28, 226);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(466, 161);
            this.DataGridView1.TabIndex = 179;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Label5);
            this.GroupBox4.Controls.Add(this.txtconsultar);
            this.GroupBox4.Location = new System.Drawing.Point(28, 141);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(466, 68);
            this.GroupBox4.TabIndex = 180;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Consultar";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(17, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 97;
            this.Label5.Text = "Usuario";
            // 
            // txtconsultar
            // 
            this.txtconsultar.Location = new System.Drawing.Point(87, 23);
            this.txtconsultar.Name = "txtconsultar";
            this.txtconsultar.Size = new System.Drawing.Size(351, 20);
            this.txtconsultar.TabIndex = 97;
            this.txtconsultar.TextChanged += new System.EventHandler(this.txtconsultar_TextChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Location = new System.Drawing.Point(358, 243);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(31, 43);
            this.GroupBox3.TabIndex = 178;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Buscar Cliente";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(276, 262);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(155, 48);
            this.GroupBox1.TabIndex = 177;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Informe de Usuario";
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Location = new System.Drawing.Point(112, 73);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(354, 20);
            this.txtcontraseña.TabIndex = 175;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(30, 80);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 171;
            this.Label3.Text = "Contraseña";
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(112, 52);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(354, 20);
            this.txtusuario.TabIndex = 174;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(30, 56);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 170;
            this.Label2.Text = "Usuario";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Location = new System.Drawing.Point(112, 30);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(175, 20);
            this.txtcodigo.TabIndex = 173;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(31, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 172;
            this.Label1.Text = "Codigo";
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(132, 243);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(89, 49);
            this.ComboBox1.TabIndex = 168;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(227, 281);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(112, 46);
            this.ComboBox2.TabIndex = 169;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.Label4);
            this.GroupBox5.Controls.Add(this.txtcargo);
            this.GroupBox5.Location = new System.Drawing.Point(21, 12);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(473, 114);
            this.GroupBox5.TabIndex = 181;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Informe del Usuario";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 88);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 13);
            this.Label4.TabIndex = 104;
            this.Label4.Text = "Cargo";
            // 
            // txtcargo
            // 
            this.txtcargo.Location = new System.Drawing.Point(91, 82);
            this.txtcargo.Name = "txtcargo";
            this.txtcargo.Size = new System.Drawing.Size(354, 20);
            this.txtcargo.TabIndex = 104;
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(604, 506);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txtcontraseña);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.GroupBox5);
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.Button Button7;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtconsultar;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtcontraseña;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtusuario;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtcargo;
    }
}