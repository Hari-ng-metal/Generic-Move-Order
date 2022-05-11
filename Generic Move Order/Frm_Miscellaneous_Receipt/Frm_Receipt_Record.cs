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

namespace Generic_Move_Order.Frm_Miscellaneous_Receipt
{
    public partial class Frm_Receipt_Record : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Receipt_Record()
        {
            InitializeComponent();
        }

        private void Frm_Receipt_Record_Load(object sender, EventArgs e)
        {
            CustomDatePicker();
            DisableAccess();
            UserAccess();
            cb_status.SelectedIndex = 0;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;
            btn_view.Enabled = false;
            HeaderName();
        }

        private void CustomDatePicker()
        {
            dp_start.CustomFormat = "MM/dd/yyyy";
            dp_end.CustomFormat = "MM/dd/yyyy";
        }

        private void DisableAccess()
        {
            btn_inactive.Visible = false;
        }

        private void UserAccess()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUserAccess", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@role", User.role_id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_user_role.DataSource = dt;
            connect.con.Close();

            foreach (DataRow row in dt.Rows)
            {
                string mod_name = row[2].ToString();
                //MessageBox.Show("" + mod_name);

                if (mod_name == "receipt_btn_inactive")
                {
                    btn_inactive.Visible = true;
                }
            }
        }

        public void GetReceiptRecords()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetReceiptRecords", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@start", dp_start.Text);
            cmd.Parameters.AddWithValue("@end", dp_end.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_receiving.DataSource = dt;
            connect.con.Close();

            dt_receiving.ReadOnly = true;
        }

        public void GetReceitRecordsBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMoveOrderRecordsBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            cmd.Parameters.AddWithValue("@start", dp_start.Text);
            cmd.Parameters.AddWithValue("@end", dp_end.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_receiving.DataSource = dt;
            connect.con.Close();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Frm_View_Receipt frm = new Frm_View_Receipt();
            frm.ShowDialog();
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_status.Text == "Active")
            {
                status = bool.Parse(true.ToString());
                btn_inactive.Enabled = true;
            }
            else
            {
                status = bool.Parse(false.ToString());
                btn_inactive.Enabled = false;
            }
            GetReceiptRecords();
            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_receiving.RowCount);
        }

        private void dt_receiving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_receiving.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                view_receipt.id = int.Parse(row.Cells["id"].Value.ToString());
                view_receipt.supplier_code = row.Cells["supplier_code"].Value.ToString();
                view_receipt.supplier_name = row.Cells["supplier_name"].Value.ToString();
                view_receipt.description = row.Cells["description"].Value.ToString();
                view_receipt.transaction_date = DateTime.Parse(row.Cells["transaction_date"].Value.ToString());
                view_receipt.reference = row.Cells["reference"].Value.ToString();
                view_receipt.account_title = row.Cells["account_title"].Value.ToString();

                btn_view.Enabled = true;
                btn_print.Enabled = true;
                if (cb_status.Text == "Active")
                {
                    btn_inactive.Enabled = true;
                }


            }
            else
            {
                btn_view.Enabled = false;
                btn_inactive.Enabled = false;
                btn_print.Enabled = false;
            }
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Frm_Printing.printing.last_id = view_receipt.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Receipt";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void InactiveReceipt()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateReceiptStatusToInactive", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", view_receipt.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_receiving.DataSource = dt;
            connect.con.Close();
        }

        private void btn_inactive_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to cancel?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                InactiveReceipt();
                GetReceiptRecords();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetReceitRecordsBySearch();
            }
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void HeaderName()
        {
            dt_receiving.Columns["id"].HeaderText = "Id";
            dt_receiving.Columns["supplier_code"].HeaderText = "Supplier Code";
            dt_receiving.Columns["supplier_name"].HeaderText = "Supplier Name";
            dt_receiving.Columns["description"].HeaderText = "Description";
            dt_receiving.Columns["transaction_date"].HeaderText = "Transaction Date";
            dt_receiving.Columns["reference"].HeaderText = "Reference";
            dt_receiving.Columns["account_title"].HeaderText = "Account Title";

            dt_receiving.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_receiving.EnableHeadersVisualStyles = false;
        }

        private void dp_start_ValueChanged(object sender, EventArgs e)
        {
            GetReceiptRecords();
        }

        private void dp_end_ValueChanged(object sender, EventArgs e)
        {
            GetReceiptRecords();
        }

        private void dt_receiving_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_receiving.ClearSelection();

            btn_view.Enabled = false;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;

            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_receiving.RowCount);
        }
    }
}
