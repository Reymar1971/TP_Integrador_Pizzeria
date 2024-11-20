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
    public partial class FrmPedido : Form
    {
        PedidoBusinss pedidoBusiness = new PedidoBusinss();
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        ProductoBusiness productoBusiness = new ProductoBusiness();

        public FrmPedido()
        {
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TabGeneral.SelectedIndex = 1;
        }

        private void FormatoProductos()
        {
            DgvProductos.Columns[0].Visible = false;
            DgvProductos.Columns[1].Width = 120;
            DgvProductos.Columns[1].HeaderText = "Código";
            DgvProductos.Columns[2].Width = 200;
            DgvProductos.Columns[2].HeaderText = "Nombre";
            DgvProductos.Columns[3].Width = 100;
            DgvProductos.Columns[3].HeaderText = "Precio Venta";
            DgvProductos.Columns[4].Width = 80;
            DgvProductos.Columns[4].HeaderText = "Stock";
            DgvProductos.Columns[5].Width = 80;
            DgvProductos.Columns[5].HeaderText = "Estado";
            DgvProductos.Columns[6].Visible = false;
            DgvProductos.Columns[7].Visible = false;

        }

        private void BuscarProductos()
        {
            try
            {
                DgvProductos.DataSource = productoBusiness.Buscar(TxtBuscarProductos.Text.Trim());
                this.FormatoProductos();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void VerificarYActualizarCliente()
        {
            try
            {
                string numeroTelefono = TxtBuscar.Text;

                Cliente cliente = pedidoBusiness.ObtenerClientePorTelefono(numeroTelefono);

                if (cliente != null)
                {
                    TxtNombre.Text = cliente.NombreApellido;
                    TxtDireccion.Text = cliente.Direccion;
                    TxtId.Text = Convert.ToInt32(cliente.IdCliente).ToString();
                    MessageBox.Show("Cliente encontrado y datos cargados.");
                    BtncargaCliente.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El número de teléfono no existe en la base de datos; complete los datos y pulse Carga Cliente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void TxtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VerificarYActualizarCliente();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnCancelaCliente_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtDireccion.Clear();
            TxtId.Clear();
            BtncargaCliente.Enabled = true;
        }

        // Uso todos los metodos de la entidad ClienteBusinner y ClienteDao para cargar 
        // el cliente a la base de datos.
        private void BtncargaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.NombreApellido = TxtNombre.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Telefono = TxtBuscar.Text;
                //cliente.IdCliente = Convert.ToInt32(TxtId.Text);
                clienteBusiness.Carga(cliente);
                MessageBox.Show("Cliente cargado correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkEnvio.Checked)
                {
                    TxtCostoEnvio.Text = "1500";
                }
                else
                {
                    TxtCostoEnvio.Text = "0";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtBuscarProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PanelProductos.Visible = true;
                    BuscarProductos();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrarPanel_Click(object sender, EventArgs e)
        {
            PanelProductos.Visible = false;
        }
    }
}
