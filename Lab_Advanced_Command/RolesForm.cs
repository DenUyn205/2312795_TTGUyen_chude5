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
    public partial class RolesForm : Form
    {
        private string accountName;
        public RolesForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            LoadRoles();
        }

        private void LoadRoles()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT r.ID, r.RoleName, 
                           CASE WHEN ra.AccountName IS NOT NULL THEN 1 ELSE 0 END AS IsAssigned
                           FROM Role r
                           LEFT JOIN RoleAccount ra ON r.ID = ra.RoleID AND ra.AccountName = @AccountName";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvRoles.Columns.Clear();
                dgvRoles.DataSource = dt;

                // Chỉ thêm 1 checkbox column
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                chkCol.HeaderText = "Chọn";
                chkCol.DataPropertyName = "IsAssigned";
                dgvRoles.Columns.Insert(0, chkCol);

                dgvRoles.Columns["ID"].Visible = false;
                dgvRoles.Columns["IsAssigned"].Visible = false;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddRoleForm addForm = new AddRoleForm();
            addForm.ShowDialog();
            LoadRoles();
        }

        //Update hơi lỏ
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cập nhật tên role
                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE Role SET RoleName = @RoleName WHERE ID = @ID";
                        cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000).Value = row.Cells["RoleName"].Value;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row.Cells["ID"].Value;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }




    }
}
