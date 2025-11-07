using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
	public partial class FoodForm : Form
	{
		private DataTable foodTable;
		public FoodForm()
		{
			InitializeComponent();
		}

		private void LoadCategory()
		{
			string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection conn = new SqlConnection(connectionString);

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "SELECT ID, Name FROM Category";

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();

			conn.Open();
			
			adapter.Fill(dt);

			conn.Close();
			conn.Dispose();

			cboCategory.DataSource = dt;
			//Hien thi ten nhom san pham
			cboCategory.DisplayMember = "Name";
			//Khi lay gtri thi lay ID cua Nhom
			cboCategory.ValueMember = "ID";

			
		}

		private void FoodForm_Load(object sender, EventArgs e)
		{
			LoadCategory();
		}

		private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCategory.SelectedIndex == -1) return;

			string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection conn = new SqlConnection(connectionString);

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = @categoryId";

			// Truyën tham ső
			cmd.Parameters.Add("@categoryId", SqlDbType.Int);

			if (cboCategory.SelectedValue is DataRowView)
			{
				DataRowView rowView = cboCategory.SelectedValue as DataRowView;
				cmd.Parameters["@categoryId"].Value = rowView["ID"];
			}

			else
			{
				cmd.Parameters["@categoryId"].Value = cboCategory.SelectedValue;
			}

			// Tạo bộ điều phiếu dữ liệu
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			foodTable = new DataTable();

			// Mở kết nối
			conn.Open();

			// Lấy dữ liệu từ csúl đưa vào DataTable
			adapter.Fill(foodTable);

			// Đóng kết nối và giải phóng bộ nhớ
			conn.Close();
			conn.Dispose();

			// Đưa dữ liệu vào data gridview
			dgvFoodList.DataSource = foodTable;

			// Tính số lượng mẫu tín
			lblQuantity.Text = foodTable.Rows.Count.ToString();
			lblCatName.Text = cboCategory.Text;
		}

		private void tsmCalculateQuantity_Click(object sender, EventArgs e)
		{
			string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection conn = new SqlConnection(connectionString);

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails WHERE FoodID = @FoodId";
			// Lấy thông tin sản phẩm được chọn
			if (dgvFoodList.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
				DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
				// Truyền tham số
				cmd.Parameters.Add("@FoodId", SqlDbType.Int);
				cmd.Parameters["@FoodId"].Value = rowView["ID"];
				cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
				cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

				conn.Open();
				// Thực thi truy vấn và lấy dữ liệu từ tham số
				cmd.ExecuteNonQuery();

				string result = cmd.Parameters["@numSaleFood"].Value.ToString();
				MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);

				conn.Close();
			}
			cmd.Dispose();
			conn.Dispose();

		}

		private void tsmAddFood_Click(object sender, EventArgs e)
		{
			FoodInfoForm foodForm = new FoodInfoForm();
			foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
			foodForm.Show(this);
		}

		void foodForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			int index = cboCategory.SelectedIndex;
			cboCategory.SelectedIndex = -1;
			cboCategory.SelectedIndex = index;
		}

		private void tsmUpdateFood_Click(object sender, EventArgs e)
		{
			if (dgvFoodList.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
				DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

				FoodInfoForm foodForm = new FoodInfoForm();
				foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
				foodForm.Show(this);
				foodForm.DisplayFoodInfo(rowView);
			}
		}

		private void txtSearchByName_TextChanged(object sender, EventArgs e)
		{
			if (foodTable == null) return;
			// create filter and sort expression
			string filterExpression = "Name like '%" + txtSearchByName.Text + "%'";
			string sortExpression = "Price DESC";
			DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;
			// Create a data view object to view the data in foodTable data table
			// filter by Name (contain 'ng') and sort descending by Price
			DataView foodView = new DataView(foodTable,
			filterExpression, sortExpression, rowStateFilter);
			// Assign foodTable as Data Source of data grid view
			dgvFoodList.DataSource = foodView;
		}
	}
}
