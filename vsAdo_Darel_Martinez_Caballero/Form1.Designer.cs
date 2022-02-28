namespace SQLMicrosfPROYECTO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCombobox = new System.Windows.Forms.Button();
            this.btnProcedimientos = new System.Windows.Forms.Button();
            this.btnFunciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(79, 118);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(163, 65);
            this.btnVisualizar.TabIndex = 0;
            this.btnVisualizar.Text = "Visualizar las multiples tablas";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(79, 258);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(163, 64);
            this.btnInsertar.TabIndex = 1;
            this.btnInsertar.Text = "Insertar en las multiples tablas";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(79, 189);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(163, 63);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar de las Multiples tablas";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(79, 328);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(163, 72);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualización multiples tablas";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(115, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = "Darel Martínez Caballero";
            // 
            // btnCombobox
            // 
            this.btnCombobox.Location = new System.Drawing.Point(292, 118);
            this.btnCombobox.Name = "btnCombobox";
            this.btnCombobox.Size = new System.Drawing.Size(163, 65);
            this.btnCombobox.TabIndex = 33;
            this.btnCombobox.Text = "Combobox";
            this.btnCombobox.UseVisualStyleBackColor = true;
            this.btnCombobox.Click += new System.EventHandler(this.btnCombobox_Click);
            // 
            // btnProcedimientos
            // 
            this.btnProcedimientos.Location = new System.Drawing.Point(292, 189);
            this.btnProcedimientos.Name = "btnProcedimientos";
            this.btnProcedimientos.Size = new System.Drawing.Size(163, 65);
            this.btnProcedimientos.TabIndex = 34;
            this.btnProcedimientos.Text = "Procedimientos";
            this.btnProcedimientos.UseVisualStyleBackColor = true;
            this.btnProcedimientos.Click += new System.EventHandler(this.btnProcedimientos_Click);
            // 
            // btnFunciones
            // 
            this.btnFunciones.Location = new System.Drawing.Point(292, 260);
            this.btnFunciones.Name = "btnFunciones";
            this.btnFunciones.Size = new System.Drawing.Size(163, 65);
            this.btnFunciones.TabIndex = 35;
            this.btnFunciones.Text = "Funciones";
            this.btnFunciones.UseVisualStyleBackColor = true;
            this.btnFunciones.Click += new System.EventHandler(this.btnFunciones_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 404);
            this.Controls.Add(this.btnFunciones);
            this.Controls.Add(this.btnProcedimientos);
            this.Controls.Add(this.btnCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnVisualizar);
            this.Name = "Form1";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnFunciones;

        private System.Windows.Forms.Button btnProcedimientos;

        #endregion

        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCombobox;
    }
}

