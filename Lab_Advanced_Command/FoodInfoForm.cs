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
	public partial class FoodInfoForm : Form
	{
		public FoodInfoForm()
		{
			InitializeComponent();
		}

		private void FoodInfoForm_Load(object sender, EventArgs e)
		{
			this.InitValues();
		}

		private void InitValues()
		{
			string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "SELECT ID, Name FROM Category";
			
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

			conn.Open();

			// LŐy dű liệu tú csál dua vào DataTable
			adapter.Fill(ds, "Category");

			// Hién thị nhóm món ăn
			cboCatName.DataSource = ds.Tables["Category"];
			cboCatName.DisplayMember = "Name";
			cboCatName.ValueMember = "ID";

			conn.Close();
			conn.Dispose();
		}

		private void ResetText()
		{
			txtID.ResetText();
			txtName.ResetText();
			txtNotes.ResetText();
			txtUnit.ResetText();
			cboCatName.ResetText();
			numPrice.ResetText();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";

					// Thêm các parameters
					cmd.Parameters.Add("@id", SqlDbType.Int);
					cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
					cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
					cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
					cmd.Parameters.Add("@price", SqlDbType.Int);
					cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

					cmd.Parameters["@id"].Direction = ParameterDirection.Output;

					// Truyền giá trị vào các parameters
					cmd.Parameters["@name"].Value = txtName.Text;
					cmd.Parameters["@unit"].Value = txtUnit.Text;
					cmd.Parameters["@foodCategoryID"].Value = cboCatName.SelectedValue;
					cmd.Parameters["@price"].Value = numPrice.Value;
					cmd.Parameters["@notes"].Value = txtNotes.Text;

					// Mở kết nối
					conn.Open();

					int numRowAffected = cmd.ExecuteNonQuery();

					// Thông báo kết quả
					if (numRowAffected > 0)
					{
						string foodID = cmd.Parameters["@id"].Value.ToString();
						MessageBox.Show("Successfully adding new food. Food ID: " + foodID, "Message");
						this.ResetText();
					}
					else
					{
						MessageBox.Show("Adding food failed");
					}
				}
			}
			// Bắt lỗi SQL và các lỗi khác
			catch (SqlException exception)
			{
				MessageBox.Show(exception.Message, "SQL Error");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error");
			}
		}

		public void DisplayFoodInfo(DataRowView rowView)
		{
			try
			{
				txtID.Text = rowView["ID"].ToString();
				txtName.Text = rowView["Name"].ToString();
				txtUnit.Text = rowView["Unit"].ToString();
				txtNotes.Text = rowView["Notes"].ToString();
				numPrice.Value = Convert.ToDecimal(rowView["Price"]);

				cboCatName.SelectedIndex = -1;

				// Chọn nhóm món ăn tương ứng
				for (int index = 0; index < cboCatName.Items.Count; index++)
				{
					DataRowView cat = cboCatName.Items[index] as DataRowView;
					if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
					{
						cboCatName.SelectedIndex = index;
						break;
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error");
				this.Close();
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				string connectionString = "server=DESKTOP-14GOEAT; database = RestaurantManagement; Integrated Security = true; ";
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

					// Thêm các parameters
					cmd.Parameters.Add("@id", SqlDbType.Int);
					cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
					cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
					cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
					cmd.Parameters.Add("@price", SqlDbType.Int);
					cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

					// Truyền giá trị vào các parameters
					cmd.Parameters["@id"].Value = int.Parse(txtID.Text);
					cmd.Parameters["@name"].Value = txtName.Text;
					cmd.Parameters["@unit"].Value = txtUnit.Text;
					cmd.Parameters["@foodCategoryID"].Value = cboCatName.SelectedValue;
					cmd.Parameters["@price"].Value = numPrice.Value;
					cmd.Parameters["@notes"].Value = txtNotes.Text;

					// Mở kết nối
					conn.Open();

					int numRowAffected = cmd.ExecuteNonQuery();

					// Thông báo kết quả
					if (numRowAffected > 0)
					{
						MessageBox.Show("Successfully updating food", "Message");
						this.ResetText();
					}
					else
					{
						MessageBox.Show("Updating food failed");
					}
				}
			}
			// Bắt lỗi SQL và các lỗi khác
			catch (SqlException exception)
			{
				MessageBox.Show(exception.Message, "SQL Error");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error");
			}
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewCategoryForm form = new AddNewCategoryForm();
            DialogResult kq = form.ShowDialog();
            if (kq == DialogResult.OK)
            {
                InitValues();
            }
        }



    }
}
