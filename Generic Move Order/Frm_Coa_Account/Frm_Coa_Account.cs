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

namespace Generic_Move_Order.Frm_Coa_Account
{
    public partial class Frm_Coa_Account : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Coa_Account()
        {
            InitializeComponent();
        }

        private void Frm_Coa_Account_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_coa_account.id = 0;
            Frm_Add_Coa_Account frm = new Frm_Add_Coa_Account(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetCoaAccount()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaAccount", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_account.DataSource = dt;
            connect.con.Close();

            dt_account.ReadOnly = true;
        }

        public void GetCoaAccountBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaAccountBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_account.DataSource = dt;
            connect.con.Close();
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_status.Text == "Active")
            {
                status = bool.Parse(true.ToString());
            }
            else
            {
                status = bool.Parse(false.ToString());
            }
            GetCoaAccount();
            label_role_counting.Text = "TOTAL # OF ACCOUNT/S: " + (dt_account.RowCount);
        }

        private void dt_account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_account.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_coa_account.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_coa_account.code = row.Cells["code"].Value.ToString();
                edit_coa_account.account = row.Cells["account"].Value.ToString();
                edit_coa_account.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Coa_Account frm = new Frm_Add_Coa_Account(this);
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            dt_account.Columns["id"].HeaderText = "Id";
            dt_account.Columns["code"].HeaderText = "Code";
            dt_account.Columns["account"].HeaderText = "Account";
            dt_account.Columns["status"].HeaderText = "Status";
            dt_account.Columns["date_added"].HeaderText = "Date Added";

            dt_account.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_account.EnableHeadersVisualStyles = false;
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetCoaAccountBySearch();
            }
        }

        private void dt_account_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_account.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF ACCOUNT/S: " + (dt_account.RowCount);
        }

        private void cb_status_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
