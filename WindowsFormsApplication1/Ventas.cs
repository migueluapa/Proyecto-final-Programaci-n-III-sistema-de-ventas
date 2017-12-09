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
    public partial class Ventas : Form
    {

        SQLiteConnection conexion;



        public Ventas()
        {
            InitializeComponent();
        }
        public void autogenerar()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");

            string ca;
            int t;

            string sql1 = "select id_documento  from  cab_documento";
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
            this.txtnumero.Text = ca;



        }
        private void Button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtcantidad.Text))
            {
                MessageBox.Show("Debe Ingesar la cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }






            int rowEscribir = dgDatos.Rows.Count - 1;

            dgDatos.Rows.Add(1);
            dgDatos.Rows[rowEscribir].Cells[0].Value = this.txtnumero.Text;

            dgDatos.Rows[rowEscribir].Cells[1].Value = this.txtcodigoproducto.Text;
            dgDatos.Rows[rowEscribir].Cells[2].Value = this.txtproducto.Text;

            dgDatos.Rows[rowEscribir].Cells[3].Value = this.txtmarca.Text;
            dgDatos.Rows[rowEscribir].Cells[4].Value = this.txtprecio.Text;
            dgDatos.Rows[rowEscribir].Cells[5].Value = this.txtcantidad.Text;
            dgDatos.Rows[rowEscribir].Cells[6].Value = this.txtimporte.Text;


            double sumatoria = 0;
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos.
                sumatoria += Convert.ToDouble(row.Cells["importe"].Value);
            }
            //Por ultimo asignamos el resultado a el texto de nuestro Label
            //txtsubtotal.Text = Convert.ToString(sumatoria);

            txtsubtotal.Text = sumatoria.ToString("#0.00");
            ///////////////////////////////////////////////
            //try
            //{


            //int  mostrar;



            //  mostrar = Int32.Parse(txtsubtotal.Text);

            //txtsubtotal.Text = mostrar.ToString("#0.00");


            double itbis = (sumatoria * 0.18);


            //txtigv.Text = Convert.ToString(igv);

            txtigv.Text = itbis.ToString("#0.00");

            double suma = (sumatoria + itbis);


            //txttotal.Text = Convert.ToString(suma);


            txttotal.Text = suma.ToString("#0.00");

            Button4.Enabled = true;

            Button2.Enabled = true;

        }

        private void Button2_Click(object sender, EventArgs e)
        {



            try
            {


                
    
            
            
            
            int Todo = dgDatos.RowCount; //cuenta todas las filas del dgDatos
            if (Todo >= 1) //las filas del dgDatos tienen que ser mayor o igual a 2 para poder remover
            {
                int Fil = dgDatos.CurrentRow.Index;


                dgDatos.Rows.RemoveAt(dgDatos.CurrentRow.Index);
            }
            else //en caso contrario no remueve la fila
            {
                MessageBox.Show("No Existe Ninguna Detalle!",
                "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }

            double sumatoria = 0;
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos.
                sumatoria += Convert.ToDouble(row.Cells["importe"].Value);
            }
            //Por ultimo asignamos el resultado a el texto de nuestro Label
            //txtsubtotal.Text = Convert.ToString(sumatoria);

            txtsubtotal.Text = sumatoria.ToString("#0.00");
            ///////////////////////////////////////////////


            double igv = (sumatoria * 0.18);



            txtigv.Text = igv.ToString("#0.00");

            double suma = (sumatoria + igv);



            txttotal.Text = suma.ToString("#0.00");



            }
            catch (Exception)
            {

            }
            







        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txtsubtotal.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtigv.Text) | string.IsNullOrEmpty(txtproveedor.Text) | string.IsNullOrEmpty(txtdireccion.Text) | string.IsNullOrEmpty(txtruc.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos Correctamente", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into cab_documento values(@id_documento,@tipo,@serie,@hora,@fecha,@usuario,@cliente,@sub_total,@igv,@total)", conexion);

            cmd.Parameters.Add(new SQLiteParameter("@id_documento", txtnumero.Text));
            cmd.Parameters.Add(new SQLiteParameter("@tipo", txtdocumento.Text));
            cmd.Parameters.Add(new SQLiteParameter("@serie", txtserie.Text));

            cmd.Parameters.Add(new SQLiteParameter("@hora", txthora.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha", txtfecha.Text));
            cmd.Parameters.Add(new SQLiteParameter("@usuario", cbousuario.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cliente", txtproveedor.Text));

            cmd.Parameters.Add(new SQLiteParameter("@sub_total", txtsubtotal.Text));
            cmd.Parameters.Add(new SQLiteParameter("@igv", txtigv.Text));
            cmd.Parameters.Add(new SQLiteParameter("@total", txttotal.Text));


            conexion.Open();

            cmd.ExecuteNonQuery();


            Detallesss();
            stock();

            //     conexion.Close()


            MessageBox.Show("Asido Registrado la Venta ", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgDatos.Rows.Clear();
            borar();


            Button4.Enabled = false;
            Button3.Enabled = false;
            Button2.Enabled = false;


            autogenerar();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro de Ventas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }
        private void Detallesss()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");

            Int32 i;

            for (i = 0; i < dgDatos.Rows.Count - 1; i++)
            {

                String sql;

                SQLiteCommand comando;

                sql = "insert into DETALLE_DOCUMENTO(ID_DOCUMENTO,ID_PRODUCTO,DES_PRODUCTO,MARCA,PRECIO,CANTIDAD,IMPORTE) Values ('" + dgDatos.Rows[i].Cells[0].Value + "','" + dgDatos.Rows[i].Cells[1].Value + "','" + dgDatos.Rows[i].Cells[2].Value + "','" + dgDatos.Rows[i].Cells[3].Value + "','" + dgDatos.Rows[i].Cells[4].Value + "','" + dgDatos.Rows[i].Cells[5].Value + "','" + dgDatos.Rows[i].Cells[6].Value + "')";

                comando = new SQLiteCommand(sql, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void stock()
        {




            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db"))
            {
                conexion.Open();

                string query = "UPDATE Productos SET STOCK_ACTUAL = STOCK_ACTUAL - @cantidad WHERE  ID_PRODUCTO= @ID_PRODUCTO";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);


                foreach (DataGridViewRow item in dgDatos.Rows)
                {

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@ID_PRODUCTO", Convert.ToInt32(item.Cells[1].Value));
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(item.Cells[5].Value));

                    cmd.ExecuteNonQuery();

                    //conn.Close();


                }

            }






        }
        public void borar()
        {


            txtdireccion.Text = "";

            txtproveedor.Text = "";
            txtcodigo.Text = "";
            txtruc.Text = "";
            txtcodigoproducto.Text = "";
            txtproducto.Text = "";
            txtcategoria.Text = "";
            txtmarca.Text = "";
            txtprecio.Text = "";
            txtimporte.Text = "";
            txtstock.Text = "";
            txtcantidad.Text = "";
            txtsubtotal.Text = "";
            txtigv.Text = "";
            txttotal.Text = "";

        }
        private void cargardatoproducto()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");





            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("select  productos.id_producto as codigo, productos.serie,productos.des_producto as producto,precio_venta as p_venta,productos.stock_actual as stock,productos.marca,productos.categoria,productos.unidad_medida,productos.proveedor,productos.fecha_ingreso from productos", conexion);

            da.Fill(dt);

            this.DataGridViewproducto.DataSource = dt;

            conexion.Close();


        }

        private void cargardatocliente()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");

            //conexion.SentenciaSQL SentenciaSQL = new conexion.SentenciaSQL();


            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT  * from cliente ", conexion);

            da.Fill(dt);

            this.DataGridViewproveedor.DataSource = dt;

            conexion.Close();


        }

        public void usuario()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from usuarios", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "usuarios");



            cbousu.DataSource = ds.Tables[0].DefaultView;

            cbousu.DisplayMember = "usuario";
            //this.cbomarca.ValueMember = "id_marca";



        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            autogenerar();
            txthora.Text = System.DateTime.Now.ToLongTimeString();

            usuario();

            panelproveedor.Visible = false;

            panelproducto.Visible = false;

            Button4.Enabled = false;
            Button3.Enabled = false;
            Button2.Enabled = false;
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {


                decimal a, b, total;




                a = decimal.Parse(txtprecio.Text);
                b = decimal.Parse(txtcantidad.Text);


                total = a * b;

                txtimporte.Text = total.ToString();


            }
            catch (Exception)
            {

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            {
                conexion.Open();

                string sql = "select  productos.id_producto as codigo, productos.serie,productos.des_producto as producto,productos.precio_venta as p_venta,productos.stock_actual as stock,productos.marca,productos.categoria,productos.unidad_medida,productos.proveedor,productos.fecha_ingreso from productos     WHERE des_producto like '" + TextBox1.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                DataGridViewproducto.DataSource = dtcliente;

                conexion.Close();
            }
        }

        private void DataGridViewproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigoproducto.Text = DataGridViewproducto.CurrentRow.Cells["codigo"].Value.ToString();


            txtproducto.Text = DataGridViewproducto.CurrentRow.Cells["producto"].Value.ToString();

            txtprecio.Text = DataGridViewproducto.CurrentRow.Cells["p_venta"].Value.ToString();


            txtstock.Text = DataGridViewproducto.CurrentRow.Cells["stock"].Value.ToString();

            txtmarca.Text = DataGridViewproducto.CurrentRow.Cells["marca"].Value.ToString();
            txtcategoria.Text = DataGridViewproducto.CurrentRow.Cells["categoria"].Value.ToString();

            panelproducto.Visible = false;


            Button3.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            panelproducto.Visible = true;

            cargardatoproducto();
            TextBox1.Text = "";
            txtcantidad.Text = "";
            txtimporte.Text = "";

        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {

            {
                conexion.Open();

                string sql = "SELECT   * FROM    cliente     WHERE cliente like '" + txtconsultar.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                DataGridViewproveedor.DataSource = dtcliente;

                conexion.Close();
            }

        }

        private void DataGridViewproveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DataGridViewproveedor.CurrentRow.Cells["id_cliente"].Value.ToString();


            txtproveedor.Text = DataGridViewproveedor.CurrentRow.Cells["cliente"].Value.ToString();

            txtdireccion.Text = DataGridViewproveedor.CurrentRow.Cells["direccion"].Value.ToString();
            txtruc.Text = DataGridViewproveedor.CurrentRow.Cells["telefono"].Value.ToString();

            panelproveedor.Visible =false;

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            panelproveedor.Visible = true;

            cargardatocliente();
            txtconsultar.Text = "";

        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Productos abrir = new Productos();

            abrir.Show();
        }
    }
}
