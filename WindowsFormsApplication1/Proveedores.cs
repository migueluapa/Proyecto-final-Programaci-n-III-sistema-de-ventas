using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
    public partial class Proveedores : Form
    {

        SQLiteConnection conexion;


        public Proveedores()
        {
            InitializeComponent();
        }

        private void cargardato()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT  id_proveedor as codigo,des_proveedor as proveedor,direccion,telefono,ruc,email from  proveedor ", conexion);

            da.Fill(dt);

            this.DataGridView1.DataSource = dt;

            conexion.Close();


        }
        private void Button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtemail.Text) | string.IsNullOrEmpty(txtruc.Text) | string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txttelefono.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos del  Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into proveedor values(@id_proveedor,@des_proveedor,@telefono,@direccion,@ruc,@email)", conexion);

            cmd.Parameters.Add(new SQLiteParameter("@id_proveedor", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@des_proveedor", txtproveedor.Text));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));

            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));
            cmd.Parameters.Add(new SQLiteParameter("@ruc", txtruc.Text));
        
            cmd.Parameters.Add(new SQLiteParameter("@email", txtemail.Text));


            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            SQLiteCommand cmd = new SQLiteCommand("update proveedor set des_proveedor=@des_proveedor,telefono=@telefono,direccion=@direccion,ruc=@ruc,email=@email  where id_proveedor=@id_proveedor", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_proveedor", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@des_proveedor", txtproveedor.Text));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));

            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));
            cmd.Parameters.Add(new SQLiteParameter("@ruc", txtruc.Text));

            cmd.Parameters.Add(new SQLiteParameter("@email", txtemail.Text));





            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Modificado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();



        }

        private void Button4_Click(object sender, EventArgs e)
        {


            SQLiteCommand cmd = new SQLiteCommand("delete  from proveedor where id_proveedor=@id_proveedor", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_proveedor", txtcodigo.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();



            conexion.Close();

            MessageBox.Show("Asido Eliminado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();


        }

        private void Button5_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();

            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();
        }

        public void borar()
        {

            txtconsultar.Text = "";
            txtproveedor.Text = "";
            txtruc.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtemail.Text = "";


        }


        public void autogenerar()
        {
           
            string ca;
            int t;

            string sql1 = "select id_proveedor  from  proveedor";
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
        private void Proveedores_Load(object sender, EventArgs e)
        {
            cargardato();

            autogenerar();

            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DataGridView1.CurrentRow.Cells["codigo"].Value.ToString();
            txtproveedor.Text = DataGridView1.CurrentRow.Cells["proveedor"].Value.ToString();
            txttelefono.Text = DataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
   

            txtdireccion.Text = DataGridView1.CurrentRow.Cells["direccion"].Value.ToString();

            txtruc.Text = DataGridView1.CurrentRow.Cells["ruc"].Value.ToString();

            txtemail.Text = DataGridView1.CurrentRow.Cells["email"].Value.ToString();


            Button2.Enabled = false;


            Button3.Enabled = true;
            Button4.Enabled = true;

        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {

            {
                conexion.Open();

                string sql = "SELECT  id_proveedor as codigo,des_proveedor as proveedor,direccion,telefono,ruc,email from  proveedor    WHERE proveedor like '" + txtconsultar.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                DataGridView1.DataSource = dtcliente;

                conexion.Close();
            }










        }
    }
}
