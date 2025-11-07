namespace Lab_Advanced_Command
{
    partial class ActivityLogForm
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
            this.lbxDates = new System.Windows.Forms.ListBox();
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxDates
            // 
            this.lbxDates.FormattingEnabled = true;
            this.lbxDates.ItemHeight = 20;
            this.lbxDates.Location = new System.Drawing.Point(8, 6);
            this.lbxDates.Name = "lbxDates";
            this.lbxDates.Size = new System.Drawing.Size(296, 424);
            this.lbxDates.TabIndex = 0;
            this.lbxDates.SelectedIndexChanged += new System.EventHandler(this.lbxDates_SelectedIndexChanged);
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Location = new System.Drawing.Point(313, 8);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.RowHeadersWidth = 62;
            this.dgvBillDetails.RowTemplate.Height = 28;
            this.dgvBillDetails.Size = new System.Drawing.Size(477, 288);
            this.dgvBillDetails.TabIndex = 1;
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHoaDon.Location = new System.Drawing.Point(521, 325);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(15, 22);
            this.lblTongHoaDon.TabIndex = 2;
            this.lblTongHoaDon.Text = ".";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(521, 380);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(15, 22);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng số hóa đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng số tiền:";
            // 
            // ActivityLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblTongHoaDon);
            this.Controls.Add(this.dgvBillDetails);
            this.Controls.Add(this.lbxDates);
            this.Name = "ActivityLogForm";
            this.Text = "ActivityLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxDates;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}