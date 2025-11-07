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
    public partial class OrderDetailsForm : Form
    {
        private int billID;
        public OrderDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
            LoadBillInfo();
            LoadBillDetails();
        }

        private void LoadBillInfo()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name, TableID FROM Bills WHERE ID = @BillID";
                cmd.Parameters.Add("@BillID", SqlDbType.Int);
                cmd.Parameters["@BillID"].Value = billID;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblHoaDon.Text = reader["Name"].ToString();
                    lblBan.Text = reader["TableID"].ToString();
                }
            }
        }


        private void LoadBillDetails()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetBillDetails";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BillID", SqlDbType.Int);
                cmd.Parameters["@BillID"].Value = billID;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvOrderDetails.DataSource = dataTable;

                decimal total = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    total += Convert.ToDecimal(row["Total"]);
                }
                lblTongTien.Text = total.ToString("N0");

            }
        }
    }
}
