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
    public partial class AddNewCategoryForm : Form
    {
        public AddNewCategoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "InsertCategory";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Type", SqlDbType.Int);

                cmd.Parameters["@Name"].Value = txtName.Text;
                cmd.Parameters["@Type"].Value = cboType.SelectedIndex == 0 ? 1 : 0;

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Add category successfully!");
                this.Close();
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
