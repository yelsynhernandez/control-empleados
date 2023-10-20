namespace ProyectoYaya
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DgvEmpleados = new DataGridView();
            BtnCerrar = new Button();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            agregarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)DgvEmpleados).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DgvEmpleados
            // 
            DgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmpleados.Location = new Point(14, 25);
            DgvEmpleados.Name = "DgvEmpleados";
            DgvEmpleados.RowTemplate.Height = 25;
            DgvEmpleados.Size = new Size(1067, 357);
            DgvEmpleados.TabIndex = 0;
            DgvEmpleados.CellDoubleClick += DgvEmpleados_CellDoubleClick;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(997, 392);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(86, 25);
            BtnCerrar.TabIndex = 1;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1095, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarEmpleadoToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(64, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // agregarEmpleadoToolStripMenuItem
            // 
            agregarEmpleadoToolStripMenuItem.Name = "agregarEmpleadoToolStripMenuItem";
            agregarEmpleadoToolStripMenuItem.Size = new Size(190, 22);
            agregarEmpleadoToolStripMenuItem.Text = "Agregar empleado";
            agregarEmpleadoToolStripMenuItem.Click += agregarEmpleadoToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 429);
            Controls.Add(BtnCerrar);
            Controls.Add(DgvEmpleados);
            Controls.Add(menuStrip1);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de empleados";
            Load += FrmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)DgvEmpleados).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvEmpleados;
        private Button BtnCerrar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem agregarEmpleadoToolStripMenuItem;
    }
}