using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void RegistroClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Cliente  abrir = new Cliente( );

            abrir.Show();
        }

        private void RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos abrir = new Productos();

            abrir.Show();
        }

        private void RegistrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores abrir = new Proveedores();

            abrir.Show();
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria abrir = new Categoria();

            abrir.Show();
        }

        private void MarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Marca abrir = new Marca();

            abrir.Show();

        }

        private void RegistrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Usuario abrir = new Usuario();

            abrir.Show();





        }

        private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Sistema Ventas - Compras ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void AcercaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Acerca abrir = new Acerca();

            abrir.Show();

        }

        private void StockMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Stock_Marcas abrir = new Ver_Stock_Marcas();

            abrir.Show();
        }

        private void VerCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Stock_Categoria abrir = new Ver_Stock_Categoria();

            abrir.Show();
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas abrir = new Ventas();

            abrir.Show();
        }

        private void EntradaMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra abrir = new Compra();

            abrir.Show();
        }

        private void ListadoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver_Reporte_Productos abrir = new Ver_Reporte_Productos();

            abrir.Show();
        }

        private void ImprimirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void imprimirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        
        }

        private void ImprimirToolStripMenuItem4_Click(object sender, EventArgs e)
        {
    ;
        }

        private void MarcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reporte_Marca abrir = new Reporte_Marca();

            abrir.Show();
        }

        private void CategoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reporte_Categoria abrir = new Reporte_Categoria();

            abrir.Show();
        }

        private void ListadoProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_Proveedor abrir = new Reporte_Proveedor();

            abrir.Show();
        }

        private void ReporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_Cliente abrir = new Reporte_Cliente();

            abrir.Show();
        }

        private void DiaMesAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_Ventas_Fecha abrir = new Reporte_Ventas_Fecha();

            abrir.Show();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reporte_Compras_Fecha abrir = new Reporte_Compras_Fecha();

            abrir.Show();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
