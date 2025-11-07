using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab_Advanced_Command
{
    public partial class AccountInfoForm : Form
    {
        public AccountInfoForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "InsertAccount";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200);

                cmd.Parameters["@AccountName"].Value = txtAccountName.Text;
                cmd.Parameters["@Password"].Value = txtPassword.Text;
                cmd.Parameters["@FullName"].Value = txtFullName.Text;
                cmd.Parameters["@Email"].Value = txtEmail.Text;
                cmd.Parameters["@Tell"].Value = txtTell.Text;

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm tài khoản thành công!");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
