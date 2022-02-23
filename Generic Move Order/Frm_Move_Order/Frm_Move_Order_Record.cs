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
            cb_status.SelectedIndex = 0;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;
            btn_view.Enabled = false;
        }
        public void GetMoveOrderRecords()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMoveOrderRecords", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
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
            }
            else
            {
                status = bool.Parse(false.ToString());
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
                btn_inactive.Enabled = true;
                btn_print.Enabled = true;

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

        private void btn_inactive_Click(object sender, EventArgs e)
        {
            //GetSelected();
            //textBox1.Text.Substring(1);
            //textBox1.Text = textBox1.Text.Remove(0, 1);
            //GetSelected();

            //GetSelectedRecords();
        }

        //private void GetSelected()
        //{
        //    string message = string.Empty;
        //    foreach (DataGridViewRow row in dt_move_order.Rows)
        //    {
        //        bool isSelected = Convert.ToBoolean(row.Cells["select"].Value);
        //        if (isSelected)
        //        {
        //            //message += Environment.NewLine;
        //            //message = "0";
        //            message += ",";
        //            message += row.Cells["id"].Value.ToString();
        //            //message += message.Remove(0, 1);

        //            textBox1.Text = message;

        //            textBox1.Text = textBox1.Text.Remove(0, 1);
        //        }
        //    }
        //    //Frm_Printing.printing.last_id = int.Parse(message.ToString());
        //    //CallPrintOut();

        //    MessageBox.Show("" + textBox1.Text);
        //}

        //public void GetSelectedRecords()
        //{
        //    connect.DatabaseConnection();
        //    connect.con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_GetMoveOrderItemMultipleById", connect.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    dataGridView1.DataSource = dt;
        //    connect.con.Close();
        //}
    }
}
