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

namespace Generic_Move_Order.Frm_Miscellaneous_Issue
{
    public partial class Frm_Issue : Form
    {
        Connection connect = new Connection();
        int customer_id = 0;
        int move_id = 0;
        public Frm_Issue()
        {
            InitializeComponent();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Issue_Load(object sender, EventArgs e)
        {
            GetWarehouse();
            GetCustomer();
            text_warehouse_name.Clear();
            text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_issue.RowCount);
            btn_save.Enabled = false;
            btn_edit.Enabled = false;
            cb_customer.Text = cb_customer.Text.ToUpper();
            HeaderName();

            cb_customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_customer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_customer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetWarehouse()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetWarehouse", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_warehouse.DataSource = dt;
                connect.con.Close();

                cb_warehouse.ValueMember = "warehouse";
                cb_warehouse.DisplayMember = "code";

                cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_warehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_warehouse.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_warehouse.SelectedIndex = -1;
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
            SqlCommand cmd = new SqlCommand("SP_GetCustomerOnlyById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_customer.Text);
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
                MessageBox.Show("You enter invalid customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_name.Clear();
                label_customer_id.Text = "0";
            }

        }

        private void InsertIssue()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertIssue", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@warehouse", cb_warehouse.Text);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@description", text_transaction_description.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);

                cmd.Parameters.AddWithValue("@reference", text_reference.Text);
                cmd.Parameters.AddWithValue("@account", text_account.Text);
                cmd.Parameters.AddWithValue("@company", issue_account_title.company_code);
                cmd.Parameters.AddWithValue("@dept", issue_account_title.department_code);
                cmd.Parameters.AddWithValue("@loc", issue_account_title.location_code);
                cmd.Parameters.AddWithValue("@acc", issue_account_title.account_code);
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

        public void InsertIssueItem()
        {
            int p_id = 0;
            double pqty = 0;

            foreach (DataGridViewRow row in dt_issue.Rows)
            {
                //More code here
                if (row.Cells["id"].Value == null)
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
                    SqlCommand cmd = new SqlCommand("SP_InsertIssueItem", connect.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@issue_id", move_id);
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

        private void HeaderName()
        {
            dt_issue.Columns["id"].HeaderText = "Id";
            dt_issue.Columns["item_code"].HeaderText = "Item Code";
            dt_issue.Columns["item_description"].HeaderText = "Item Description";
            dt_issue.Columns["uom"].HeaderText = "UOM";
            dt_issue.Columns["quantity"].HeaderText = "Quantity";
            dt_issue.Columns["remove"].HeaderText = "Remove";

            dt_issue.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_issue.EnableHeadersVisualStyles = false;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            //SP_GetCustomerById();
            //if (label_customer_id.Text == "0" || string.IsNullOrEmpty(text_account.Text))
            //{
            //    //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cb_customer.Focus();
            //    text_name.Clear();
            //    label_customer_id.Text = "0";
            //}
            //else
            //{
            //    Frm_Add_Issue frm = new Frm_Add_Issue(this);
            //    frm.ShowDialog();
            //}
            //btn_edit.Enabled = false;

            SP_GetCustomerById();
            if (label_customer_id.Text == "0")
            {
                //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_customer.Focus();
                text_name.Clear();
                label_customer_id.Text = "0";
            }
            else if (string.IsNullOrEmpty(cb_warehouse.Text))
            {
                cb_warehouse.Focus();
            }
            else if (string.IsNullOrEmpty(text_account.Text))
            {
                text_account.Focus();
            }
            else
            {
                Frm_Add_Issue frm = new Frm_Add_Issue(this);
                frm.ShowDialog();
            }
            btn_edit.Enabled = false;
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                InsertIssue();
                InsertIssueItem();
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
            Frm_Printing.printing.report_name = "Issue";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void ClearRecord()
        {
            cb_customer.Text = "";
            text_name.Clear();
            text_transaction_description.Clear();
            label_customer_id.Text = "0";
            text_account.Clear();
            text_reference.Clear();

            dt_issue.Rows.Clear();

            issue_account_title.company_code = null;
            issue_account_title.department_code = null;
            issue_account_title.location_code = null;
            issue_account_title.account_code = null;
        }

        private void dt_issue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_issue.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_issue_item.index = e.RowIndex;
                edit_issue_item.id = Convert.ToInt32(dt_issue.SelectedRows[0].Cells[0].Value);
                edit_issue_item.item_code = dt_issue.SelectedRows[0].Cells[1].Value.ToString();
                edit_issue_item.item_description = dt_issue.SelectedRows[0].Cells[2].Value.ToString();
                edit_issue_item.uom = dt_issue.SelectedRows[0].Cells[3].Value.ToString();
                edit_issue_item.quantity = Convert.ToDecimal(dt_issue.SelectedRows[0].Cells[4].Value);

                btn_edit.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void dt_issue_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_issue.RowCount);
            if (dt_issue.RowCount > 0)
            {
                btn_save.Enabled = true;
            }
            else
            {
                btn_save.Enabled = false;
            }
        }

        private void dt_issue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_issue.ReadOnly = true;
            if (dt_issue.Columns[e.ColumnIndex].Name == "remove")
            {

                DialogResult res = MessageBox.Show("Are you sure you want to remove?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    dt_issue.Rows.Remove(dt_issue.Rows[e.RowIndex]);
                }
                if (res == DialogResult.No)
                {
                    //Some task…  
                }
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Edit_Issue frm = new Frm_Edit_Issue(this);
            frm.ShowDialog();
        }

        private void text_transaction_description_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void text_account_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void text_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Frm_Add_Account_Title frm = new Frm_Add_Account_Title(this);
                frm.ShowDialog();
            }

            //keydown
            if (e.Control && e.KeyCode == Keys.N || e.KeyCode == Keys.Down)
            {
                SP_GetCustomerById();
                if (label_customer_id.Text == "0")
                {
                    //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_customer.Focus();
                    text_name.Clear();
                    label_customer_id.Text = "0";
                }
                else if (string.IsNullOrEmpty(cb_warehouse.Text))
                {
                    cb_warehouse.Focus();
                }
                else if(string.IsNullOrEmpty(text_account.Text))
                {
                    text_account.Focus();
                }
                else
                {
                    Frm_Add_Issue frm = new Frm_Add_Issue(this);
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
                    SP_GetCustomerById();
                    InsertIssue();
                    InsertIssueItem();
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

        private void text_account_DoubleClick(object sender, EventArgs e)
        {
            Frm_Add_Account_Title frm = new Frm_Add_Account_Title(this);
            frm.ShowDialog();
        }

        private void cb_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_warehouse.SelectedIndex >= 0)
            {
                text_warehouse_name.Clear();
                text_warehouse_name.Text = cb_warehouse.SelectedValue.ToString();
            }
        }
    }
}
