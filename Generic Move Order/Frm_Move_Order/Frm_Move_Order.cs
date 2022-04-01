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
        int b_category = 0;
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
            CustomDatePicker();
            GetBCategory();
            text_name.Clear();
            //GetCustomer();
            GetReason();
            text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_move.RowCount);
            btn_save.Enabled = false;
            btn_edit.Enabled = false;
            cb_customer.Text = cb_customer.Text.ToUpper();
            HeaderName();
        }

        private void CustomDatePicker()
        {
            dp_delivery_date.CustomFormat = "MM/dd/yyyy";
            dp_delivery_date.MinDate = DateTime.Now.Date.AddDays(-1);
            dp_delivery_date.MaxDate = DateTime.Now.AddDays(30).Date;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            //SP_GetCustomerById(); old
            SP_GetCustomerDetailsBy();
            if (label_customer_id.Text == "0" || string.IsNullOrEmpty(cb_reason.Text))
            {
                //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_customer.Focus();
                text_name.Clear();
                label_customer_id.Text = "0";
            }
            else if(string.IsNullOrEmpty(text_account.Text))
            {
                text_account.Focus();
            }
            else
            {
                Frm_Add_Move_Order frm = new Frm_Add_Move_Order(this);
                frm.ShowDialog();
            }
            btn_edit.Enabled = false;

        }

        //old code
        //public void GetCustomer()
        //{
        //    try
        //    {
        //        connect.DatabaseConnection();
        //        connect.con.Open();
        //        SqlCommand cmd = new SqlCommand("SP_GetCustomer", connect.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@status", true);
        //        DataTable dt = new DataTable();
        //        dt.Load(cmd.ExecuteReader());
        //        cb_customer.DataSource = dt;
        //        connect.con.Close();

        //        cb_customer.ValueMember = "customer_name";
        //        cb_customer.DisplayMember = "customer_code";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        throw;
        //    }
        //    cb_customer.SelectedIndex = -1;
        //    text_name.Clear();
        //}

        //get customer list where business category id = selected id
        public void GetCustomerByBCategory()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCustomerByBCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                cmd.Parameters.AddWithValue("@bcategory_id", b_category);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_customer.DataSource = dt;
                connect.con.Close();

                cb_customer.ValueMember = "customer_name";
                cb_customer.DisplayMember = "customer_code";

                cb_customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_customer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_customer.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_customer.SelectedIndex = -1;
            cb_customer.Text = "";
            text_name.Clear();
        }

        //old code
        //public void SP_GetCustomerById()
        //{
        //    connect.DatabaseConnection();
        //    connect.con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_GetCustomerById", connect.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@code", cb_customer.Text);
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    //dt_module.DataSource = dt;
        //    connect.con.Close();
            
        //    if(dt.Rows.Count > 0)
        //    {
        //        //MessageBox.Show("" + dt.Rows[0]["item_description"]);
        //        customer_id = int.Parse(dt.Rows[0]["id"].ToString());
        //        label_customer_id.Text = customer_id.ToString();
        //        text_name.Text = dt.Rows[0]["customer_name"].ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("You enter invalid customer!"+dt.Rows.Count, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        text_name.Clear();
        //        label_customer_id.Text = "0";
        //    }
        //}


        //validate if enter to get the id
        //public void SP_GetCustomerByIdandBCategory()
        //{
        //    connect.DatabaseConnection();
        //    connect.con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_GetCustomerByIdandBCategory", connect.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@code", cb_customer.Text.Trim());
        //    cmd.Parameters.AddWithValue("@bcategory_id", label_bcategory_id.Text);
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    //dt_module.DataSource = dt;
        //    connect.con.Close();

        //    if (dt.Rows.Count > 0)
        //    {
        //        //MessageBox.Show("" + dt.Rows[0]["item_description"]);
        //        customer_id = int.Parse(dt.Rows[0]["id"].ToString());
        //        label_customer_id.Text = customer_id.ToString();
        //        text_name.Text = dt.Rows[0]["customer_name"].ToString();
        //        label_customer_id.Text = customer_id.ToString();
        //    }
        //    //if(string.IsNullOrEmpty(text_name.Text))
        //    //{
        //    //    //MessageBox.Show("You enter invalid customer!"+dt.Rows.Count, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    text_name.Clear();
        //    //    label_customer_id.Text = "0";
        //    //    cb_customer.SelectedIndex = -1;
        //    //    cb_customer.Text = "";
        //    //}
        //}

        //combo box key.enter - validate if b category is exist
        //public void SP_GetBCategoryByCode()
        //{
        //    connect.DatabaseConnection();
        //    connect.con.Open();
        //    SqlCommand cmd = new SqlCommand("SP_GetBCategoryByCode", connect.con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@status", true);
        //    cmd.Parameters.AddWithValue("@bcategory", cb_bcategory.Text);
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    //dt_module.DataSource = dt;
        //    connect.con.Close();

        //    if (dt.Rows.Count > 0)
        //    {
        //        //MessageBox.Show("" + dt.Rows[0]["item_description"]);
        //        b_category = int.Parse(dt.Rows[0]["id"].ToString());
        //    }
        //    else
        //    {
        //        MessageBox.Show("You enter invalid business category!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        cb_bcategory.SelectedIndex = -1;
        //        cb_bcategory.Text = "";
        //    }
        //}
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
                cmd.Parameters.AddWithValue("@reason", cb_reason.Text);
                cmd.Parameters.AddWithValue("@reference", text_reference.Text);
                cmd.Parameters.AddWithValue("@account", text_account.Text);
                cmd.Parameters.AddWithValue("@date", dp_delivery_date.Text);
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
            double pslab = 0;

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
                    pslab = float.Parse(row.Cells["slab"].Value.ToString());
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
                    cmd.Parameters.AddWithValue("@slab", pslab);
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

        //selected index
        public void SP_GetCustomerDetailsBy()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCustomerById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_customer.Text);
            cmd.Parameters.AddWithValue("@b_category", cb_bcategory.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();

            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                customer_id = int.Parse(dt.Rows[0]["id"].ToString());
                label_customer_id.Text = customer_id.ToString();
                text_name.Text = dt.Rows[0]["customer_name"].ToString();
            }
            else
            {
                text_name.Clear();
                label_customer_id.Text = "0";
            }

        }

        public void GetReason()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetReason", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_reason.DataSource = dt;
                connect.con.Close();

                cb_reason.ValueMember = "id";
                cb_reason.DisplayMember = "reason";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_reason.SelectedIndex = -1;
        }

        public void GetBCategory()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetBCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_bcategory.DataSource = dt;
                connect.con.Close();

                cb_bcategory.ValueMember = "id";
                cb_bcategory.DisplayMember = "business_category";

                cb_bcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_bcategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_bcategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_bcategory.SelectedIndex = -1;
            b_category = 0;
            label_bcategory_id.Text = "0";
        }


        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_customer.SelectedIndex >= 0)
            {
                text_name.Clear();
                text_name.Text = cb_customer.SelectedValue.ToString();
                SP_GetCustomerDetailsBy();
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
                //SP_GetCustomerById();
                //GetCustomerByBCategory();
                SP_GetCustomerDetailsBy();
                InsertMoveOrder();
                InsertMoveOrderItem();
                CallPrintOut();
                ClearRecord();
                text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cb_customer.Select();
                cb_customer.Focus();
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
                edit_move_item.uom = dt_move.SelectedRows[0].Cells[3].Value.ToString();
                edit_move_item.quantity = Convert.ToDecimal(dt_move.SelectedRows[0].Cells[4].Value);
                edit_move_item.slab = Convert.ToDecimal(dt_move.SelectedRows[0].Cells[5].Value);

                btn_edit.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void dt_move_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_move.ReadOnly = true;
            if (dt_move.Columns[e.ColumnIndex].Name == "remove")
            {
              
                DialogResult res = MessageBox.Show("Are you sure you want to remove?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    dt_move.Rows.Remove(dt_move.Rows[e.RowIndex]);
                }
                if (res == DialogResult.No)
                {
                    //Some task…  
                }
            }
        }

        private void ClearRecord()
        {
            cb_customer.Text = "";
            text_name.Clear();
            text_transaction_description.Clear();
            label_customer_id.Text = "0";
            cb_reason.Text = "";
            cb_bcategory.Text = "";
            cb_bcategory.SelectedIndex = -1;
            text_reference.Clear();
            text_account.Clear();
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                text_name.Clear();
                cb_customer_SelectedIndexChanged(sender, e);
                SP_GetCustomerDetailsBy();

                if (string.IsNullOrEmpty(text_name.Text))
                {
                    MessageBox.Show("You enter invalid customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Edit_Move_Order frm = new Frm_Edit_Move_Order(this);
            frm.ShowDialog();
        }

        private void cb_customer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Move_Order_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Frm_Move_Order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                Frm_Add_Move_Order frm = new Frm_Add_Move_Order(this);
                frm.ShowDialog();
            }
        }

        private void text_transaction_description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                //SP_GetCustomerById();
                //GetCustomerByBCategory();
                if (label_customer_id.Text == "0")
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
            if (e.Control && e.KeyCode == Keys.S)
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
                    //SP_GetCustomerById();
                    //GetCustomerByBCategory();
                    InsertMoveOrder();
                    InsertMoveOrderItem();
                    CallPrintOut();
                    ClearRecord();
                    text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (res == DialogResult.No)
                {
                    //Some task…  
                }
            }
        }

        private void HeaderName()
        {
            dt_move.Columns["id"].HeaderText = "Id";
            dt_move.Columns["item_code"].HeaderText = "Item Code";
            dt_move.Columns["item_description"].HeaderText = "Item Description";
            dt_move.Columns["uom"].HeaderText = "UOM";
            dt_move.Columns["quantity"].HeaderText = "Quantity";
            dt_move.Columns["slab"].HeaderText = "Slab/Bag";
            dt_move.Columns["remove"].HeaderText = "Remove";

            dt_move.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_move.EnableHeadersVisualStyles = false;
        }

        private void cb_reason_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_bcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_bcategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void cb_bcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //cb_bcategory_SelectedIndexChanged(sender, e);
                cb_bcategory_SelectionChangeCommitted(sender, e);

                if (label_bcategory_id.Text == "0")
                {
                        MessageBox.Show("You enter invalid business category!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_customer.SelectedIndex = -1;
                    text_name.Clear();
                }
            }
        }

        private void text_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N || e.KeyCode == Keys.Down)
            {
                //SP_GetCustomerById(); old
                if (label_customer_id.Text == "0")
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
            if (e.Control && e.KeyCode == Keys.S)
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
                    //SP_GetCustomerById();
                    InsertMoveOrder();
                    InsertMoveOrderItem();
                    CallPrintOut();
                    ClearRecord();
                    text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (res == DialogResult.No)
                {
                    //Some task…  
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                Frm_Add_Account_Title frm = new Frm_Add_Account_Title(this);
                frm.ShowDialog();
            }
            }

        private void text_account_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void text_account_DoubleClick(object sender, EventArgs e)
        {
            Frm_Add_Account_Title frm = new Frm_Add_Account_Title(this);
            frm.ShowDialog();
        }

        private void text_account_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_bcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //
            label_bcategory_id.Text = "0";
            try
            {
                if (cb_bcategory.SelectedIndex >= 0)
                {
                    b_category = int.Parse(cb_bcategory.SelectedValue.ToString());
                    label_bcategory_id.Text = b_category.ToString();
                    GetCustomerByBCategory();
                    //MessageBox.Show("" + b_category);
                }
            }
            catch (Exception)
            {
                //Whatever you want to do when it is not an int
            }
        }

        private void cb_customer_Leave(object sender, EventArgs e)
        {

        }

        private void dp_delivery_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
