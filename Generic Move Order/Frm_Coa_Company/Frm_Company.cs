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

namespace Generic_Move_Order.Frm_Coa_Company
{
    public partial class Frm_Company : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Company()
        {
            InitializeComponent();
        }

        private void Frm_Company_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_coa_company.id = 0;
            Frm_Add_Coa_Company frm = new Frm_Add_Coa_Company(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetCoaCompany()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaCompany", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_company.DataSource = dt;
            connect.con.Close();

            dt_company.ReadOnly = true;
        }

        public void GetCoaCompanyBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaCompanyBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_company.DataSource = dt;
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
            GetCoaCompany();
            label_role_counting.Text = "TOTAL # OF ACCOUNT/S: " + (dt_company.RowCount);
        }

        private void dt_company_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_company.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_coa_company.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_coa_company.code = row.Cells["code"].Value.ToString();
                edit_coa_company.company = row.Cells["company"].Value.ToString();
                edit_coa_company.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Coa_Company frm = new Frm_Add_Coa_Company(this);
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            dt_company.Columns["id"].HeaderText = "Id";
            dt_company.Columns["code"].HeaderText = "Code";
            dt_company.Columns["company"].HeaderText = "Company";
            dt_company.Columns["status"].HeaderText = "Status";
            dt_company.Columns["date_added"].HeaderText = "Date Added";

            dt_company.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_company.EnableHeadersVisualStyles = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetCoaCompanyBySearch();
            }
        }

        private void dt_company_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_company.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF COMPANY/S: " + (dt_company.RowCount);
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
