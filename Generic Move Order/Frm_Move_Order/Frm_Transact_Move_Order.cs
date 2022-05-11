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
    public partial class Frm_Transact_Move_Order : Form
    {
        Connection connect = new Connection();
        Frm_Available_Transact frm;
        public Frm_Transact_Move_Order(Frm_Available_Transact _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void Frm_Transact_Move_Order_Load(object sender, EventArgs e)
        {
            CustomDatePicker();
            ShowMoeOrderDetails();
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_move.RowCount);
            dt_move.Columns["actual_quantity"].ReadOnly = false;
            dt_move.Columns["reason"].ReadOnly = false;
            dt_move.Columns["item_code"].ReadOnly = true;
            dt_move.Columns["item_description"].ReadOnly = true;
            dt_move.Columns["uom"].ReadOnly = true;
            dt_move.Columns["quantity"].ReadOnly = true;

            HeaderName();
            FIllQuantityReceived();
        }

        private void CustomDatePicker()
        {
            dp_delivery_date.CustomFormat = "MM/dd/yyyy";
            dp_delivery_date.MinDate = DateTime.Now.Date.AddDays(-60);
            dp_delivery_date.MaxDate = DateTime.Now.Date.AddDays(7);
        }

        private void FIllQuantityReceived()
        {
            dt_move.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            for (int i = 0; i < dt_move.Rows.Count; i++)
            {
                dt_move.Rows[i].Cells[5].Value = dt_move.Rows[i].Cells[4].Value;
            }
        }

        private void ShowMoeOrderDetails()
        {
            text_sales_id.Text = view_move_order.id.ToString();
            text_date.Text = view_move_order.transaction_date.ToString("MM/dd/yyyy");
            text_name.Text = view_move_order.customer_name;
            text_code.Text = view_move_order.customer_code;
            text_transaction_description.Text = view_move_order.description;
            dp_delivery_date.Text = view_move_order.delivery_date.ToString("MM/dd/yyyy");

            GetMoveOrderItemById();
        }

        public void GetMoveOrderItemById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTransactMoveOrderItemById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", view_move_order.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move.DataSource = dt;
            connect.con.Close();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_move_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4) // 1 should be your column index
            {
                float i;

                if (!float.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please input numeric");
                }
                else
                {
                    // the input is numeric 
                }
            }
        }

        private void TransactMoveOrderItem()
        {
            int p_id = 0;
            float pqty = 0;
            string reason = "";
            foreach (DataGridViewRow row in dt_move.Rows)
            {
                //More code here
                if (row.Cells["id"].Value == null)
                {
                    return;
                }
                else
                {
                    p_id = int.Parse(row.Cells["id"].Value.ToString());
                    pqty = float.Parse(row.Cells["actual_quantity"].Value.ToString());
                    reason = row.Cells["reason"].Value.ToString();
                    //MessageBox.Show("" +"id= "+ p_id +" " +"acual: " +pqty);
                }

                try
                {
                    connect.con.Open();
                    SqlCommand cmd = new SqlCommand("SP_UpdateTransactMoveOrderActualQtyItemById", connect.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", p_id);
                    cmd.Parameters.AddWithValue("@actual", pqty);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    //dt_report.DataSource = dt;
                    connect.con.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show("Takla");
                    throw;
                }
            }

            MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TransactMoveOrder()
        {
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateTransactMoveOrderById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", text_sales_id.Text);
            cmd.Parameters.AddWithValue("@del_date", dp_delivery_date.Text);
            cmd.Parameters.AddWithValue("@user", User.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
        }

        private void btn_transact_Click(object sender, EventArgs e)
        {
            bool isnull = true;

            DialogResult res = MessageBox.Show("Are you sure you want to transact?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dt_move.Rows)
                {
                    //More code here
                    if (row.Cells["actual_quantity"].Value.ToString() == string.Empty)
                    {
                        //MessageBox.Show("wala");
                        //return;
                    }
                    else
                    {
                        isnull = false;
                    }
                }
                if(isnull == true)
                {
                    MessageBox.Show("Please input the actual quantity received!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Some task…
                    TransactMoveOrderItem();
                    TransactMoveOrder();
                    frm.GetTransactMoveOrderAvailable();
                    this.Close();
                    frm.dt_move_order.ClearSelection();
                    frm.btn_transact.Enabled = false;
                }

            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HeaderName()
        {
            dt_move.Columns["id"].HeaderText = "Id";
            dt_move.Columns["item_code"].HeaderText = "Item Code";
            dt_move.Columns["item_description"].HeaderText = "Item Description";
            dt_move.Columns["uom"].HeaderText = "UOM";
            dt_move.Columns["quantity"].HeaderText = "Quantity";
            dt_move.Columns["actual_quantity"].HeaderText = "Actual Quantity";
            dt_move.Columns["reason"].HeaderText = "Reason";

            dt_move.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_move.EnableHeadersVisualStyles = false;
        }

        private void dt_move_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dt_move_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);

                //NEW COLUMN ACTUAL - NUMERIC ONLY
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                if (dt_move.CurrentCell.ColumnIndex == 5) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }

                //NEW COLUMN ACTUAL - NUMERIC ONLY
                e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
                if (dt_move.CurrentCell.ColumnIndex == 6) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        //private void Control_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //        (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void dp_delivery_date_ValueChanged(object sender, EventArgs e)
        {
            btn_transact.Enabled = true;
        }

        private void dp_delivery_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
