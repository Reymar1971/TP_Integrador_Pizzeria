using BLL;
using Entity;
using System.Data;

namespace UI
{
    public partial class FrmPedido : Form
    {
        private DataTable DtDetalle = new DataTable();
        PedidoBusiness pedidoBusiness = new PedidoBusiness();
        ClienteBusiness clienteBusiness = new ClienteBusiness();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        DetallePedidoBusiness detallePedidoBusiness = new DetallePedidoBusiness();

        public FrmPedido()
        {
            InitializeComponent();
        }

        #region Metodos
        // Formato a la grilla que muestra los pedidos generados
        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Width = 80;
            DgvListado.Columns[1].HeaderText = "Pedido Nro.";
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[3].HeaderText = "Cliente";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Nro.Teléfono";
            DgvListado.Columns[5].Width = 80;
            DgvListado.Columns[5].HeaderText = "Cantidad";
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[6].HeaderText = "Fecha";
            DgvListado.Columns[7].Width = 100;
            DgvListado.Columns[7].HeaderText = "Total";
        }

        // Lista los pedidos generados 
        private void Listar()
        {
            try
            {
                //cambio color alternando las filas de la grilla
                this.DgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
                DgvListado.DataSource = pedidoBusiness.Listar();
                this.Formato();
                //this.Limpiar();
                LblTotal.Text = "Total de registros: " + Convert.ToString(DgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Procedimientos que afectan a la generacion de los pedidos
        private void Limpiar()
        {
            TxtId.Clear();
            TxtNombre.Clear();
            TxtDireccion.Clear();
            TxtBuscar.Clear();
            // Limpia el DataTable asociado al DataGridView
            DtDetalle.Clear();
            // Actualiza el DataGridView
            DgvDetalle.DataSource = DtDetalle;
            // Opcional: Recalcula los totales después de limpiar los detalles
            CalcularTotales();
        }

        private List<DetallePedido> ObtenerDetallePedido(DataTable dtDetalle)
        {
            List<DetallePedido> detallePedido = new List<DetallePedido>();
            foreach (DataRow row in dtDetalle.Rows)
            {
                DetallePedido detalle = new DetallePedido
                {
                    Producto = new Producto { IdProducto = Convert.ToInt32(row["idarticulo"]) },
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(row["precio"])
                };
                detallePedido.Add(detalle);
            }
            return detallePedido;
        }

        private int CalcularCantidadTotalProductos(DataTable dtDetalle)
        {
            int cantidadTotal = 0;

            foreach (DataRow row in dtDetalle.Rows)
            {
                cantidadTotal += Convert.ToInt32(row["cantidad"]);
            }

            return cantidadTotal;
        }

        private decimal CalcularMontoTotalPedido(DataTable dtDetalle)
        {
            decimal montoTotal = 0;

            foreach (DataRow row in dtDetalle.Rows)
            {
                montoTotal += Convert.ToDecimal(row["precio"]);
            }

            return montoTotal;
        }

        private void CrearTabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("codigo", Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("cantidad", Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("stock", Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("importe", Type.GetType("System.Decimal"));

            //cambio color alternando las filas de la grilla
            this.DgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
            DgvDetalle.DataSource = this.DtDetalle;

            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].HeaderText = "Código";
            DgvDetalle.Columns[1].Width = 100;
            DgvDetalle.Columns[2].HeaderText = "Producto";
            DgvDetalle.Columns[2].Width = 250;
            DgvDetalle.Columns[3].HeaderText = "Cantidad";
            DgvDetalle.Columns[3].Width = 80;
            DgvDetalle.Columns[4].HeaderText = "Precio";
            DgvDetalle.Columns[4].Width = 80;
            DgvDetalle.Columns[5].HeaderText = "Stock";
            DgvDetalle.Columns[5].Width = 70;
            DgvDetalle.Columns[6].HeaderText = "Importe";
            DgvDetalle.Columns[6].Width = 100;

            DgvDetalle.Columns[1].ReadOnly = true;
            DgvDetalle.Columns[2].ReadOnly = true;
            DgvDetalle.Columns[5].ReadOnly = true;
            DgvDetalle.Columns[6].ReadOnly = true;

        }

        private void AgregarDetalle(int IdArticulo, string Codigo, string Nombre, int Stock, Decimal Precio)
        {
            bool Agregar = true;
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false;
                    MessageBox.Show("El producto ya ha sido agredado al detalle");
                }

            }
            if (Agregar)
            {
                DataRow fila = DtDetalle.NewRow();
                fila["idarticulo"] = IdArticulo;
                fila["codigo"] = Codigo;
                fila["articulo"] = Nombre;
                fila["cantidad"] = 1;
                fila["precio"] = Precio;
                fila["stock"] = Stock;
                fila["importe"] = Precio;
                this.DtDetalle.Rows.Add(fila);
                this.CalcularTotales();
            }

        }

        private void CalcularTotales()
        {
            decimal Total = 0;
            decimal Subtotal = 0;
            decimal CostoEnvio = Convert.ToDecimal(TxtCostoEnvio.Text);

            try
            {
                foreach (DataRow FilaTem in DtDetalle.Rows)
                {
                    if (FilaTem.RowState != DataRowState.Deleted)
                    {
                        Subtotal += Convert.ToDecimal(FilaTem["Importe"]);
                    }
                }
            }
            catch (RowNotInTableException ex)
            {
                // Maneja la excepcion.
            }

            Total = Subtotal + CostoEnvio;
            TxtTotal.Text = Total.ToString("#0.00#");
            TxtSubTotal.Text = Subtotal.ToString("#0.00#");
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TabGeneral.SelectedIndex = 1;
            this.CrearTabla();
            TxtCostoEnvio.Enabled = false;
            this.Listar();
        }

        private void FormatoProductos()
        {
            //cambio color alternando las filas de la grilla
            this.DgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
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
                // Aqui se listan todos los productos que tengan stock
                DgvProductos.DataSource = pedidoBusiness.Buscar(TxtBuscarProductos.Text.Trim());
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

        private void MostrarDetallePedido(int pedidoId)
        {
            // Obtener el detalle del pedido por su ID
            List<DetallePedido> detallePedido = detallePedidoBusiness.ObtenerDetallePedidoPorId(pedidoId);

            // Crear una nueva instancia del pedido y asignar el detalle
            Pedido pedido = new Pedido
            {
                IdPedido = pedidoId,
                Detalle = detallePedido
            };

            // Crear una nueva instancia del formulario de detalles del pedido
            FrmDetallePedido frmDetalle = new FrmDetallePedido(pedido);

            // Mostrar el formulario
            frmDetalle.ShowDialog();
        }
        #endregion

        #region Eventos Click

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
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
                    TxtCostoEnvio.Enabled = true;
                }
                else
                {
                    TxtCostoEnvio.Enabled = false;
                    TxtCostoEnvio.Text = "0";
                    this.CalcularTotales();
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
            TxtBuscarProductos.Clear();
        }

        private void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo, Stock;
            string Codigo, Nombre;
            decimal Precio;
            IdArticulo = Convert.ToInt32(DgvProductos.CurrentRow.Cells[0].Value);
            Codigo = Convert.ToString(DgvProductos.CurrentRow.Cells[1].Value);
            Nombre = Convert.ToString(DgvProductos.CurrentRow.Cells[2].Value);
            Stock = Convert.ToInt32(DgvProductos.CurrentRow.Cells[4].Value);
            Precio = Convert.ToDecimal(DgvProductos.CurrentRow.Cells[3].Value);
            this.AgregarDetalle(IdArticulo, Codigo, Nombre, Stock, Precio);

        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            decimal Precio = Convert.ToDecimal(Fila["Precio"]);
            int Stock = Convert.ToInt32(Fila["Stock"]);
            int Cantidad = Convert.ToInt32(Fila["Cantidad"]);
            if (Cantidad > Stock)
            {
                MessageBox.Show("Stock insuficiente; controle la contidad!!!");
                Fila["Cantidad"] = 1;
            }
            Fila["Importe"] = Precio * Cantidad;
            this.CalcularTotales();
        }

        private void TxtCostoEnvio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.CalcularTotales();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Limpia el DataTable asociado al DataGridView
            DtDetalle.Clear();

            // Actualiza el DataGridView
            DgvDetalle.DataSource = DtDetalle;

            // Opcional: Recalcula los totales después de limpiar los detalles
            CalcularTotales();
        }

        private void DgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotales();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido.Detalle = new List<DetallePedido>();
                pedido.Detalle = ObtenerDetallePedido(DtDetalle);
                pedido.Cliente = new Cliente();
                pedido.Cliente.IdCliente = Convert.ToInt32(TxtId.Text);
                pedido.Fecha = DateTime.Now.Date;
                pedido.Cantidad = CalcularCantidadTotalProductos(DtDetalle);
                pedido.Total = CalcularMontoTotalPedido(DtDetalle);
                pedidoBusiness.Carga(pedido);
                MessageBox.Show("Pedido cargado correctamente");
                this.Limpiar();
                this.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                            pedidoBusiness.Eliminar(Codigo);
                            MessageBox.Show("Se elimino el pedido: " + Convert.ToString(row.Cells[1].Value));
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

        // Cueando doy click en los registros del listado de pedidos
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

        private void DgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int pedidoId = Convert.ToInt32(DgvListado.Rows[e.RowIndex].Cells["IdPedido"].Value);
                MostrarDetallePedido(pedidoId);
            }
        }
        #endregion


    }
}
