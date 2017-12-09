using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SQLite;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Ver_Reporte_Productos : Form
    {

        SQLiteConnection conexion;
         



        public Ver_Reporte_Productos()
        {
            InitializeComponent();
        }
        private void cargardato()
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            string factu = null;



            DataSet dset = new DataSet();

 




            factu = "SELECT *  FROM PRODUCTOS";




            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "PRODUCTOS");




            Ver_Reporte_informe_producto reportar = new Ver_Reporte_informe_producto();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;


         

          


        }

        private void Ver_Reporte_Productos_Load(object sender, EventArgs e)
        {
            cargardato();
        }
    }
}
