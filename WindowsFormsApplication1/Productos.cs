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
    public partial class Productos : Form
    {

        SQLiteConnection conexion;



        public Productos()
        {
            InitializeComponent();
        }

        private void cargardato()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");





            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("select  productos.id_producto as codigo, productos.serie,productos.des_producto as producto,productos.compra_compra as p_compra,productos.precio_venta as p_venta,productos.stock_actual as stock,productos.marca,productos.categoria,productos.unidad_medida,productos.proveedor,productos.fecha_ingreso from productos", conexion);

            da.Fill(dt);

            this.DataGridView1.DataSource = dt;

            conexion.Close();


        }



        public void area()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from marcas", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "marcas");



            cbomarca.DataSource = ds.Tables[0].DefaultView;

            this.cbomarca.DisplayMember = "marca";
            //this.cbomarca.ValueMember = "id_marca";



        }

        public void proveedor()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from proveedor", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "proveedor");



            cboproveedor.DataSource = ds.Tables[0].DefaultView;

            this.cboproveedor.DisplayMember = "des_proveedor";
            //this.cbomarca.ValueMember = "id_marca";



        }

        public void categoria()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from categorias", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "categorias");



            cbocategoria.DataSource = ds.Tables[0].DefaultView;

            this.cbocategoria.DisplayMember = "categoria";
            //this.cbomarca.ValueMember = "id_marca";



        }


        public void borar()
        {
            cbomarca.Text = "";
            cbocategoria.Text = "";

            TextBox1.Text = "";
         txtserie.Text= "";
         txtproducto.Text= "";

            txtcompra.Text= "";
          txtventa.Text= "";
            cboproveedor.Text= "";

        txtstock.Text= "";
    txtunidad.Text= "";
    txtfecha.Text = "";


        }


        public void autogenerar()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");
            string ca;
            int t;

            string sql1 = "select id_producto  from  productos";
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

       


      
        private void Productos_Load(object sender, EventArgs e)
        {

           


            autogenerar();
            proveedor();
            categoria();

            area();
            cargardato();
            Button3.Enabled = true;


            Button2.Enabled = false;
            Button4.Enabled = false;


            cbocategoria.Text = "";
            cbomarca.Text = "";
            cboproveedor.Text = "";


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Este codigo es para que cuando algun usuario no ingrese datos correctamente le muestre un mensaje que diga que debe ingresar los datos del producto.
            if (string.IsNullOrEmpty(txtproducto.Text) | string.IsNullOrEmpty(txtcompra.Text) | string.IsNullOrEmpty(txtventa.Text) | string.IsNullOrEmpty(cboproveedor.Text) | string.IsNullOrEmpty(txtstock.Text) | string.IsNullOrEmpty(cbomarca.Text) | string.IsNullOrEmpty(cbocategoria.Text))
            {
                MessageBox.Show("Debe Ingesar los Datos del Producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }
            try
            {

                //Este Comando nos permite   insertar datos a nuestra tabla productos.
                SQLiteCommand cmd = new SQLiteCommand("insert into productos values(@id_producto,@serie,@des_producto,@compra_compra,@precio_venta,@proveedor,@stock_actual,@unidad_medida,@fecha_ingreso,@marca,@categoria)", conexion);
            
            //Estos 11 parametros representan a los once campos que hay en nuestra tabla productos.
            cmd.Parameters.Add(new SQLiteParameter("@id_producto", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@serie", txtserie.Text));
            cmd.Parameters.Add(new SQLiteParameter("@des_producto", txtproducto.Text));

            cmd.Parameters.Add(new SQLiteParameter("@compra_compra", txtcompra.Text));
            cmd.Parameters.Add(new SQLiteParameter("@precio_venta", txtventa.Text));
            cmd.Parameters.Add(new SQLiteParameter("@proveedor", cboproveedor.Text));

            cmd.Parameters.Add(new SQLiteParameter("@stock_actual", txtstock.Text));
            cmd.Parameters.Add(new SQLiteParameter("@unidad_medida", txtunidad.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_ingreso", txtfecha.Text));
            cmd.Parameters.Add(new SQLiteParameter("@marca",cbomarca.Text));
            cmd.Parameters.Add(new SQLiteParameter("@categoria", cbocategoria.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("error al insertar los Datos intertelo correctamente");
            }


            //     conexion.Close()


            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button3.Enabled = true;


            Button2.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            {
                conexion.Open();

                string sql = "select  productos.id_producto as codigo, productos.serie,productos.des_producto as producto,productos.compra_compra as p_compra,productos.precio_venta as p_venta,productos.stock_actual as stock,productos.marca,productos.categoria,productos.unidad_medida,productos.proveedor,productos.fecha_ingreso from productos     WHERE des_producto like '" + TextBox1.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                DataGridView1.DataSource = dtcliente;

                conexion.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Este Comando nos permite   actualizar  datos a nuestra tabla productos.
                SQLiteCommand cmd = new SQLiteCommand("update productos set serie=@serie,des_producto=@des_producto,compra_compra=@compra_compra,precio_venta=@precio_venta,proveedor=@proveedor,stock_actual=@stock_actual,unidad_medida=@unidad_medida,fecha_ingreso=@fecha_ingreso,marca=@marca,categoria=@categoria  where id_producto=@id_producto", conexion);
          
       
            cmd.Parameters.Add(new SQLiteParameter("@id_producto", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@serie", txtserie.Text));
            cmd.Parameters.Add(new SQLiteParameter("@des_producto", txtproducto.Text));

            cmd.Parameters.Add(new SQLiteParameter("@compra_compra", txtcompra.Text));
            cmd.Parameters.Add(new SQLiteParameter("@precio_venta", txtventa.Text));
            cmd.Parameters.Add(new SQLiteParameter("@proveedor", cboproveedor.Text));

            cmd.Parameters.Add(new SQLiteParameter("@stock_actual", txtstock.Text));
            cmd.Parameters.Add(new SQLiteParameter("@unidad_medida", txtunidad.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_ingreso", txtfecha.Text));
            cmd.Parameters.Add(new SQLiteParameter("@marca", cbomarca.Text));
            cmd.Parameters.Add(new SQLiteParameter("@categoria", cbocategoria.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("error al insertar los Datos");
            }


            //     conexion.Close()


            MessageBox.Show("Asido Modificado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            Button3.Enabled = true;


            Button2.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand("delete  from  productos where id_producto=@id_producto", conexion);


            cmd.Parameters.Add(new SQLiteParameter("id_producto", txtcodigo.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();



            conexion.Close();

            MessageBox.Show("Asido Eliminado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            Button3.Enabled = true;


            Button2.Enabled = false;
            Button4.Enabled = false;

            autogenerar();

            cargardato();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            Button3.Enabled = true;


            Button2.Enabled = false;
            Button4.Enabled = false;


            autogenerar();

            cargardato();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DataGridView1.CurrentRow.Cells["codigo"].Value.ToString();

            txtserie.Text = DataGridView1.CurrentRow.Cells["serie"].Value.ToString();
            txtproducto.Text = DataGridView1.CurrentRow.Cells["producto"].Value.ToString();

            txtcompra.Text = DataGridView1.CurrentRow.Cells["p_compra"].Value.ToString();
            txtventa.Text = DataGridView1.CurrentRow.Cells["p_venta"].Value.ToString();
            cboproveedor.Text = DataGridView1.CurrentRow.Cells["proveedor"].Value.ToString();


           txtstock.Text = DataGridView1.CurrentRow.Cells["stock"].Value.ToString();
            txtunidad.Text = DataGridView1.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtfecha.Text = DataGridView1.CurrentRow.Cells["fecha_ingreso"].Value.ToString();

            cbomarca.Text = DataGridView1.CurrentRow.Cells["marca"].Value.ToString();
            cbocategoria.Text = DataGridView1.CurrentRow.Cells["categoria"].Value.ToString();



            Button3.Enabled = false;


            Button2.Enabled = true;
            Button4.Enabled = true;




        }
    }
}
