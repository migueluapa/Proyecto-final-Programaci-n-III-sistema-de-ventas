using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        SQLiteConnection conexion;


        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {


            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            conexion.Open();
            SQLiteCommand consulta = new SQLiteCommand("select * from usuarios  where usuario= '" + TextBox1.Text + "'and passwords='" + TextBox2.Text + "'", conexion);
            SQLiteDataReader ejecuta = consulta.ExecuteReader();

            if (ejecuta.Read() == true)
            {




                //this.Hide();

                this.Hide();
                Menu_Principal abrir = new Menu_Principal();

                //entrada_mercaderia.mostrar.Text = TextBox1.Text;



                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Los Datos Ingresados Son Incorrectos", "Acceso Denegado");

                TextBox1.Clear();


                TextBox2.Clear();

                TextBox1.Focus();


                conexion.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro Ingreso?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
