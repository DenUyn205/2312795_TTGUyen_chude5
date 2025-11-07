namespace Lab_Advanced_Command
{
    partial class AccountForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmXemVaiTro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmXemNhatKyHD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAccounts.Location = new System.Drawing.Point(-2, -2);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.RowHeadersWidth = 62;
            this.dgvAccounts.RowTemplate.Height = 28;
            this.dgvAccounts.Size = new System.Drawing.Size(721, 287);
            this.dgvAccounts.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmXemVaiTro,
            this.tsmXemNhatKyHD});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(291, 101);
            // 
            // tsmXemVaiTro
            // 
            this.tsmXemVaiTro.Name = "tsmXemVaiTro";
            this.tsmXemVaiTro.Size = new System.Drawing.Size(290, 32);
            this.tsmXemVaiTro.Text = "Xem danh sách các vai trò";
            this.tsmXemVaiTro.Click += new System.EventHandler(this.tsmXemVaiTro_Click);
            // 
            // tsmXemNhatKyHD
            // 
            this.tsmXemNhatKyHD.Name = "tsmXemNhatKyHD";
            this.tsmXemNhatKyHD.Size = new System.Drawing.Size(290, 32);
            this.tsmXemNhatKyHD.Text = "Xem nhật ký hoạt động";
            this.tsmXemNhatKyHD.Click += new System.EventHandler(this.tsmXemNhatKyHD_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(38, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(173, 53);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm tài khoản mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(235, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 53);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật tài khoản";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 375);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvAccounts);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmXemVaiTro;
        private System.Windows.Forms.ToolStripMenuItem tsmXemNhatKyHD;
    }
}