namespace UI
{
    partial class FrmProducto
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
            label3 = new Label();
            tabPage2 = new TabPage();
            CmbCategoria = new ComboBox();
            label5 = new Label();
            TxtCodigo = new TextBox();
            label4 = new Label();
            TxtStock = new TextBox();
            BtnCargar = new Button();
            TxtPrecioVenta = new TextBox();
            BtnConfirmar = new Button();
            TxtId = new TextBox();
            BtnActualizar = new Button();
            TxtNombre = new TextBox();
            BtnCancelar = new Button();
            label1 = new Label();
            BtnIngresar = new Button();
            label2 = new Label();
            LblTotal = new Label();
            BtnEliminar = new Button();
            BtnCancelaBuscar = new Button();
            tabPage1 = new TabPage();
            BtnDesactivar = new Button();
            BtnActivar = new Button();
            ChkSeleccionar = new CheckBox();
            BtnBuscar = new Button();
            TxtBuscar = new TextBox();
            DgvListado = new DataGridView();
            Seleccionar = new DataGridViewCheckBoxColumn();
            TabGeneral = new TabControl();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).BeginInit();
            TabGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 162);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 13;
            label3.Text = "Stock:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(CmbCategoria);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(TxtCodigo);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(TxtStock);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(BtnCargar);
            tabPage2.Controls.Add(TxtPrecioVenta);
            tabPage2.Controls.Add(BtnConfirmar);
            tabPage2.Controls.Add(TxtId);
            tabPage2.Controls.Add(BtnActualizar);
            tabPage2.Controls.Add(TxtNombre);
            tabPage2.Controls.Add(BtnCancelar);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(BtnIngresar);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 437);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mantenimiento";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // CmbCategoria
            // 
            CmbCategoria.FormattingEnabled = true;
            CmbCategoria.Location = new Point(142, 196);
            CmbCategoria.Name = "CmbCategoria";
            CmbCategoria.Size = new Size(200, 23);
            CmbCategoria.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 202);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 17;
            label5.Text = "Categoría:";
            // 
            // TxtCodigo
            // 
            TxtCodigo.Location = new Point(142, 23);
            TxtCodigo.Name = "TxtCodigo";
            TxtCodigo.Size = new Size(200, 23);
            TxtCodigo.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 73);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 15;
            label4.Text = "Nombre:";
            // 
            // TxtStock
            // 
            TxtStock.Location = new Point(200, 154);
            TxtStock.Name = "TxtStock";
            TxtStock.Size = new Size(142, 23);
            TxtStock.TabIndex = 14;
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(413, 325);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(75, 23);
            BtnCargar.TabIndex = 12;
            BtnCargar.Text = "Cargar";
            BtnCargar.UseVisualStyleBackColor = true;
            BtnCargar.Click += BtnCargar_Click;
            // 
            // TxtPrecioVenta
            // 
            TxtPrecioVenta.Location = new Point(200, 110);
            TxtPrecioVenta.Name = "TxtPrecioVenta";
            TxtPrecioVenta.Size = new Size(142, 23);
            TxtPrecioVenta.TabIndex = 11;
            // 
            // BtnConfirmar
            // 
            BtnConfirmar.Location = new Point(292, 325);
            BtnConfirmar.Name = "BtnConfirmar";
            BtnConfirmar.Size = new Size(75, 23);
            BtnConfirmar.TabIndex = 10;
            BtnConfirmar.Text = "Confirmar";
            BtnConfirmar.UseVisualStyleBackColor = true;
            BtnConfirmar.Click += BtnConfirmar_Click;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(534, 6);
            TxtId.Name = "TxtId";
            TxtId.ReadOnly = true;
            TxtId.Size = new Size(100, 23);
            TxtId.TabIndex = 9;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Location = new Point(170, 325);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(75, 23);
            BtnActualizar.TabIndex = 8;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.UseVisualStyleBackColor = true;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(95, 65);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(247, 23);
            TxtNombre.TabIndex = 3;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(529, 325);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 23);
            BtnCancelar.TabIndex = 7;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 31);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // BtnIngresar
            // 
            BtnIngresar.Location = new Point(170, 325);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(75, 23);
            BtnIngresar.TabIndex = 6;
            BtnIngresar.Text = "Ingresar";
            BtnIngresar.UseVisualStyleBackColor = true;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 118);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Precio de Venta:";
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
            // BtnCancelaBuscar
            // 
            BtnCancelaBuscar.Location = new Point(488, 19);
            BtnCancelaBuscar.Name = "BtnCancelaBuscar";
            BtnCancelaBuscar.Size = new Size(118, 23);
            BtnCancelaBuscar.TabIndex = 12;
            BtnCancelaBuscar.Text = "Cancela Busqueda";
            BtnCancelaBuscar.UseVisualStyleBackColor = true;
            BtnCancelaBuscar.Click += BtnCancelaBuscar_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnCancelaBuscar);
            tabPage1.Controls.Add(BtnEliminar);
            tabPage1.Controls.Add(BtnDesactivar);
            tabPage1.Controls.Add(BtnActivar);
            tabPage1.Controls.Add(ChkSeleccionar);
            tabPage1.Controls.Add(BtnBuscar);
            tabPage1.Controls.Add(TxtBuscar);
            tabPage1.Controls.Add(LblTotal);
            tabPage1.Controls.Add(DgvListado);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 437);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnDesactivar
            // 
            BtnDesactivar.Location = new Point(257, 386);
            BtnDesactivar.Name = "BtnDesactivar";
            BtnDesactivar.Size = new Size(75, 23);
            BtnDesactivar.TabIndex = 10;
            BtnDesactivar.Text = "Desactivar";
            BtnDesactivar.UseVisualStyleBackColor = true;
            BtnDesactivar.Click += BtnDesactivar_Click;
            // 
            // BtnActivar
            // 
            BtnActivar.Location = new Point(144, 385);
            BtnActivar.Name = "BtnActivar";
            BtnActivar.Size = new Size(75, 23);
            BtnActivar.TabIndex = 9;
            BtnActivar.Text = "Activar";
            BtnActivar.UseVisualStyleBackColor = true;
            BtnActivar.Click += BtnActivar_Click;
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
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(398, 19);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 7;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(16, 19);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(367, 23);
            TxtBuscar.TabIndex = 6;
            // 
            // DgvListado
            // 
            DgvListado.AllowUserToAddRows = false;
            DgvListado.AllowUserToDeleteRows = false;
            DgvListado.BackgroundColor = Color.AntiqueWhite;
            DgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListado.Columns.AddRange(new DataGridViewColumn[] { Seleccionar });
            DgvListado.Location = new Point(16, 54);
            DgvListado.Name = "DgvListado";
            DgvListado.ReadOnly = true;
            DgvListado.Size = new Size(721, 316);
            DgvListado.TabIndex = 4;
            DgvListado.CellContentClick += DgvListado_CellContentClick;
            DgvListado.CellContentDoubleClick += DgvListado_CellContentDoubleClick;
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.Name = "Seleccionar";
            Seleccionar.ReadOnly = true;
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(tabPage1);
            TabGeneral.Controls.Add(tabPage2);
            TabGeneral.Location = new Point(2, 5);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.SelectedIndex = 0;
            TabGeneral.Size = new Size(800, 465);
            TabGeneral.TabIndex = 11;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 477);
            Controls.Add(TabGeneral);
            Name = "FrmProducto";
            Text = "Productos";
            Load += FrmProducto_Load;
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).EndInit();
            TabGeneral.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private TabPage tabPage2;
        private TextBox TxtStock;
        private Button BtnCargar;
        private TextBox TxtPrecioVenta;
        private Button BtnConfirmar;
        private TextBox TxtId;
        private Button BtnActualizar;
        private TextBox TxtNombre;
        private Button BtnCancelar;
        private Label label1;
        private Button BtnIngresar;
        private Label label2;
        private Label LblTotal;
        private Button BtnEliminar;
        private Button BtnCancelaBuscar;
        private TabPage tabPage1;
        private Button BtnDesactivar;
        private Button BtnActivar;
        private CheckBox ChkSeleccionar;
        private Button BtnBuscar;
        private TextBox TxtBuscar;
        private DataGridView DgvListado;
        private DataGridViewCheckBoxColumn Seleccionar;
        private TabControl TabGeneral;
        private TextBox TxtCodigo;
        private Label label4;
        private ComboBox CmbCategoria;
        private Label label5;
    }
}