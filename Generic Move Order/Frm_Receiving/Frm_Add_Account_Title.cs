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
    public partial class Frm_Add_Account_Title : Form
    {
        Connection connect = new Connection();
        Frm_Receiving frm;
        public Frm_Add_Account_Title(Frm_Receiving _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void Frm_Add_Account_Title_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void account()
        {
            receiving_account_title.company_code = cb_company.Text;
            receiving_account_title.department_code = cb_department.Text;
            receiving_account_title.location_code = cb_location.Text;
            receiving_account_title.account_code = cb_account.Text;

            string account = cb_company.Text + "." + cb_department.Text + "." + cb_location.Text + "." + cb_account.Text;
            frm.text_account.Text = account;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_company.Text) || string.IsNullOrEmpty(text_dept.Text) || string.IsNullOrEmpty(text_loc.Text) || string.IsNullOrEmpty(text_acc.Text))
            {
                MessageBox.Show("Please input the required field", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                account();
                this.Close();
            }
        }

        private void LoadAccount()
        {
            cb_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_company.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_company.AutoCompleteSource = AutoCompleteSource.ListItems;

            cb_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_location.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_location.AutoCompleteSource = AutoCompleteSource.ListItems;

            cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_department.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_department.AutoCompleteSource = AutoCompleteSource.ListItems;

            cb_account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_account.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_account.AutoCompleteSource = AutoCompleteSource.ListItems;

            GetCompany();
            GetLocation();
            GetDepartment();
            GetAccount();
        }

        public void GetCompany()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCoaCompany", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_company.DataSource = dt;
                connect.con.Close();

                cb_company.ValueMember = "company";
                cb_company.DisplayMember = "code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_company.SelectedIndex = -1;
            text_company.Clear();
        }

        public void GetLocation()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCoaLocation", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_location.DataSource = dt;
                connect.con.Close();

                cb_location.ValueMember = "location";
                cb_location.DisplayMember = "code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_location.SelectedIndex = -1;
            text_loc.Clear();
        }

        public void GetDepartment()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCoaDepartment", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_department.DataSource = dt;
                connect.con.Close();

                cb_department.ValueMember = "department";
                cb_department.DisplayMember = "code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_department.SelectedIndex = -1;
            text_dept.Clear();
        }

        public void GetAccount()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCoaAccount", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_account.DataSource = dt;
                connect.con.Close();

                cb_account.ValueMember = "account";
                cb_account.DisplayMember = "code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_account.SelectedIndex = -1;
            text_acc.Clear();
        }

        private void cb_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_company.SelectedIndex >= 0)
            {
                text_company.Text = cb_company.SelectedValue.ToString();
            }
        }

        private void cb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_department.SelectedIndex >= 0)
            {
                text_dept.Text = cb_department.SelectedValue.ToString();
            }
        }

        private void cb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_location.SelectedIndex >= 0)
            {
                text_loc.Text = cb_location.SelectedValue.ToString();
            }
        }

        private void cb_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_account.SelectedIndex >= 0)
            {
                text_acc.Text = cb_account.SelectedValue.ToString();
            }
        }

        private void cb_account_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cb_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(text_company.Text) || string.IsNullOrEmpty(text_dept.Text) || string.IsNullOrEmpty(text_loc.Text) || string.IsNullOrEmpty(text_acc.Text))
                {
                    MessageBox.Show("Please input the required field", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    account();
                    this.Close();
                }
            }
        }
    }
}
