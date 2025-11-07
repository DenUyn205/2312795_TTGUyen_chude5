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
    public partial class AddRoleForm : Form
    {
        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "InsertRole";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000).Value = txtRoleName.Text;

                conn.Open();
                cmd.ExecuteNonQuery();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
