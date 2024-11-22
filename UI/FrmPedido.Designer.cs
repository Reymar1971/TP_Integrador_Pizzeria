namespace UI
{
    partial class FrmPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabGeneral = new TabControl();
            tabPage1 = new TabPage();
            BtnCancelaBuscar = new Button();
            BtnEliminar = new Button();
            BtnDesactivar = new Button();
            BtnActivar = new Button();
            ChkSeleccionar = new CheckBox();
            BtnBuscarPedido = new Button();
            TxtBuscarPedido = new TextBox();
            LblTotal = new Label();
            DgvListado = new DataGridView();
            Seleccionar = new DataGridViewCheckBoxColumn();
            tabPage2 = new TabPage();
            groupBox2 = new GroupBox();
            PanelProductos = new Panel();
            BtnCerrarPanel = new Button();
            DgvProductos = new DataGridView();
            ChkEnvio = new CheckBox();
            TxtTotal = new TextBox();
            TxtCostoEnvio = new TextBox();
            TxtSubTotal = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            TxtBuscarProductos = new TextBox();
            DgvDetalle = new DataGridView();
            BtnCancelar = new Button();
            BtnConfirmar = new Button();
            groupBox1 = new GroupBox();
            BtnCancelaCliente = new Button();
            BtncargaCliente = new Button();
            label4 = new Label();
            TxtBuscar = new TextBox();
            label3 = new Label();
            TxtDireccion = new TextBox();
            TxtId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtNombre = new TextBox();
            TabGeneral.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            PanelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvDetalle).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(tabPage1);
            TabGeneral.Controls.Add(tabPage2);
            TabGeneral.Location = new Point(6, 6);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.SelectedIndex = 0;
            TabGeneral.Size = new Size(800, 523);
            TabGeneral.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnCancelaBuscar);
            tabPage1.Controls.Add(BtnEliminar);
            tabPage1.Controls.Add(BtnDesactivar);
            tabPage1.Controls.Add(BtnActivar);
            tabPage1.Controls.Add(ChkSeleccionar);
            tabPage1.Controls.Add(BtnBuscarPedido);
            tabPage1.Controls.Add(TxtBuscarPedido);
            tabPage1.Controls.Add(LblTotal);
            tabPage1.Controls.Add(DgvListado);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 495);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnCancelaBuscar
            // 
            BtnCancelaBuscar.Location = new Point(488, 19);
            BtnCancelaBuscar.Name = "BtnCancelaBuscar";
            BtnCancelaBuscar.Size = new Size(118, 23);
            BtnCancelaBuscar.TabIndex = 12;
            BtnCancelaBuscar.Text = "Cancela Busqueda";
            BtnCancelaBuscar.UseVisualStyleBackColor = true;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(373, 386);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(75, 23);
            BtnEliminar.TabIndex = 11;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnDesactivar
            // 
            BtnDesactivar.Enabled = false;
            BtnDesactivar.Location = new Point(257, 386);
            BtnDesactivar.Name = "BtnDesactivar";
            BtnDesactivar.Size = new Size(75, 23);
            BtnDesactivar.TabIndex = 10;
            BtnDesactivar.Text = "Desactivar";
            BtnDesactivar.UseVisualStyleBackColor = true;
            // 
            // BtnActivar
            // 
            BtnActivar.Enabled = false;
            BtnActivar.Location = new Point(144, 385);
            BtnActivar.Name = "BtnActivar";
            BtnActivar.Size = new Size(75, 23);
            BtnActivar.TabIndex = 9;
            BtnActivar.Text = "Activar";
            BtnActivar.UseVisualStyleBackColor = true;
            // 
            // ChkSeleccionar
            // 
            ChkSeleccionar.AutoSize = true;
            ChkSeleccionar.Location = new Point(25, 398);
            ChkSeleccionar.Name = "ChkSeleccionar";
            ChkSeleccionar.Size = new Size(86, 19);
            ChkSeleccionar.TabIndex = 8;
            ChkSeleccionar.Text = "Seleccionar";
            ChkSeleccionar.UseVisualStyleBackColor = true;
            ChkSeleccionar.CheckedChanged += ChkSeleccionar_CheckedChanged;
            // 
            // BtnBuscarPedido
            // 
            BtnBuscarPedido.Location = new Point(398, 19);
            BtnBuscarPedido.Name = "BtnBuscarPedido";
            BtnBuscarPedido.Size = new Size(75, 23);
            BtnBuscarPedido.TabIndex = 7;
            BtnBuscarPedido.Text = "Buscar";
            BtnBuscarPedido.UseVisualStyleBackColor = true;
            // 
            // TxtBuscarPedido
            // 
            TxtBuscarPedido.Location = new Point(14, 19);
            TxtBuscarPedido.Name = "TxtBuscarPedido";
            TxtBuscarPedido.Size = new Size(367, 23);
            TxtBuscarPedido.TabIndex = 6;
            // 
            // LblTotal
            // 
            LblTotal.AutoSize = true;
            LblTotal.Location = new Point(570, 401);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(32, 15);
            LblTotal.TabIndex = 5;
            LblTotal.Text = "Total";
            // 
            // DgvListado
            // 
            DgvListado.AllowUserToAddRows = false;
            DgvListado.AllowUserToDeleteRows = false;
            DgvListado.BackgroundColor = Color.AntiqueWhite;
            DgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListado.Columns.AddRange(new DataGridViewColumn[] { Seleccionar });
            DgvListado.Location = new Point(12, 54);
            DgvListado.Name = "DgvListado";
            DgvListado.ReadOnly = true;
            DgvListado.Size = new Size(770, 316);
            DgvListado.TabIndex = 4;
            DgvListado.CellContentClick += DgvListado_CellContentClick;
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.Name = "Seleccionar";
            Seleccionar.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 495);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Pedidos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PanelProductos);
            groupBox2.Controls.Add(ChkEnvio);
            groupBox2.Controls.Add(TxtTotal);
            groupBox2.Controls.Add(TxtCostoEnvio);
            groupBox2.Controls.Add(TxtSubTotal);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(TxtBuscarProductos);
            groupBox2.Controls.Add(DgvDetalle);
            groupBox2.Controls.Add(BtnCancelar);
            groupBox2.Controls.Add(BtnConfirmar);
            groupBox2.Location = new Point(17, 143);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(752, 344);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pedido";
            // 
            // PanelProductos
            // 
            PanelProductos.BackColor = Color.PaleGreen;
            PanelProductos.Controls.Add(BtnCerrarPanel);
            PanelProductos.Controls.Add(DgvProductos);
            PanelProductos.Location = new Point(98, 59);
            PanelProductos.Name = "PanelProductos";
            PanelProductos.Size = new Size(654, 231);
            PanelProductos.TabIndex = 24;
            PanelProductos.Visible = false;
            // 
            // BtnCerrarPanel
            // 
            BtnCerrarPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCerrarPanel.ForeColor = Color.OrangeRed;
            BtnCerrarPanel.Location = new Point(599, 4);
            BtnCerrarPanel.Name = "BtnCerrarPanel";
            BtnCerrarPanel.Size = new Size(45, 22);
            BtnCerrarPanel.TabIndex = 1;
            BtnCerrarPanel.Text = "X";
            BtnCerrarPanel.UseVisualStyleBackColor = true;
            BtnCerrarPanel.Click += BtnCerrarPanel_Click;
            // 
            // DgvProductos
            // 
            DgvProductos.AllowUserToAddRows = false;
            DgvProductos.AllowUserToDeleteRows = false;
            DgvProductos.BackgroundColor = Color.DarkSeaGreen;
            DgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProductos.Location = new Point(16, 31);
            DgvProductos.Name = "DgvProductos";
            DgvProductos.ReadOnly = true;
            DgvProductos.Size = new Size(622, 182);
            DgvProductos.TabIndex = 0;
            DgvProductos.CellDoubleClick += DgvProductos_CellDoubleClick;
            // 
            // ChkEnvio
            // 
            ChkEnvio.AutoSize = true;
            ChkEnvio.Location = new Point(652, 18);
            ChkEnvio.Name = "ChkEnvio";
            ChkEnvio.Size = new Size(80, 19);
            ChkEnvio.TabIndex = 23;
            ChkEnvio.Text = "Con Envío";
            ChkEnvio.UseVisualStyleBackColor = true;
            ChkEnvio.CheckedChanged += ChkEnvio_CheckedChanged;
            // 
            // TxtTotal
            // 
            TxtTotal.BackColor = SystemColors.InactiveCaption;
            TxtTotal.Enabled = false;
            TxtTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtTotal.ForeColor = Color.Black;
            TxtTotal.Location = new Point(646, 317);
            TxtTotal.Name = "TxtTotal";
            TxtTotal.Size = new Size(93, 27);
            TxtTotal.TabIndex = 21;
            // 
            // TxtCostoEnvio
            // 
            TxtCostoEnvio.BackColor = SystemColors.InactiveCaption;
            TxtCostoEnvio.Enabled = false;
            TxtCostoEnvio.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtCostoEnvio.Location = new Point(646, 293);
            TxtCostoEnvio.Name = "TxtCostoEnvio";
            TxtCostoEnvio.Size = new Size(93, 22);
            TxtCostoEnvio.TabIndex = 20;
            TxtCostoEnvio.Text = "0";
            TxtCostoEnvio.KeyDown += TxtCostoEnvio_KeyDown;
            // 
            // TxtSubTotal
            // 
            TxtSubTotal.BackColor = SystemColors.InactiveCaption;
            TxtSubTotal.Enabled = false;
            TxtSubTotal.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSubTotal.Location = new Point(646, 268);
            TxtSubTotal.Name = "TxtSubTotal";
            TxtSubTotal.Size = new Size(93, 22);
            TxtSubTotal.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(568, 323);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 18;
            label8.Text = "Total             $";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(567, 299);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 17;
            label7.Text = "Costo Envío $";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(568, 272);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 16;
            label6.Text = "SubTotal       $";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 22);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 15;
            label5.Text = "Buscar productos";
            // 
            // TxtBuscarProductos
            // 
            TxtBuscarProductos.Location = new Point(124, 15);
            TxtBuscarProductos.Name = "TxtBuscarProductos";
            TxtBuscarProductos.Size = new Size(391, 23);
            TxtBuscarProductos.TabIndex = 14;
            TxtBuscarProductos.KeyDown += TxtBuscarProductos_KeyDown;
            // 
            // DgvDetalle
            // 
            DgvDetalle.AllowUserToAddRows = false;
            DgvDetalle.BackgroundColor = Color.AntiqueWhite;
            DgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDetalle.Location = new Point(17, 44);
            DgvDetalle.Name = "DgvDetalle";
            DgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetalle.Size = new Size(722, 222);
            DgvDetalle.TabIndex = 13;
            DgvDetalle.CellEndEdit += DgvDetalle_CellEndEdit;
            DgvDetalle.RowsRemoved += DgvDetalle_RowsRemoved;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(378, 315);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 23);
            BtnCancelar.TabIndex = 7;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnConfirmar
            // 
            BtnConfirmar.Location = new Point(187, 315);
            BtnConfirmar.Name = "BtnConfirmar";
            BtnConfirmar.Size = new Size(75, 23);
            BtnConfirmar.TabIndex = 10;
            BtnConfirmar.Text = "Confirmar";
            BtnConfirmar.UseVisualStyleBackColor = true;
            BtnConfirmar.Click += BtnConfirmar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnCancelaCliente);
            groupBox1.Controls.Add(BtncargaCliente);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TxtBuscar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TxtDireccion);
            groupBox1.Controls.Add(TxtId);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TxtNombre);
            groupBox1.Location = new Point(17, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(752, 132);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cliente";
            // 
            // BtnCancelaCliente
            // 
            BtnCancelaCliente.Location = new Point(550, 92);
            BtnCancelaCliente.Name = "BtnCancelaCliente";
            BtnCancelaCliente.Size = new Size(96, 23);
            BtnCancelaCliente.TabIndex = 17;
            BtnCancelaCliente.Text = "Cancela";
            BtnCancelaCliente.UseVisualStyleBackColor = true;
            BtnCancelaCliente.Click += BtnCancelaCliente_Click;
            // 
            // BtncargaCliente
            // 
            BtncargaCliente.Location = new Point(412, 93);
            BtncargaCliente.Name = "BtncargaCliente";
            BtncargaCliente.Size = new Size(103, 23);
            BtncargaCliente.TabIndex = 16;
            BtncargaCliente.Text = "Carga Cliente";
            BtncargaCliente.UseVisualStyleBackColor = true;
            BtncargaCliente.Click += BtncargaCliente_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(625, 19);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 15;
            label4.Text = "ID:";
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(177, 28);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(197, 23);
            TxtBuscar.TabIndex = 14;
            TxtBuscar.KeyDown += TxtTelefono_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 36);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 13;
            label3.Text = "Teléfono";
            // 
            // TxtDireccion
            // 
            TxtDireccion.Location = new Point(74, 93);
            TxtDireccion.Name = "TxtDireccion";
            TxtDireccion.Size = new Size(300, 23);
            TxtDireccion.TabIndex = 11;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(652, 12);
            TxtId.Name = "TxtId";
            TxtId.ReadOnly = true;
            TxtId.Size = new Size(76, 23);
            TxtId.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 67);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre y Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 100);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Diección";
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(127, 58);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(247, 23);
            TxtNombre.TabIndex = 3;
            // 
            // FrmPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 530);
            Controls.Add(TabGeneral);
            Name = "FrmPedido";
            Text = "Pedidos - Ventas";
            Load += FrmPedido_Load;
            TabGeneral.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            PanelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvDetalle).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabGeneral;
        private TabPage tabPage1;
        private Button BtnCancelaBuscar;
        private Button BtnEliminar;
        private Button BtnDesactivar;
        private Button BtnActivar;
        private CheckBox ChkSeleccionar;
        private Button BtnBuscarPedido;
        private TextBox TxtBuscarPedido;
        private Label LblTotal;
        private DataGridView DgvListado;
        private DataGridViewCheckBoxColumn Seleccionar;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private TextBox TxtBuscar;
        private Label label3;
        private TextBox TxtDireccion;
        private Button BtnConfirmar;
        private TextBox TxtId;
        private TextBox TxtNombre;
        private Button BtnCancelar;
        private Label label1;
        private Label label2;
        private Button BtncargaCliente;
        private Label label4;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox TxtBuscarProductos;
        private DataGridView DgvDetalle;
        private Button BtnCancelaCliente;
        private TextBox TxtSubTotal;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox TxtTotal;
        private TextBox TxtCostoEnvio;
        private CheckBox ChkEnvio;
        private Panel PanelProductos;
        private DataGridView DgvProductos;
        private Button BtnCerrarPanel;
    }
}