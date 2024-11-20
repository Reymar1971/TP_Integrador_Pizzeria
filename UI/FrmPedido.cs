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
        public FrmPedido()
        {
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TabGeneral.SelectedIndex = 1;
        }

        // Busqueda de el cliente en la base de datos, si no esta se da de alta

        private void VerificarNumeroTelefono()
        {
            string numeroTelefono = TxtTelefono.Text;
            ClienteBusiness clienteBusiness = new ClienteBusiness();

            if (clienteBusiness.ExisteNumeroTelefono(numeroTelefono))
            {
                //TxtNombre.Text = 
                MessageBox.Show("El número de teléfono ya existe en la base de datos.");
            }
            else
            {
                MessageBox.Show("El número de teléfono no existe en la base de datos.");
            }
        }

        private void TxtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VerificarNumeroTelefono();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        

    }
}
