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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            dtpTuNgay.Value = DateTime.Now.AddDays(-7);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void LoadBills()
        {
            string connectionString = "server=DESKTOP-14GOEAT; database=RestaurantManagement; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetBillsByDateRange";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", SqlDbType.SmallDateTime);
                cmd.Parameters.Add("@ToDate", SqlDbType.SmallDateTime);

                cmd.Parameters["@FromDate"].Value = dtpTuNgay.Value;
                cmd.Parameters["@ToDate"].Value = dtpDenNgay.Value;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgvBills.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBills();
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal totalAmount = 0;
            decimal totalDiscount = 0;
            decimal totalRevenue = 0;

            foreach (DataGridViewRow row in dgvBills.Rows)
            {
                decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);
                decimal discountRate = Convert.ToDecimal(row.Cells["Discount"].Value);
                decimal discountAmount = amount * discountRate;

                totalAmount += amount;
                totalDiscount += discountAmount;
                totalRevenue += amount - discountAmount;
            }

            lblTongTien.Text = totalAmount.ToString("N0");
            lblGiamGia.Text = totalDiscount.ToString("N0");
            lblThucThu.Text = totalRevenue.ToString("N0");
        }

        private void dgvBills_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBills.CurrentRow != null)
            {
                int billID = Convert.ToInt32(dgvBills.CurrentRow.Cells["ID"].Value);
                OrderDetailsForm detailsForm = new OrderDetailsForm(billID);
                detailsForm.ShowDialog();
            }
        }
    }
}
