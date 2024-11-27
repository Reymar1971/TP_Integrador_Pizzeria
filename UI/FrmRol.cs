using BLL;
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
    public partial class FrmRol : Form
    {
        private RolBusiness rolBusiness = new RolBusiness();
        public FrmRol()
        {
            InitializeComponent();
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Listar()
        {
            try
            {
                //cambio color alternando las filas de la grilla
                this.DgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;

                DgvListado.DataSource = rolBusiness.Listar();
                this.Formato();
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
            DgvListado.Columns[1].Width = 110;
            DgvListado.Columns[1].HeaderText = "Nombre";
            DgvListado.Columns[2].Width = 450;
            DgvListado.Columns[2].HeaderText = "Descripción";
            
        }
    }
}
