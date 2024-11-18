using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmProducto : Form
    {
        private ProductoBusiness productoBusiness = new ProductoBusiness();
        private List<Producto> borradorProducto = new List<Producto>();

        public FrmProducto()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = productoBusiness.Listar();
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total de registros: " + Convert.ToString(DgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 110;
            DgvListado.Columns[2].HeaderText = "Categoría";
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[3].HeaderText = "Código";
            DgvListado.Columns[4].Width = 150;
            DgvListado.Columns[4].HeaderText = "Nombre";
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Precio Venta";
            DgvListado.Columns[6].Width = 80;
            DgvListado.Columns[6].HeaderText = "Stock";
            DgvListado.Columns[7].Width = 50;
            DgvListado.Columns[7].HeaderText = "Estado";
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = productoBusiness.Buscar(TxtBuscar.Text.Trim());
                this.Formato();
                LblTotal.Text = "Total de registros: " + Convert.ToString(DgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpiar()
        {
            TxtNombre.Clear();
            TxtCodigo.Clear();
            TxtPrecioVenta.Clear();
            TxtStock.Clear();
            CmbCategoria.SelectedIndex = -1;
            TxtId.Clear();
            BtnIngresar.Visible = true;
            BtnCargar.Visible = true;
            BtnActualizar.Visible = false;

            DgvListado.Columns[0].Visible = false;
            BtnActivar.Visible = false;
            BtnDesactivar.Visible = false;
            BtnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
