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


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace WindowsFormsApplication1
{
    public partial class Reporte_Marca : Form
    {

        SQLiteConnection conexion;

        public Reporte_Marca()
        {
            InitializeComponent();
        }

        private void Reporte_Marca_Load(object sender, EventArgs e)
        {
            area();

        }

        public void area()
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from marcas", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "marcas");



            comboBox1.DataSource = ds.Tables[0].DefaultView;

            comboBox1.DisplayMember = "marca";
            //this.cbomarca.ValueMember = "id_marca";



        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string factu = null;



            DataSet dset = new DataSet();

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            string x = comboBox1.Text;



            factu = "SELECT *  FROM productos where marca like'" + x + "'";



            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "productos");



            Ver_Reporte_informe_producto reportar = new Ver_Reporte_informe_producto();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
