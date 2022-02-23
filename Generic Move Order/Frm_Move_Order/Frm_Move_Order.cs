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
    public partial class Frm_Move_Order : Form
    {
        Connection connect = new Connection();
        int customer_id = 0;
        int move_id = 0;
        public Frm_Move_Order()
        {
            InitializeComponent();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Move_Order_Load(object sender, EventArgs e)
        {
            GetCustomer();
            text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label_counting.Text = "TOTAL # OF MODULE/S: " + (dt_move.RowCount);
            btn_save.Enabled = false;
            btn_edit.Enabled = false;
            cb_customer.Text = cb_customer.Text.ToUpper();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            SP_GetCustomerById();
            if(label_customer_id.Text == "0")
            {
                //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_customer.Focus();
                text_name.Clear();
                label_customer_id.Text = "0";
            }
            else
            {
                Frm_Add_Move_Order frm = new Frm_Add_Move_Order(this);
                frm.ShowDialog();
            }
            btn_edit.Enabled = false;

        }

        public void GetCustomer()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCustomer", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_customer.DataSource = dt;
                connect.con.Close();

                cb_customer.ValueMember = "customer_name";
                cb_customer.DisplayMember = "customer_code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_customer.SelectedIndex = -1;
            text_name.Clear();
        }

        public void SP_GetCustomerById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCustomerById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_customer.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();
            
            if(dt.Rows.Count > 0)
            {
                //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                customer_id = int.Parse(dt.Rows[0]["id"].ToString());
                label_customer_id.Text = customer_id.ToString();
                text_name.Text = dt.Rows[0]["customer_name"].ToString();
            }
            else
            {
                MessageBox.Show("You enter invalid customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_name.Clear();
                label_customer_id.Text = "0";
            }

        }

        private void InsertMoveOrder()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertMoveOrder", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@description", text_transaction_description.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                move_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                Frm_Printing.printing.last_id = move_id;
                connect.con.Close();

                //MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void InsertMoveOrderItem()
        {
            int p_id = 0;
            double pqty = 0;

            foreach (DataGridViewRow row in dt_move.Rows)
            {
                //More code here
              if(row.Cells["id"].Value == null)
                {
                    return;
                }
              else
                {
                    p_id = int.Parse(row.Cells["id"].Value.ToString());
                    pqty = float.Parse(row.Cells["quantity"].Value.ToString());
                    //MessageBox.Show("" + p_id);
                }

                try
                {
                    connect.con.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertMoveOrderItem", connect.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@move_id", move_id);
                    cmd.Parameters.AddWithValue("@item_id", int.Parse(p_id.ToString()));
                    cmd.Parameters.AddWithValue("@quantity", pqty);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    //dt_report.DataSource = dt;
                    connect.con.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }

            MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (cb_customer.SelectedIndex >= 0)
            {
                text_name.Text = cb_customer.SelectedValue.ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (cb_customer.Text == string.Empty || text_transaction_description.Text == string.Empty || text_name.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                SP_GetCustomerById();
                InsertMoveOrder();
                InsertMoveOrderItem();
                CallPrintOut();
                ClearRecord();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }

           
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "MoveOrder";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void dt_move_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_move.RowCount);
            if(dt_move.RowCount > 0)
            {
                btn_save.Enabled = true;
            }
            else
            {
                btn_save.Enabled = false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to cancel?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void dt_move_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_move.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_move_item.index = e.RowIndex;
                edit_move_item.id = Convert.ToInt32(dt_move.SelectedRows[0].Cells[0].Value);
                edit_move_item.item_code = dt_move.SelectedRows[0].Cells[1].Value.ToString();
                edit_move_item.item_description = dt_move.SelectedRows[0].Cells[2].Value.ToString();
                edit_move_item.quantity = Convert.ToDecimal(dt_move.SelectedRows[0].Cells[3].Value);

                btn_edit.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void dt_move_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt_move.Columns[e.ColumnIndex].Name == "remove")
            {
                dt_move.Rows.Remove(dt_move.Rows[e.RowIndex]);
            }
        }

        private void ClearRecord()
        {
            cb_customer.Text = "";
            text_name.Clear();
            text_transaction_description.Clear();
            label_customer_id.Text = "0";

            dt_move.Rows.Clear();
        }

        private void cb_customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void cb_customer_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (e.KeyCode == Keys.Enter)
            {
                //
                //text_item_desc_from.Text = cb_item_code_from.SelectedValue.ToString();
                SP_GetCustomerById();
                if (string.IsNullOrEmpty(label_customer_id.Text))
                {
                    MessageBox.Show("You enter invalid customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_name.Clear();
                    label_customer_id.Text = "0";
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Edit_Move_Order frm = new Frm_Edit_Move_Order(this);
            frm.ShowDialog();
        }
    }
}
