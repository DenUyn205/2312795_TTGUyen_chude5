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
    public partial class ActivityLogForm : Form
    {
        private string accountName;
        public ActivityLogForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            LoadBillDates();
        }

        private void LoadBillDates()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetBillDatesByAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbxDates.Items.Add(reader["CheckoutDate"]);
                }
            }
            CalculateTotals();
        }

        private void LoadBillDetails(DateTime date)
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetBillDetailsByDate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
                cmd.Parameters.Add("@CheckoutDate", SqlDbType.SmallDateTime).Value = date;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvBillDetails.DataSource = dt;
            }
        }


        private void lbxDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDates.SelectedItem != null)
            {
                DateTime selectedDate = Convert.ToDateTime(lbxDates.SelectedItem);
                LoadBillDetails(selectedDate);
            }
        }

        private void CalculateTotals()
    {
        string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GetAccountStatistics";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName;
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                lblTongHoaDon.Text = reader["TotalBills"].ToString();
                lblTongTien.Text = Convert.ToDecimal(reader["TotalAmount"]).ToString("N0");
            }
        }
    }

        
    }
}
