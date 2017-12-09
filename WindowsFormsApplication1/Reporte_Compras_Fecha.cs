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
    public partial class Reporte_Compras_Fecha : Form
    {
        SQLiteConnection conexion;

        public Reporte_Compras_Fecha()
        {
            InitializeComponent();
        }

        private void Reporte_Compras_Fecha_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string factu = null;



            DataSet dset = new DataSet();

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Desktop/Sistema Ventas C#SQLITE/Ventas_Producto_Sqlite.s3db");



            string x = dateTimePicker1.Text;
            string xx = dateTimePicker2.Text;


            factu = "select * from compras where FECHA between '" + x + "' and '" + xx + "'";







            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "compras");




            Ver_Reporte_documento_compra reportar = new Ver_Reporte_documento_compra();



            reportar.SetDataSource(dset);

            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
