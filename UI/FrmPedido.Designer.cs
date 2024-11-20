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
            BtnBuscarProducto = new Button();
            label5 = new Label();
            textBox1 = new TextBox();
            DgvPedido = new DataGridView();
            BtnActualizar = new Button();
            BtnIngresar = new Button();
            BtnCargar = new Button();
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
            ((System.ComponentModel.ISupportInitialize)DgvPedido).BeginInit();
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
            TxtBuscarPedido.Location = new Point(16, 19);
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
            DgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListado.Columns.AddRange(new DataGridViewColumn[] { Seleccionar });
            DgvListado.Location = new Point(16, 54);
            DgvListado.Name = "DgvListado";
            DgvListado.ReadOnly = true;
            DgvListado.Size = new Size(721, 316);
            DgvListado.TabIndex = 4;
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
            tabPage2.Text = "Mantenimiento";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnBuscarProducto);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(DgvPedido);
            groupBox2.Controls.Add(BtnActualizar);
            groupBox2.Controls.Add(BtnIngresar);
            groupBox2.Controls.Add(BtnCargar);
            groupBox2.Controls.Add(BtnCancelar);
            groupBox2.Controls.Add(BtnConfirmar);
            groupBox2.Location = new Point(17, 144);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(752, 344);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pedido";
            // 
            // BtnBuscarProducto
            // 
            BtnBuscarProducto.Location = new Point(318, 18);
            BtnBuscarProducto.Name = "BtnBuscarProducto";
            BtnBuscarProducto.Size = new Size(121, 23);
            BtnBuscarProducto.TabIndex = 16;
            BtnBuscarProducto.Text = "Buscar Producto";
            BtnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 26);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 15;
            label5.Text = "Código Producto:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 14;
            // 
            // DgvPedido
            // 
            DgvPedido.AllowUserToAddRows = false;
            DgvPedido.AllowUserToDeleteRows = false;
            DgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvPedido.Location = new Point(17, 47);
            DgvPedido.Name = "DgvPedido";
            DgvPedido.ReadOnly = true;
            DgvPedido.Size = new Size(722, 251);
            DgvPedido.TabIndex = 13;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Location = new Point(157, 314);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(75, 23);
            BtnActualizar.TabIndex = 8;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.UseVisualStyleBackColor = true;
            // 
            // BtnIngresar
            // 
            BtnIngresar.Location = new Point(157, 314);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(75, 23);
            BtnIngresar.TabIndex = 6;
            BtnIngresar.Text = "Ingresar";
            BtnIngresar.UseVisualStyleBackColor = true;
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(400, 314);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(75, 23);
            BtnCargar.TabIndex = 12;
            BtnCargar.Text = "Cargar";
            BtnCargar.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(516, 314);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 23);
            BtnCancelar.TabIndex = 7;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnConfirmar
            // 
            BtnConfirmar.Location = new Point(279, 314);
            BtnConfirmar.Name = "BtnConfirmar";
            BtnConfirmar.Size = new Size(75, 23);
            BtnConfirmar.TabIndex = 10;
            BtnConfirmar.Text = "Confirmar";
            BtnConfirmar.UseVisualStyleBackColor = true;
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
            label3.Size = new Size(55, 15);
            label3.TabIndex = 13;
            label3.Text = "Telefono:";
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
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre y Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 100);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Diección:";
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
            ((System.ComponentModel.ISupportInitialize)DgvPedido).EndInit();
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
        private Button BtnCargar;
        private TextBox TxtDireccion;
        private Button BtnConfirmar;
        private TextBox TxtId;
        private Button BtnActualizar;
        private TextBox TxtNombre;
        private Button BtnCancelar;
        private Label label1;
        private Button BtnIngresar;
        private Label label2;
        private Button BtncargaCliente;
        private Label label4;
        private GroupBox groupBox2;
        private Button BtnBuscarProducto;
        private Label label5;
        private TextBox textBox1;
        private DataGridView DgvPedido;
        private Button BtnCancelaCliente;
    }
}