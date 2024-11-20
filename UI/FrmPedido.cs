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

        public FrmPedido()
        {
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TabGeneral.SelectedIndex = 1;
        }

        // Busqueda de el cliente en la base de datos, si no esta se da de alta

        //private void VerificarNumeroTelefono()
        //{
        //    string numeroTelefono = TxtBuscar.Text;
        //    ClienteBusiness clienteBusiness = new ClienteBusiness();

        //    if (clienteBusiness.ExisteNumeroTelefono(numeroTelefono))
        //    {
        //        MessageBox.Show("El número de teléfono ya existe en la base de datos.");


        //    }
        //    else
        //    {
        //        MessageBox.Show("El número de teléfono no existe en la base de datos.");
        //    }
        //}

        private void VerificarYActualizarCliente()
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

                throw;
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
                cliente.IdCliente = Convert.ToInt32(TxtId.Text);
                clienteBusiness.Carga(cliente);
                MessageBox.Show("Cliente cargado correctamente");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
