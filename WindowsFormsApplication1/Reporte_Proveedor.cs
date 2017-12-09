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
    public partial class Reporte_Proveedor : Form
    {

        SQLiteConnection conexion;


        public Reporte_Proveedor()
        {
            InitializeComponent();
        }

        private void Reporte_Proveedor_Load(object sender, EventArgs e)
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");


            string factu = null;



            DataSet dset = new DataSet();






            factu = "SELECT *  FROM Proveedor";




            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "PRoveedor");




            Ver_Reporte_informe_proveedor reportar = new Ver_Reporte_informe_proveedor();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;


         
        }
    }
}
