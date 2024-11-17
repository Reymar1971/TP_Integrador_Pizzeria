namespace UI
{
    partial class FrmCategoria
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
            BtnConfirmar = new Button();
            BtnActualizar = new Button();
            tabPage2 = new TabPage();
            TxtDescripcion = new TextBox();
            TxtId = new TextBox();
            TxtNombre = new TextBox();
            BtnCancelar = new Button();
            label1 = new Label();
            BtnIngresar = new Button();
            label2 = new Label();
            Seleccionar = new DataGridViewCheckBoxColumn();
            BtnCancelaBuscar = new Button();
            tabPage1 = new TabPage();
            BtnEliminar = new Button();
            BtnDesactivar = new Button();
            BtnActivar = new Button();
            ChkSeleccionar = new CheckBox();
            BtnBuscar = new Button();
            TxtBuscar = new TextBox();
            LblTotal = new Label();
            DgvListado = new DataGridView();
            TabGeneral = new TabControl();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).BeginInit();
            TabGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // BtnConfirmar
            // 
            BtnConfirmar.Location = new Point(373, 244);
            BtnConfirmar.Name = "BtnConfirmar";
            BtnConfirmar.Size = new Size(75, 23);
            BtnConfirmar.TabIndex = 10;
            BtnConfirmar.Text = "Confirmar";
            BtnConfirmar.UseVisualStyleBackColor = true;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Location = new Point(229, 244);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(75, 23);
            BtnActualizar.TabIndex = 8;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.UseVisualStyleBackColor = true;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TxtDescripcion);
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
            // TxtDescripcion
            // 
            TxtDescripcion.Location = new Point(93, 102);
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(333, 23);
            TxtDescripcion.TabIndex = 11;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(534, 6);
            TxtId.Name = "TxtId";
            TxtId.ReadOnly = true;
            TxtId.Size = new Size(100, 23);
            TxtId.TabIndex = 9;
            // 
            // TxtNombre
            // 
            TxtNombre.Location = new Point(179, 21);
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(247, 23);
            TxtNombre.TabIndex = 3;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(495, 244);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 23);
            BtnCancelar.TabIndex = 7;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 29);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // BtnIngresar
            // 
            BtnIngresar.Location = new Point(229, 244);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(75, 23);
            BtnIngresar.TabIndex = 6;
            BtnIngresar.Text = "Ingresar";
            BtnIngresar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 110);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción:";
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.Name = "Seleccionar";
            Seleccionar.ReadOnly = true;
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
            ChkSeleccionar.Location = new Point(19, 392);
            ChkSeleccionar.Name = "ChkSeleccionar";
            ChkSeleccionar.Size = new Size(86, 19);
            ChkSeleccionar.TabIndex = 8;
            ChkSeleccionar.Text = "Seleccionar";
            ChkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(398, 19);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 7;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(16, 19);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(367, 23);
            TxtBuscar.TabIndex = 6;
            // 
            // LblTotal
            // 
            LblTotal.AutoSize = true;
            LblTotal.Location = new Point(564, 395);
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
            DgvListado.CellContentClick += DgvListado_CellContentClick;
            DgvListado.CellContentDoubleClick += DgvListado_CellContentDoubleClick;
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(tabPage1);
            TabGeneral.Controls.Add(tabPage2);
            TabGeneral.Location = new Point(3, 4);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.SelectedIndex = 0;
            TabGeneral.Size = new Size(800, 465);
            TabGeneral.TabIndex = 9;
            // 
            // FrmCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 470);
            Controls.Add(TabGeneral);
            Name = "FrmCategoria";
            Text = "Categorias";
            Load += FrmCategoria_Load;
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).EndInit();
            TabGeneral.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnConfirmar;
        private Button BtnActualizar;
        private TabPage tabPage2;
        private TextBox TxtId;
        private TextBox TxtNombre;
        private Button BtnCancelar;
        private Label label1;
        private Button BtnIngresar;
        private Label label2;
        private DataGridViewCheckBoxColumn Seleccionar;
        private Button BtnCancelaBuscar;
        private TabPage tabPage1;
        private Button BtnEliminar;
        private Button BtnDesactivar;
        private Button BtnActivar;
        private CheckBox ChkSeleccionar;
        private Button BtnBuscar;
        private TextBox TxtBuscar;
        private Label LblTotal;
        private DataGridView DgvListado;
        private TabControl TabGeneral;
        private TextBox TxtDescripcion;
    }
}