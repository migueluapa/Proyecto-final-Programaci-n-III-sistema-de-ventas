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
    public partial class Categoria : Form
    {
        SQLiteConnection conexion;
         

        public Categoria()
        {
            InitializeComponent();
        }
        private void cargardato()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT  * from categorias ", conexion);

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

            string sql1 = "select id_categoria  from categorias";
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
        private void Categoria_Load(object sender, EventArgs e)
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
            //Este codigo es para que cuando algun usuario no ingrese datos le muestre un mensaje que diga que debe ingresar los datos de categoria.
            if (string.IsNullOrEmpty(txtcodigo.Text) | string.IsNullOrEmpty(txtmarca.Text) | string.IsNullOrEmpty(txtmarca.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos del  Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }


            //Este Comando nos permite   insertar datos a nuestra tabla categoria.

            SQLiteCommand cmd = new SQLiteCommand("insert into categorias values(@id_categoria,@categoria)", conexion);



            //Estos 2 parametros representan a los dos campos que hay en nuestra tabla categoria.
            cmd.Parameters.Add(new SQLiteParameter("@id_categoria", txtcodigo.Text)); // Este parametro va hacer representando por por la caja de texto txt codigo categoria
            cmd.Parameters.Add(new SQLiteParameter("@categoria", txtmarca.Text)); // Este parametro va hacer representando por por la caja de texto txt marca


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



            SQLiteCommand cmd = new SQLiteCommand("update categorias set categoria=@categoria  where id_categoria=@id_categoria", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_categoria", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@categoria", txtmarca.Text));
     





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
            SQLiteCommand cmd = new SQLiteCommand("delete  from  categorias where id_categoria=@id_categoria", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_categoria", txtcodigo.Text));

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

            txtcodigo.Text =DataGridView1.CurrentRow.Cells["id_categoria"].Value.ToString();

            txtmarca.Text = DataGridView1.CurrentRow.Cells["categoria"].Value.ToString();
           


            Button7.Enabled = false;


            Button6.Enabled = true ;
            Button5.Enabled = true ;

        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            {
                conexion.Open();

                string sql = "SELECT   * FROM    categorias    WHERE categoria like '" + txtconsultar.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                DataGridView1.DataSource = dtcliente;

                conexion.Close();
            }
        }
    }
}
