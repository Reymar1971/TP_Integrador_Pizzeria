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
    public partial class FrmCliente : Form
    {
        private ClienteBusiness clienteBusiness = new ClienteBusiness();
        private List<Cliente> borradorCliente = new List<Cliente>();

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                //cambio color alternando las filas de la grilla
                this.DgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
                DgvListado.DataSource = clienteBusiness.Listar();
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
            DgvListado.Columns[2].Width = 200;
            DgvListado.Columns[2].HeaderText = "Nombre y Apellido";
            DgvListado.Columns[3].Width = 350;
            DgvListado.Columns[3].HeaderText = "Dirección";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Teléfono";
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = clienteBusiness.Buscar(TxtBuscar.Text.Trim());
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
            TxtDireccion.Clear();
            TxtTelefono.Clear();
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

        private void DgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnIngresar.Visible = false;
                BtnConfirmar.Visible = false;
                BtnCargar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["IdCliente"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["NombreApellido"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.NombreApellido = TxtNombre.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Telefono = TxtTelefono.Text;
                borradorCliente.Add(cliente);

                MessageBox.Show("Cliente cargado en la Lista");
                this.Listar();
                TxtDireccion.Clear();
                TxtNombre.Clear();
                TxtTelefono.Clear();

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
                if (borradorCliente.Count == 0)
                {
                    throw new Exception("La Lista esta vacia!!");
                }
                clienteBusiness.CargaVarios(borradorCliente);
                MessageBox.Show("Clientes confirmados correctamente");
                borradorCliente = new List<Cliente>();
                this.Listar();
                TabGeneral.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            borradorCliente = new List<Cliente>();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.NombreApellido = TxtNombre.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Telefono = TxtTelefono.Text;
                clienteBusiness.Carga(cliente);
                MessageBox.Show("Cliente cargado correctamente");
                this.Listar();
                TxtDireccion.Clear();
                TxtNombre.Clear();
                TxtTelefono.Clear();
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
                clienteBusiness.Actualizar(Convert.ToInt32(TxtId.Text), TxtNombre.Text, TxtDireccion.Text, TxtTelefono.Text);
                this.Listar();
                MessageBox.Show("El cliente se actualizó de forma correta");
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
                            clienteBusiness.Eliminar(Codigo);
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

        // Los metodos de Activa y Desactiva se de dejan por alguna implementacion futura 
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
                            clienteBusiness.Activar(Codigo);
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
                            clienteBusiness.Desactivar(Codigo);
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
