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
            BtnIngresar.Visible = true;
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
    }
}
