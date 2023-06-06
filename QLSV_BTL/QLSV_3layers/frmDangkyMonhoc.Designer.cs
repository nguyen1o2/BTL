namespace QLSV_3layers
{
    partial class frmDangkyMonhoc
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
            this.dgvDSLH = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSLH
            // 
            this.dgvDSLH.AllowUserToAddRows = false;
            this.dgvDSLH.AllowUserToDeleteRows = false;
            this.dgvDSLH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSLH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSLH.Location = new System.Drawing.Point(0, 0);
            this.dgvDSLH.MultiSelect = false;
            this.dgvDSLH.Name = "dgvDSLH";
            this.dgvDSLH.ReadOnly = true;
            this.dgvDSLH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSLH.Size = new System.Drawing.Size(755, 419);
            this.dgvDSLH.TabIndex = 0;
            this.dgvDSLH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSLH_CellDoubleClick);
            // 
            // frmDangkyMonhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 419);
            this.Controls.Add(this.dgvDSLH);
            this.Name = "frmDangkyMonhoc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách lớp học";
            this.Load += new System.EventHandler(this.frmDKyMHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSLH;
    }
}