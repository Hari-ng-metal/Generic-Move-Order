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

namespace Generic_Move_Order.Frm_Receiving
{
    public partial class Frm_Receiving : Form
    {
        Connection connect = new Connection();
        int supplier_id = 0;
        int receive_id = 0;
        public Frm_Receiving()
        {
            InitializeComponent();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            SP_GetSupplierById();
            if (label_customer_id.Text == "0" || string.IsNullOrEmpty(text_account.Text))
            {
                //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_supplier.Focus();
                text_name.Clear();
                label_customer_id.Text = "0";
            }
            else
            {
                Frm_Add_Receiving frm = new Frm_Add_Receiving(this);
                frm.ShowDialog();
            }
            btn_edit.Enabled = false;
        }

        private void Frm_Receiving_Load(object sender, EventArgs e)
        {
            GetSupplier();
            text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_receiving.RowCount);
            btn_save.Enabled = false;
            btn_edit.Enabled = false;
            cb_supplier.Text = cb_supplier.Text.ToUpper();
            HeaderName();

            cb_supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_supplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_supplier.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void GetSupplier()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetSupplier", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_supplier.DataSource = dt;
                connect.con.Close();

                cb_supplier.ValueMember = "supplier_name";
                cb_supplier.DisplayMember = "supplier_code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_supplier.SelectedIndex = -1;
            text_name.Clear();
        }

        public void SP_GetSupplierById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetSupplierById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_supplier.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();

            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                supplier_id = int.Parse(dt.Rows[0]["id"].ToString());
                label_customer_id.Text = supplier_id.ToString();
                text_name.Text = dt.Rows[0]["supplier_name"].ToString();
            }
            else
            {
                MessageBox.Show("You enter invalid supplier!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_name.Clear();
                label_customer_id.Text = "0";
            }

        }

        private void InsertReceiving()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertReceiving", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@supplier", supplier_id);
                cmd.Parameters.AddWithValue("@description", text_transaction_description.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);

                cmd.Parameters.AddWithValue("@reference", text_reference.Text);
                cmd.Parameters.AddWithValue("@account", text_account.Text);
                cmd.Parameters.AddWithValue("@company", receiving_account_title.company_code);
                cmd.Parameters.AddWithValue("@dept", receiving_account_title.department_code);
                cmd.Parameters.AddWithValue("@loc", receiving_account_title.location_code);
                cmd.Parameters.AddWithValue("@acc", receiving_account_title.account_code);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                receive_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                Frm_Printing.printing.last_id = receive_id;
                connect.con.Close();

                //MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void InsertReceiveItem()
        {
            int p_id = 0;
            double pqty = 0;

            foreach (DataGridViewRow row in dt_receiving.Rows)
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
                    SqlCommand cmd = new SqlCommand("SP_InsertReceiveItem", connect.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@receive_id", receive_id);
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
            if (cb_supplier.SelectedIndex >= 0)
            {
                text_name.Text = cb_supplier.SelectedValue.ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (cb_supplier.Text == string.Empty || text_transaction_description.Text == string.Empty || text_name.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                SP_GetSupplierById();
                InsertReceiving();
                InsertReceiveItem();
                CallPrintOut();
                ClearRecord();
                text_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cb_supplier.Select();
                cb_supplier.Focus();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Receiving";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void dt_receiving_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_receiving.RowCount);
            if (dt_receiving.RowCount > 0)
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

        private void dt_receiving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_receiving.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_receiving_item.index = e.RowIndex;
                edit_receiving_item.id = Convert.ToInt32(dt_receiving.SelectedRows[0].Cells[0].Value);
                edit_receiving_item.item_code = dt_receiving.SelectedRows[0].Cells[1].Value.ToString();
                edit_receiving_item.item_description = dt_receiving.SelectedRows[0].Cells[2].Value.ToString();
                edit_receiving_item.uom = dt_receiving.SelectedRows[0].Cells[3].Value.ToString();
                edit_receiving_item.quantity = Convert.ToDecimal(dt_receiving.SelectedRows[0].Cells[4].Value);

                btn_edit.Enabled = true;
                //MessageBox.Show("" + e.RowIndex);
            }
            else
            {
                btn_edit.Enabled = false;
            }

   
        }

        private void dt_receiving_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_receiving.ReadOnly = true;
            if (dt_receiving.Columns[e.ColumnIndex].Name == "remove")
            {

                DialogResult res = MessageBox.Show("Are you sure you want to remove?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    dt_receiving.Rows.Remove(dt_receiving.Rows[e.RowIndex]);
                }
                if (res == DialogResult.No)
                {
                    //Some task…  
                }
            }
        }

        private void ClearRecord()
        {
            cb_supplier.Text = "";
            text_name.Clear();
            text_transaction_description.Clear();
            label_customer_id.Text = "0";
            text_account.Clear();
            text_reference.Clear();

            dt_receiving.Rows.Clear();


            receiving_account_title.company_code = null;
            receiving_account_title.department_code = null;
            receiving_account_title.location_code = null;
            receiving_account_title.account_code = null;
        }

        private void cb_supplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Edit_Receiving frm = new Frm_Edit_Receiving(this);
            frm.ShowDialog();
        }

        private void cb_supplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //
                //text_item_desc_from.Text = cb_item_code_from.SelectedValue.ToString();
                SP_GetSupplierById();
                if (string.IsNullOrEmpty(label_customer_id.Text))
                {
                    MessageBox.Show("You enter invalid customer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_name.Clear();
                    label_customer_id.Text = "0";
                }
            }
        }

        private void HeaderName()
        {
            dt_receiving.Columns["id"].HeaderText = "Id";
            dt_receiving.Columns["item_code"].HeaderText = "Item Code";
            dt_receiving.Columns["item_description"].HeaderText = "Item Description";
            dt_receiving.Columns["uom"].HeaderText = "UOM";
            dt_receiving.Columns["quantity"].HeaderText = "Quantity";
            dt_receiving.Columns["remove"].HeaderText = "Remove";

            dt_receiving.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_receiving.EnableHeadersVisualStyles = false;
        }

        private void text_transaction_description_KeyDown(object sender, KeyEventArgs e)
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

        private void text_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Frm_Add_Account_Title frm = new Frm_Add_Account_Title(this);
                frm.ShowDialog();
            }

            if (e.Control && e.KeyCode == Keys.N || e.KeyCode == Keys.Down)
            {
                SP_GetSupplierById();
                if (label_customer_id.Text == "0" || string.IsNullOrEmpty(text_account.Text))
                {
                    //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_supplier.Focus();
                    text_name.Clear();
                    label_customer_id.Text = "0";
                }
                else
                {
                    Frm_Add_Receiving frm = new Frm_Add_Receiving(this);
                    frm.ShowDialog();
                }
                btn_edit.Enabled = false;
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    if (cb_supplier.Text == string.Empty || text_transaction_description.Text == string.Empty || text_name.Text == string.Empty)
                    {
                        MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Some task…
                    SP_GetSupplierById();
                    InsertReceiving();
                    InsertReceiveItem();
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
    }
}
