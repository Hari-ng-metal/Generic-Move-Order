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
    public partial class Frm_Add_Account_Title : Form
    {
        Connection connect = new Connection();
        Frm_Move_Order frm;
        public Frm_Add_Account_Title(Frm_Move_Order _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void account()
        {
            account_title.company_code = cb_company.Text;
            account_title.department_code = cb_department.Text;
            //old without restriction
            //account_title.location_code = cb_location.Text;

            //new with restriction dep to loc
            account_title.location_code = cb_tag_location.Text;
            account_title.account_code = cb_account.Text;

            //string account = cb_company.Text + "." + cb_department.Text + "." + cb_location.Text + "." + cb_account.Text;
            string account = cb_company.Text + "." + cb_department.Text + "." + cb_tag_location.Text + "." + cb_account.Text;
            frm.text_account.Text = account;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //CheckAccountTitle();
            if (string.IsNullOrEmpty(text_company.Text) || string.IsNullOrEmpty(text_dept.Text) || string.IsNullOrEmpty(text_loc.Text) || string.IsNullOrEmpty(text_acc.Text))
            {
                MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

        private void Frm_Add_Account_Title_Load(object sender, EventArgs e)
        {
            LoadAccount();
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

                //enable when select department - for comment to be up once ok
                GetLocationByDepartment();
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

        private void cb_account_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (e.KeyCode == Keys.Enter)
            {
                //CheckAccountTitle();
                if (string.IsNullOrEmpty(text_company.Text) || string.IsNullOrEmpty(text_dept.Text) || string.IsNullOrEmpty(text_loc.Text) || string.IsNullOrEmpty(text_acc.Text))
                {
                    MessageBox.Show("Please input the required field", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    account();
                    this.Close();
                }
            }
              
        }

        private void CheckDepartment()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coa_code", text_dept.Text);
            cmd.Parameters.AddWithValue("@mode", "coa_department");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    //MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                text_dept.Clear();
                this.Close();
            }
        }

        private void CheckCompany()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coa_code", text_company.Text);
            cmd.Parameters.AddWithValue("@mode", "coa_company");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    //MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                text_company.Clear();
                this.Close();
            }
        }

        private void CheckLocation()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coa_code", text_loc.Text);
            cmd.Parameters.AddWithValue("@mode", "coa_location");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    //MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                text_loc.Clear();
                this.Close();
            }
        }

        private void CheckAccount()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coa_code", text_acc.Text);
            cmd.Parameters.AddWithValue("@mode", "coa_account");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    //MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                text_acc.Clear();
                this.Close();
            }
        }
        //comment
        private void CheckAccountTitle()
        {
            CheckCompany();
            CheckDepartment();
            CheckLocation();
            CheckAccount();
        }

        private void cb_location_Leave(object sender, EventArgs e)
        {

        }

        //for cb tagging of department to location
        public void GetLocationByDepartment()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetTaggedLocation", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                cmd.Parameters.AddWithValue("@department", cb_department.Text);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_tag_location.DataSource = dt;
                connect.con.Close();

                cb_tag_location.ValueMember = "location";
                cb_tag_location.DisplayMember = "code";

                cb_tag_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_tag_location.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_tag_location.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_tag_location.SelectedIndex = -1;
            cb_tag_location.Text = "";
            text_loc.Clear();
        }

        //for cb tagging of department to location
        private void cb_tag_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tag_location.SelectedIndex >= 0)
            {
                text_loc.Text = cb_tag_location.SelectedValue.ToString();
            }
        }
    }
}
