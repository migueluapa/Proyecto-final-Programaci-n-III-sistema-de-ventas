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


     

    public partial class Cliente : Form
    {

        //SentenciaSQL  conexion = new  SentenciaSQL () ;

       SQLiteConnection conexion;
         

        public Cliente()
        {
            InitializeComponent();
        }


        private  void cargardato()
 {

     conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");

     //conexion.SentenciaSQL SentenciaSQL = new conexion.SentenciaSQL();


     conexion.Open();


     SQLiteDataAdapter da;
     DataTable dt = new DataTable();


     da = new SQLiteDataAdapter("SELECT  * from cliente ", conexion);

     da.Fill(dt);

     this.dataGridView1.DataSource = dt;

     conexion.Close();


 }


        private void button3_Click(object sender, EventArgs e)
        {
            
            //conexion = new SQLiteConnection("Data Source=C:/Users/juan/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");

            if (string.IsNullOrEmpty(txtcedula.Text) | string.IsNullOrEmpty(txtcliente.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtemail.Text) | string.IsNullOrEmpty(txtcliente.Text) | string.IsNullOrEmpty(txtcliente.Text) | string.IsNullOrEmpty(txttelefono.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos del Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into cliente values(@id_cliente,@cedula,@cliente,@direccion,@telefono,@email)", conexion);

            cmd.Parameters.Add(new SQLiteParameter("@id_cliente", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cedula", txtcedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cliente", txtcliente.Text));

            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));
            cmd.Parameters.Add(new SQLiteParameter("@email", txtemail.Text));


            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();

            cargardato();

        }

        public void borar()
        {

            txtbuscar.Text = "";
           txtcedula.Text = "";
           txtcliente.Text = "";
           txtdireccion.Text = "";
           txttelefono.Text = "";
           txtemail.Text = "";


        }


        public void autogenerar()
        {
            //conexion = new SQLiteConnection("Data Source=C:/Users/juan/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");
            string ca;
            int t;

            string sql1 = "select id_cliente  from  cliente";
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
        private void Form1_Load(object sender, EventArgs e)
        {
            cargardato();

            autogenerar();

            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {



            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();



        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {


            {
                conexion.Open();

                string sql = "SELECT   * FROM    cliente     WHERE cliente like '" + txtbuscar.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                dataGridView1.DataSource = dtcliente;

                conexion.Close();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {





            SQLiteCommand cmd = new SQLiteCommand("update cliente set cedula=@cedula,cliente=@cliente,direccion=@direccion,telefono=@telefono,email=@email  where id_cliente=@id_cliente", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_cliente", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cedula", txtcedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cliente", txtcliente.Text));

            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));
            cmd.Parameters.Add(new SQLiteParameter("@email", txtemail.Text));



     


            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()


            MessageBox.Show("Asido Modificado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();

            cargardato();








        }

        private void button4_Click(object sender, EventArgs e)
        {



            SQLiteCommand cmd = new SQLiteCommand("delete  from  cliente where id_cliente=@id_cliente", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@id_cliente", txtcodigo.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();



            conexion.Close();

            MessageBox.Show("Asido Eliminado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();

            cargardato();






        }

        private void button2_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();

            cargardato();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtcodigo.Text = dataGridView1.CurrentRow.Cells["id_cliente"].Value.ToString();

            txtcedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
            txtcliente.Text = dataGridView1.CurrentRow.Cells["cliente"].Value.ToString();

            txtdireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();


            button3.Enabled = false;


            button6.Enabled = true;
            button4.Enabled = true;



        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
