using System.ComponentModel;

namespace SQLMicrosfPROYECTO
{
    partial class Funciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvFuncSumaTotalEstancias = new System.Windows.Forms.DataGridView();
            this.btnFuncSumaTotalEstancias = new System.Windows.Forms.Button();
            this.txtCoddnionie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.dgvFuncSumaTotalEstancias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 33);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvFuncSumaTotalEstancias
            // 
            this.dgvFuncSumaTotalEstancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncSumaTotalEstancias.Location = new System.Drawing.Point(12, 116);
            this.dgvFuncSumaTotalEstancias.Name = "dgvFuncSumaTotalEstancias";
            this.dgvFuncSumaTotalEstancias.Size = new System.Drawing.Size(148, 80);
            this.dgvFuncSumaTotalEstancias.TabIndex = 67;
            // 
            // btnFuncSumaTotalEstancias
            // 
            this.btnFuncSumaTotalEstancias.Location = new System.Drawing.Point(11, 202);
            this.btnFuncSumaTotalEstancias.Name = "btnFuncSumaTotalEstancias";
            this.btnFuncSumaTotalEstancias.Size = new System.Drawing.Size(213, 21);
            this.btnFuncSumaTotalEstancias.TabIndex = 66;
            this.btnFuncSumaTotalEstancias.Text = "Ejecutar Función suma total Estancias";
            this.btnFuncSumaTotalEstancias.UseVisualStyleBackColor = true;
            this.btnFuncSumaTotalEstancias.Click += new System.EventHandler(this.btnFuncSumaTotalEstancias_Click);
            // 
            // txtCoddnionie
            // 
            this.txtCoddnionie.Location = new System.Drawing.Point(11, 90);
            this.txtCoddnionie.Name = "txtCoddnionie";
            this.txtCoddnionie.Size = new System.Drawing.Size(100, 20);
            this.txtCoddnionie.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "coddnionie";
            // 
            // Funciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 227);
            this.Controls.Add(this.dgvFuncSumaTotalEstancias);
            this.Controls.Add(this.btnFuncSumaTotalEstancias);
            this.Controls.Add(this.txtCoddnionie);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCerrar);
            this.Name = "Funciones";
            this.Text = "Funciones";
            ((System.ComponentModel.ISupportInitialize) (this.dgvFuncSumaTotalEstancias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvFuncSumaTotalEstancias;
        private System.Windows.Forms.Button btnFuncSumaTotalEstancias;
        private System.Windows.Forms.TextBox txtCoddnionie;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}