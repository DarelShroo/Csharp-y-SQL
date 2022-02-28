namespace SQLMicrosfPROYECTO
{
    partial class Combobox
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
            this.lblHabitaciones = new System.Windows.Forms.Label();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegimenes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvEstancias = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCodHoteles = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize) (this.dgvHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvRegimenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvEstancias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHabitaciones
            // 
            this.lblHabitaciones.AutoSize = true;
            this.lblHabitaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblHabitaciones.Location = new System.Drawing.Point(240, 91);
            this.lblHabitaciones.Name = "lblHabitaciones";
            this.lblHabitaciones.Size = new System.Drawing.Size(153, 20);
            this.lblHabitaciones.TabIndex = 90;
            this.lblHabitaciones.Text = "Tabla Habitaciones";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(12, 114);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.Size = new System.Drawing.Size(662, 161);
            this.dgvHabitaciones.TabIndex = 89;
            this.dgvHabitaciones.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.beginValue);
            this.dgvHabitaciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.onChangeDataHabitaciones);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(504, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 29);
            this.label1.TabIndex = 101;
            this.label1.Text = "Darel Martínez Caballero";
            // 
            // dgvRegimenes
            // 
            this.dgvRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimenes.Location = new System.Drawing.Point(695, 114);
            this.dgvRegimenes.Name = "dgvRegimenes";
            this.dgvRegimenes.Size = new System.Drawing.Size(547, 161);
            this.dgvRegimenes.TabIndex = 103;
            this.dgvRegimenes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.onChangeDataRegimenes);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(918, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 105;
            this.label3.Text = "Tabla Regimenes";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(27, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 37);
            this.btnClose.TabIndex = 106;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvEstancias
            // 
            this.dgvEstancias.Location = new System.Drawing.Point(253, 346);
            this.dgvEstancias.Name = "dgvEstancias";
            this.dgvEstancias.Size = new System.Drawing.Size(1013, 108);
            this.dgvEstancias.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(699, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 108;
            this.label2.Text = "Tabla Estancias";
            // 
            // comboCodHoteles
            // 
            this.comboCodHoteles.FormattingEnabled = true;
            this.comboCodHoteles.Location = new System.Drawing.Point(27, 385);
            this.comboCodHoteles.Name = "comboCodHoteles";
            this.comboCodHoteles.Size = new System.Drawing.Size(188, 21);
            this.comboCodHoteles.TabIndex = 109;
            this.comboCodHoteles.DropDownClosed += new System.EventHandler(this.updateDataGrid);
            // 
            // Combobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 482);
            this.Controls.Add(this.comboCodHoteles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEstancias);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRegimenes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHabitaciones);
            this.Controls.Add(this.dgvHabitaciones);
            this.Name = "Combobox";
            this.Text = "Combobox";
            ((System.ComponentModel.ISupportInitialize) (this.dgvHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvRegimenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvEstancias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblHabitaciones;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRegimenes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvEstancias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCodHoteles;
    }
}