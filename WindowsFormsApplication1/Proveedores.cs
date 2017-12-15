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
            //Este codigo es para que cuando algun usuario no ingrese datos le muestre un mensaje que diga que debe ingresar los datos del proveedor.
            if (string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtemail.Text) | string.IsNullOrEmpty(txtruc.Text) | string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txttelefono.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos del  Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }

            //Este Comando nos permite   insertar datos a nuestra tabla proveedor.

            SQLiteCommand cmd = new SQLiteCommand("insert into proveedor values(@id_proveedor,@des_proveedor,@telefono,@direccion,@ruc,@email)", conexion);

            //Estos 6 parametros representan a los seis campos que hay en nuestra tabla proveedor.
            try
            {
                cmd.Parameters.Add(new SQLiteParameter("@id_proveedor", txtcodigo.Text)); // Este parametro va hacer representando por por la caja de texto txt codigo
            cmd.Parameters.Add(new SQLiteParameter("@des_proveedor", txtproveedor.Text));   // Este parametro va hacer representando por por la caja de texto txt proveedor
            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));   // Este parametro va hacer representando por por la caja de texto txt telefono

            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));   // Este parametro va hacer representando por por la caja de texto txt direccion
            cmd.Parameters.Add(new SQLiteParameter("@ruc", txtruc.Text));   // Este parametro va hacer representando por por la caja de texto txt ruc que es el registro unico de contribuyente

            cmd.Parameters.Add(new SQLiteParameter("@email", txtemail.Text));   // Este parametro va hacer representando por por la caja de texto txt email


            conexion.Open();

            cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("error al insertar los Datos");
            }



            //     conexion.Close()


            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information); // Este es el mensaje que  nos va a mostrar  despues de haber insertado los datos


            borar();


            Button2.Enabled = true;


            Button3.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            // Todo este codigo equivale para poder  modificar o actualizar los datos del proveedor
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
            // Este codigo nos pemite eliminar un  proveedor de nuestra tabla

            SQLiteCommand cmd = new SQLiteCommand("delete  from proveedor where id_proveedor=@id_proveedor", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_proveedor", txtcodigo.Text));  // Solo hay un parametro porque vamos a eliminar por id proveedor

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
