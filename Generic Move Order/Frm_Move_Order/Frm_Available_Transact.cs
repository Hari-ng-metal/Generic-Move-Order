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
    public partial class Frm_Available_Transact : Form
    {
        Connection connect = new Connection();
        public Frm_Available_Transact()
        {
            InitializeComponent();
        }

        private void Frm_Available_Transact_Load(object sender, EventArgs e)
        {
            //
            cb_status.SelectedIndex = 0;
            btn_transact.Enabled = false;
            //GetTransactMoveOrderAvailable();
            HeaderName();
        }

        private void dt_move_order_CellClick(object sender, DataGridViewCellEventArgs e)
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

                btn_transact.Enabled = true;


            }
            else
            {
                btn_transact.Enabled = false;
            }
        }

        public void GetTransactMoveOrderAvailable()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTransactMoveOrderAvailable", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", true);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();

            dt_move_order.ReadOnly = true;
        }

        public void GetTransactMoveOrderAvailableBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTransactMoveOrderAvailableBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        public void GetTransactMoveOrderAlready()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTransactMoveOrderAlready", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@transact_status", true);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        public void GetTransactMoveOrderAlreadyBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTransactMoveOrderAlreadyBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@transact_status", true);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_transact_Click(object sender, EventArgs e)
        {
            if(btn_transact.Text == "Transact")
            {
                Frm_Transact_Move_Order frm = new Frm_Transact_Move_Order(this);
                frm.ShowDialog();
            }
            else
            {
                Frm_View_Transacted frm = new Frm_View_Transacted();
                frm.ShowDialog();
            }

        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //status

            if (cb_status.Text == "Active")
            {
                btn_transact.Text = "Transact";
                GetTransactMoveOrderAvailable();
            }
            else
            {
                GetTransactMoveOrderAlready();
                btn_transact.Text = "View";
            }
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                if(cb_status.Text == "Active")
                {
                    GetTransactMoveOrderAvailableBySearch();
                }
                else
                {
                    GetTransactMoveOrderAlreadyBySearch();
                }
            }
        }

        private void dt_move_order_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_move_order.ClearSelection();

            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_move_order.RowCount);
        }
    }
}
