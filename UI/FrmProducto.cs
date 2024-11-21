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
        private CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        private List<Producto> borradorProducto = new List<Producto>();

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void CargoCombo()
        {
            try
            {
                CmbCategoria.DataSource = null;
                CmbCategoria.DataSource = categoriaBusiness.Listar();
                CmbCategoria.ValueMember = "IdCategoria";
                CmbCategoria.DisplayMember = "Nombre";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
            DgvListado.Columns[2].Width = 100;
            DgvListado.Columns[2].HeaderText = "Código";
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[3].HeaderText = "Nombre";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Precio Venta";
            DgvListado.Columns[5].Width = 80;
            DgvListado.Columns[5].HeaderText = "Stock";
            DgvListado.Columns[6].Width = 80;
            DgvListado.Columns[6].HeaderText = "Estado";
            DgvListado.Columns[7].Visible = false;
            DgvListado.Columns[8].Width = 150;
            DgvListado.Columns[8].HeaderText = "Categoría";
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
            CargoCombo();
        }

        private void DgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnIngresar.Visible = false;
                BtnConfirmar.Visible = false;
                BtnCargar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["IdProducto"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtCodigo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Codigo"].Value);
                TxtPrecioVenta.Text = Convert.ToString(DgvListado.CurrentRow.Cells["PrecioVenta"].Value);
                TxtStock.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Stock"].Value);
                CargoCombo();
                if (DgvListado.CurrentRow != null)
                {
                    // Obtener el producto seleccionado
                    Producto productoSeleccionado = (Producto)DgvListado.CurrentRow.DataBoundItem;

                    // Seleccionar la categoría del producto en el ComboBox
                    CmbCategoria.SelectedValue = productoSeleccionado.TipoCategoria.IdCategoria;
                }
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre");
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnActivar.Visible = true;
                BtnDesactivar.Visible = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnActivar.Visible = false;
                BtnDesactivar.Visible = false;
                BtnEliminar.Visible = false;
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)

        {
            try
            {
                Producto producto = new Producto();
                producto.Codigo = TxtCodigo.Text;
                producto.Nombre = TxtNombre.Text;
                producto.PrecioVenta = Convert.ToDecimal(TxtPrecioVenta.Text);
                producto.Stock = Convert.ToInt32(TxtStock.Text);
                producto.TipoCategoria = new Categoria();
                producto.TipoCategoria.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                borradorProducto.Add(producto);

                MessageBox.Show("Producto cargado en la Lista");
                this.Listar();
                TxtCodigo.Clear();
                TxtNombre.Clear();
                TxtPrecioVenta.Clear();
                TxtStock.Clear();
                CmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (borradorProducto.Count == 0)
                {
                    throw new Exception("La Lista esta vacia!!");
                }
                productoBusiness.CargaVarios(borradorProducto);
                MessageBox.Show("Productos confirmados correctamente");
                borradorProducto = new List<Producto>();
                this.Listar();
                TabGeneral.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            borradorProducto = new List<Producto>();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();
                producto.Codigo = TxtCodigo.Text;
                producto.Nombre = TxtNombre.Text;
                producto.PrecioVenta = Convert.ToDecimal(TxtPrecioVenta.Text);
                producto.Stock = Convert.ToInt32(TxtStock.Text);
                producto.TipoCategoria = new Categoria();
                producto.TipoCategoria.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                productoBusiness.Carga(producto);
                MessageBox.Show("Producto cargado correctamente");
                this.Listar();
                TxtCodigo.Clear();
                TxtNombre.Clear();
                TxtPrecioVenta.Clear();
                TxtStock.Clear();
                CmbCategoria.SelectedIndex = -1;
                TabGeneral.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                productoBusiness.Actualizar(Convert.ToInt32(TxtId.Text), TxtCodigo.Text, TxtNombre.Text, Convert.ToDecimal(TxtPrecioVenta.Text), Convert.ToInt32(TxtStock.Text), Convert.ToInt32(CmbCategoria.SelectedValue));
                this.Listar();
                MessageBox.Show("El Producto se actualizó de forma correta");
                this.Limpiar();
                TabGeneral.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            BtnConfirmar.Visible = true;
            BtnCargar.Visible = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el(los) registro(s)?", "Gestion Pizzeria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            productoBusiness.Eliminar(Codigo);
                            MessageBox.Show("Se elimino el registro: " + Convert.ToString(row.Cells[2].Value));
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCancelaBuscar_Click(object sender, EventArgs e)
        {
            this.Listar();
            TxtBuscar.Text = null;
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas Activar el(los) registro(s)?", "Gestion Pizzeria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            productoBusiness.Activar(Codigo);
                            MessageBox.Show("Se Activó el registro: " + Convert.ToString(row.Cells[2].Value));
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas Desactivar el(los) registro(s)?", "Gestion Pizzeria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            productoBusiness.Desactivar(Codigo);
                            MessageBox.Show("Se Desactivó el registro: " + Convert.ToString(row.Cells[2].Value));
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
