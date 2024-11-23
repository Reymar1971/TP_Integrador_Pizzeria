using Entity;

namespace UI
{
    public partial class FrmDetallePedido : Form
    {
        private Pedido pedido; 
        private DataGridView DgvDetalle; 

        public FrmDetallePedido(Pedido pedido)
        {
            InitializeComponent();
            this.pedido = pedido; 
            this.DgvDetalle = new DataGridView(); 
            this.Controls.Add(DgvDetalle); 
                                           
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

        private void AjustarTamañoFormulario()
        {
            int anchoTotalColumnas = 0;

            foreach (DataGridViewColumn columna in DgvDetalle.Columns)
            {
                if (columna.Visible)
                {
                    anchoTotalColumnas += columna.Width;
                }
            }

            this.Width = anchoTotalColumnas + DgvDetalle.RowHeadersWidth + 18; 
        }

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {
                        
            DgvDetalle.DataSource = pedido.Detalle;
            this.Formato();
                                    
            int rowHeight = DgvDetalle.RowTemplate.Height;
            int totalHeight = rowHeight * pedido.Detalle.Count + DgvDetalle.ColumnHeadersHeight;
            this.Height = totalHeight + 50; 

            
            DgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int totalWidth = 0;
            foreach (DataGridViewColumn column in DgvDetalle.Columns)
            {
                totalWidth += column.Width;
            }
            DgvDetalle.Width = totalWidth + DgvDetalle.RowHeadersWidth + 2; 
            this.Width = DgvDetalle.Width; 

            AjustarTamañoFormulario();
        }
    }
}
