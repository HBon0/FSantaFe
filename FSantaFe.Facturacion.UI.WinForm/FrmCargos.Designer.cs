
namespace FSantaFe.Facturacion.UI.WinForm
{
    partial class FrmCargos
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCargo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(174, 270);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 270);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 270);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvCargos
            // 
            this.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargos.Location = new System.Drawing.Point(12, 77);
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.Size = new System.Drawing.Size(430, 173);
            this.dgvCargos.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre Cargo";
            // 
            // txtNombreCargo
            // 
            this.txtNombreCargo.Location = new System.Drawing.Point(15, 50);
            this.txtNombreCargo.Name = "txtNombreCargo";
            this.txtNombreCargo.Size = new System.Drawing.Size(146, 20);
            this.txtNombreCargo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Estado";
            // 
            // cboEstados
            // 
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(187, 50);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(142, 21);
            this.cboEstados.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(367, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 302);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboEstados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreCargo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvCargos);
            this.Name = "FrmCargos";
            this.Text = "Listado de Cargos";
            this.Load += new System.EventHandler(this.FrmCargos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvCargos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCargo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Button btnBuscar;
    }
}