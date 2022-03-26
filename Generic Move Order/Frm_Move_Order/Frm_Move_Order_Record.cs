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

namespace Generic_Move_Order.Frm_Move_Order
{
    public partial class Frm_Move_Order_Record : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Move_Order_Record()
        {
            InitializeComponent();
        }

        private void Frm_Move_Order_Record_Load(object sender, EventArgs e)
        {
            DisableAccess();
            UserAccess();
            cb_status.SelectedIndex = 0;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;
            btn_view.Enabled = false;
            HeaderName();
            //GetMoveOrderRecordsBySearch();
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

                if (mod_name == "move_btn_inactive")
                {
                    btn_inactive.Visible = true;
                }
            }
        }

        public void GetMoveOrderRecords()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMoveOrderRecords", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@start", dp_start.Text);
            cmd.Parameters.AddWithValue("@end", dp_end.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();

            dt_move_order.ReadOnly = true;
        }

        public void GetMoveOrderRecordsBySearch()
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
            dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Frm_View_Move_Order frm = new Frm_View_Move_Order();
            frm.ShowDialog();
        }

        private void cb_status_SelectedIndexChanged_1(object sender, EventArgs e)
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
            GetMoveOrderRecords();
            label_role_counting.Text = "TOTAL # OF MOVE ORDER/S: " + (dt_move_order.RowCount);
        }

        private void dt_move_order_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_move_order.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                view_move_order.id = int.Parse(row.Cells["id"].Value.ToString());
                view_move_order.customer_code = row.Cells["customer_code"].Value.ToString();
                view_move_order.customer_name = row.Cells["customer_name"].Value.ToString();
                view_move_order.description = row.Cells["description"].Value.ToString();
                view_move_order.transaction_date = DateTime.Parse(row.Cells["transaction_date"].Value.ToString());

                btn_view.Enabled = true;
                btn_print.Enabled = true;
                if(cb_status.Text == "Active")
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
            Frm_Printing.printing.last_id = view_move_order.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "MoveOrder";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void InactiveMoveORder()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateMoveOrderStatusToInactive", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", view_move_order.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        private void btn_inactive_Click(object sender, EventArgs e)
        {
            //GetSelected();
            //textBox1.Text.Substring(1);
            //textBox1.Text = textBox1.Text.Remove(0, 1);
            //GetSelected();

            //GetSelectedRecords();

            DialogResult res = MessageBox.Show("Are you sure you want to cancel?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                InactiveMoveORder();
                GetMoveOrderRecords();
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
                GetMoveOrderRecordsBySearch();
            }
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void HeaderName()
        {
            dt_move_order.Columns["id"].HeaderText = "Id";
            dt_move_order.Columns["customer_code"].HeaderText = "Customer Code";
            dt_move_order.Columns["customer_name"].HeaderText = "Customer Name";
            dt_move_order.Columns["description"].HeaderText = "Description";
            dt_move_order.Columns["transaction_date"].HeaderText = "Transaction Date";

            dt_move_order.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_move_order.EnableHeadersVisualStyles = false;
        }

        private void dp_start_ValueChanged(object sender, EventArgs e)
        {
            GetMoveOrderRecords();
        }

        private void dp_end_ValueChanged(object sender, EventArgs e)
        {
            GetMoveOrderRecords();
        }

        private void dt_move_order_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_move_order.ClearSelection();
            btn_view.Enabled = false;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;

            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_move_order.RowCount);
        }
    }
}
