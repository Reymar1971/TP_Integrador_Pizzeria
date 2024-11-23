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
    public partial class FrmDetallePedido : Form
    {
        private Pedido pedido; // Agregar campo para almacenar el pedido
        private DataGridView DgvDetalle; // Agregar campo para el DataGridView

        public FrmDetallePedido(Pedido pedido)
        {
            InitializeComponent();
            this.pedido = pedido; // Asignar el pedido al campo
            this.DgvDetalle = new DataGridView(); // Inicializar el DataGridView
            this.Controls.Add(DgvDetalle); // Agregar el DataGridView al formulario
                                           //CargarDetallePedido(pedido);
        }

        private void Formato()
        {
            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].Width = 80;
            DgvDetalle.Columns[1].HeaderText = "Cantidad";
            DgvDetalle.Columns[2].Width = 250;
            DgvDetalle.Columns[2].HeaderText = "Precio unitario";
            DgvDetalle.Columns[3].Visible = false;
            DgvDetalle.Columns[4].Width = 250;
            DgvDetalle.Columns[4].HeaderText = "Nombre Producto";
            DgvDetalle.Columns[5].Visible = false;
        }

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {
            
            // Asignar los detalles del pedido al DataGridView u otro control
            DgvDetalle.DataSource = pedido.Detalle;
            this.Formato();

            // Ajustar el tamaño del formulario según la cantidad de productos
            int rowHeight = DgvDetalle.RowTemplate.Height;
            int totalHeight = rowHeight * pedido.Detalle.Count + DgvDetalle.ColumnHeadersHeight;
            this.Height = totalHeight + 50; // Ajusta 50 según sea necesario 

            // Ajustar el ancho del DataGridView y del formulario según el ancho total de las columnas
            DgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int totalWidth = 0;
            foreach (DataGridViewColumn column in DgvDetalle.Columns)
            {
                totalWidth += column.Width;
            }
            DgvDetalle.Width = totalWidth + DgvDetalle.RowHeadersWidth + 2; // Ajusta según sea necesario
            this.Width = DgvDetalle.Width; // Ajusta 50 según sea necesario
        }
    }
}
