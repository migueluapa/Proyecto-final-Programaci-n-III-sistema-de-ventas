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
    public partial class Marca : Form
    {

        SQLiteConnection conexion;
         

        public Marca()
        {
            InitializeComponent();
        }
        private void cargardato()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT  * from marcas ", conexion);

            da.Fill(dt);

            this.DataGridView1.DataSource = dt;

            conexion.Close();


        }
        public void borar()
        {
            txtconsultar.Text = "";
            txtmarca.Text = "";



        }


        public void autogenerar()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");
            string ca;
            int t;

            string sql1 = "select id_marca  from marcas";
            SQLiteDataAdapter dacategoria = new SQLiteDataAdapter(sql1, conexion);
            DataTable dtcategoria = new DataTable();
            dacategoria.Fill(dtcategoria);
            t = dtcategoria.Rows.Count;
            conexion.Close();
            ca = (t + 1).ToString();
            do
            {
                ca = "0" + ca;
            } while (ca.Length < 2);
            this.txtcodigo.Text = ca;



        }
        private void Marca_Load(object sender, EventArgs e)
        {
            cargardato();

            autogenerar();


            Button7.Enabled = true;


            Button6.Enabled = false;
            Button5.Enabled = false;

        }

        private void Button8_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();



            Button7.Enabled = true;


            Button6.Enabled = false;
            Button5.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigo.Text) | string.IsNullOrEmpty(txtmarca.Text) | string.IsNullOrEmpty(txtmarca.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos de marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into marcas values(@id_marca,@marca)", conexion);

            cmd.Parameters.Add(new SQLiteParameter("@id_marca", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@marca", txtmarca.Text));


            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button7.Enabled = true;


            Button6.Enabled = false;
            Button5.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand("update marcas set marca=@marca  where id_marca=@id_marca", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_marca", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@marca", txtmarca.Text));






            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Modificado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button7.Enabled = true;


            Button6.Enabled = false;
            Button5.Enabled = false;


            autogenerar();

            cargardato();


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand("delete  from  marcas  where id_marca=@id_marca", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_marca", txtcodigo.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();



            conexion.Close();

            MessageBox.Show("Asido Eliminado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();



            Button7.Enabled = true;


            Button6.Enabled = false;
            Button5.Enabled = false;


            autogenerar();

            cargardato();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DataGridView1.CurrentRow.Cells["id_marca"].Value.ToString();

            txtmarca.Text = DataGridView1.CurrentRow.Cells["marca"].Value.ToString();



            Button7.Enabled = false;


            Button6.Enabled = true;
            Button5.Enabled = true;
        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            conexion.Open();

            string sql = "SELECT   * FROM   marcas   WHERE marca like '" + txtconsultar.Text + "%'";

            SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

            DataTable dtcliente = new DataTable();

            dacliente.Fill(dtcliente);
            DataGridView1.DataSource = dtcliente;

            conexion.Close();
        }
    }
}
