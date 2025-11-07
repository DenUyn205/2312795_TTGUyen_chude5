namespace Lab_Advanced_Command
{
	partial class FoodForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblCatName = new System.Windows.Forms.Label();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dgvFoodList = new System.Windows.Forms.DataGridView();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.ctmFoodList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmCalculateQuantity = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmSeperator = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmAddFood = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmUpdateFood = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSearchByName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).BeginInit();
			this.ctmFoodList.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(23, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chọn nhóm món án:";
			// 
			// lblCatName
			// 
			this.lblCatName.AutoSize = true;
			this.lblCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.lblCatName.Location = new System.Drawing.Point(327, 408);
			this.lblCatName.Name = "lblCatName";
			this.lblCatName.Size = new System.Drawing.Size(16, 16);
			this.lblCatName.TabIndex = 0;
			this.lblCatName.Text = "...";
			// 
			// lblQuantity
			// 
			this.lblQuantity.AutoSize = true;
			this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.lblQuantity.Location = new System.Drawing.Point(122, 408);
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(16, 16);
			this.lblQuantity.TabIndex = 0;
			this.lblQuantity.Text = "...";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.label4.Location = new System.Drawing.Point(42, 408);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Có tất cả";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.label5.Location = new System.Drawing.Point(188, 408);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(122, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "món ăn thuộc nhóm";
			// 
			// dgvFoodList
			// 
			this.dgvFoodList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFoodList.ContextMenuStrip = this.ctmFoodList;
			this.dgvFoodList.Location = new System.Drawing.Point(0, 58);
			this.dgvFoodList.Name = "dgvFoodList";
			this.dgvFoodList.Size = new System.Drawing.Size(737, 338);
			this.dgvFoodList.TabIndex = 1;
			// 
			// cboCategory
			// 
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Location = new System.Drawing.Point(153, 23);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(192, 21);
			this.cboCategory.TabIndex = 2;
			this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
			// 
			// ctmFoodList
			// 
			this.ctmFoodList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCalculateQuantity,
            this.tsmSeperator,
            this.tsmAddFood,
            this.tsmUpdateFood});
			this.ctmFoodList.Name = "ctmFoodList";
			this.ctmFoodList.Size = new System.Drawing.Size(205, 92);
			// 
			// tsmCalculateQuantity
			// 
			this.tsmCalculateQuantity.Name = "tsmCalculateQuantity";
			this.tsmCalculateQuantity.Size = new System.Drawing.Size(204, 22);
			this.tsmCalculateQuantity.Text = "Tính số lượng đã bán";
			this.tsmCalculateQuantity.Click += new System.EventHandler(this.tsmCalculateQuantity_Click);
			// 
			// tsmSeperator
			// 
			this.tsmSeperator.Name = "tsmSeperator";
			this.tsmSeperator.Size = new System.Drawing.Size(204, 22);
			this.tsmSeperator.Text = "--------------------------";
			// 
			// tsmAddFood
			// 
			this.tsmAddFood.Name = "tsmAddFood";
			this.tsmAddFood.Size = new System.Drawing.Size(204, 22);
			this.tsmAddFood.Text = "Thêm món ăn mới";
			this.tsmAddFood.Click += new System.EventHandler(this.tsmAddFood_Click);
			// 
			// tsmUpdateFood
			// 
			this.tsmUpdateFood.Name = "tsmUpdateFood";
			this.tsmUpdateFood.Size = new System.Drawing.Size(204, 22);
			this.tsmUpdateFood.Text = "Cập nhật món ăn";
			this.tsmUpdateFood.Click += new System.EventHandler(this.tsmUpdateFood_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(397, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tìm kiếm theo tên:";
			// 
			// txtSearchByName
			// 
			this.txtSearchByName.Location = new System.Drawing.Point(518, 24);
			this.txtSearchByName.Name = "txtSearchByName";
			this.txtSearchByName.Size = new System.Drawing.Size(193, 20);
			this.txtSearchByName.TabIndex = 4;
			this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
			// 
			// FoodForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 450);
			this.Controls.Add(this.txtSearchByName);
			this.Controls.Add(this.cboCategory);
			this.Controls.Add(this.dgvFoodList);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblQuantity);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCatName);
			this.Controls.Add(this.label1);
			this.Name = "FoodForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FoodForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).EndInit();
			this.ctmFoodList.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCatName;
		private System.Windows.Forms.Label lblQuantity;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridView dgvFoodList;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.ContextMenuStrip ctmFoodList;
		private System.Windows.Forms.ToolStripMenuItem tsmCalculateQuantity;
		private System.Windows.Forms.ToolStripMenuItem tsmSeperator;
		private System.Windows.Forms.ToolStripMenuItem tsmAddFood;
		private System.Windows.Forms.ToolStripMenuItem tsmUpdateFood;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSearchByName;
	}
}

