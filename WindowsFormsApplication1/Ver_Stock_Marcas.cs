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
    public partial class Ver_Stock_Marcas : Form
    {
        public Ver_Stock_Marcas()
        {
            InitializeComponent();
        }

        SQLiteConnection conexion;


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

        private void Ver_Stock_Marcas_Load(object sender, EventArgs e)
        {
            area();
        }

        private void cbomarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            conexion.Open();

            string sql = "select  productos.id_producto as codigo, productos.serie,productos.des_producto as producto,productos.compra_compra as p_compra,productos.precio_venta as p_venta,productos.stock_actual as stock,productos.marca,productos.categoria,productos.unidad_medida,productos.proveedor,productos.fecha_ingreso from productos   WHERE productos.marca like '" + cbomarca.Text + "%'";

            SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

            DataTable dtcliente = new DataTable();

            dacliente.Fill(dtcliente);
            DataGridView1.DataSource = dtcliente;

            conexion.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Consulta ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }
    }
}
