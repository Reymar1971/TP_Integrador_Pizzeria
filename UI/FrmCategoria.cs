using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BLL;
using Entity;


namespace UI
{
    public partial class FrmCategoria : Form
    {
        private CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        private List<Categoria> borradorCategoria = new List<Categoria>();


        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                //cambio color alternando las filas de la grilla
                this.DgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;

                DgvListado.DataSource = categoriaBusiness.Listar();
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
            DgvListado.Columns[2].HeaderText = "Nombre";
            DgvListado.Columns[3].Width = 450;
            DgvListado.Columns[3].HeaderText = "Descripción";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Estado";
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = categoriaBusiness.Buscar(TxtBuscar.Text.Trim());
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
            TxtDescripcion.Clear();
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


        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            Listar();
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
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["IdCategoria"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                categoriaBusiness.Actualizar(Convert.ToInt32(TxtId.Text), TxtNombre.Text, TxtDescripcion.Text);
                this.Listar();
                MessageBox.Show("La Categoría se actualizó de forma correta");
                this.Limpiar();
                TabGeneral.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = TxtNombre.Text;
                categoria.Descripcion = TxtDescripcion.Text;
                borradorCategoria.Add(categoria);

                MessageBox.Show("Categoria cargada en la Lista");
                this.Listar();
                TxtDescripcion.Clear();
                TxtNombre.Clear();

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
                if (borradorCategoria.Count == 0)
                {
                    throw new Exception("La Lista esta vacia!!");
                }
                categoriaBusiness.CargaVarios(borradorCategoria);
                MessageBox.Show("Categorias confirmadas correctamente");
                borradorCategoria = new List<Categoria>();
                this.Listar();
                TabGeneral.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            borradorCategoria = new List<Categoria>();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = TxtNombre.Text;
                categoria.Descripcion = TxtDescripcion.Text;
                categoriaBusiness.Carga(categoria);
                MessageBox.Show("Categoria cargada correctamente");
                this.Listar();
                TxtDescripcion.Clear();
                TxtNombre.Clear();
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
                            categoriaBusiness.Eliminar(Codigo);
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
                            categoriaBusiness.Activar(Codigo);
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
                            categoriaBusiness.Desactivar(Codigo);
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCancelaBuscar_Click(object sender, EventArgs e)
        {
            this.Listar();
            TxtBuscar.Text = null;
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

        
    }
}
