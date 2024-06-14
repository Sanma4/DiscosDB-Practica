namespace Practica_Discos
{
    partial class frmDiscos
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.pbxDiscos = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDiscos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDiscos.Location = new System.Drawing.Point(32, 31);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscos.Size = new System.Drawing.Size(444, 298);
            this.dgvDiscos.TabIndex = 0;
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // pbxDiscos
            // 
            this.pbxDiscos.Location = new System.Drawing.Point(496, 22);
            this.pbxDiscos.Name = "pbxDiscos";
            this.pbxDiscos.Size = new System.Drawing.Size(341, 298);
            this.pbxDiscos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDiscos.TabIndex = 1;
            this.pbxDiscos.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(32, 335);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(113, 335);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // frmDiscos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 370);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbxDiscos);
            this.Controls.Add(this.dgvDiscos);
            this.Name = "frmDiscos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DISCOS";
            this.Load += new System.EventHandler(this.frmDiscos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiscos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.PictureBox pbxDiscos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
    }
}

