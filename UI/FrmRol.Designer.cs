namespace UI
{
    partial class FrmRol
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
            LblTotal = new Label();
            DgvListado = new DataGridView();
            TabGeneral.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).BeginInit();
            SuspendLayout();
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(tabPage1);
            TabGeneral.Location = new Point(12, 12);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.SelectedIndex = 0;
            TabGeneral.Size = new Size(434, 368);
            TabGeneral.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(LblTotal);
            tabPage1.Controls.Add(DgvListado);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(426, 340);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblTotal
            // 
            LblTotal.AutoSize = true;
            LblTotal.Location = new Point(242, 316);
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
            DgvListado.Location = new Point(6, 6);
            DgvListado.Name = "DgvListado";
            DgvListado.ReadOnly = true;
            DgvListado.Size = new Size(414, 277);
            DgvListado.TabIndex = 4;
            // 
            // FrmRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 396);
            Controls.Add(TabGeneral);
            Name = "FrmRol";
            Text = "Roles";
            Load += FrmRol_Load;
            TabGeneral.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabGeneral;
        private TabPage tabPage1;
        private Label LblTotal;
        private DataGridView DgvListado;
    }
}