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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetAllAccounts";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvAccounts.DataSource = dataTable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AccountInfoForm addForm = new AccountInfoForm();
            addForm.ShowDialog();
            LoadAccounts();
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow != null)
            {
                string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UpdateAccount";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataGridViewRow row = dgvAccounts.CurrentRow;

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = row.Cells["AccountName"].Value;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = row.Cells["Password"].Value;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = row.Cells["FullName"].Value;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = row.Cells["Email"].Value;
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = row.Cells["Tell"].Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadAccounts();
                    MessageBox.Show("Cập nhật thành công");

                }
            }
        }

        private void tsmXemVaiTro_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow != null)
            {
                string accountName = dgvAccounts.CurrentRow.Cells["AccountName"].Value.ToString();
                RolesForm roleForm = new RolesForm(accountName);
                roleForm.ShowDialog();
            }
        }

        private void tsmXemNhatKyHD_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow != null)
            {
                string accountName = dgvAccounts.CurrentRow.Cells["AccountName"].Value.ToString();
                ActivityLogForm logForm = new ActivityLogForm(accountName);
                logForm.ShowDialog();
            }
        }
    }
}
