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

namespace Generic_Move_Order.Frm_Customer
{
    public partial class Frm_Customer : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Customer()
        {
            InitializeComponent();
        }

        private void Frm_Customer_Load(object sender, EventArgs e)
        {
            //
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        public void GetCustomer()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCustomer", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_customer.DataSource = dt;
            connect.con.Close();

            dt_customer.Columns["area_id"].Visible = false;
            dt_customer.Columns["business_category_id"].Visible = false;
            dt_customer.ReadOnly = true;
        }

        public void GetCustomerBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCustomerBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_customer.DataSource = dt;
            connect.con.Close();
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //status
            if (cb_status.Text == "Active")
            {
                status = bool.Parse(true.ToString());
            }
            else
            {
                status = bool.Parse(false.ToString());
            }
            GetCustomer();
            label_role_counting.Text = "TOTAL # OF CUSTOMER/S:" + (dt_customer.RowCount);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_customer.id = 0;
            Frm_Add_Customer frm = new Frm_Add_Customer(this);
            frm.ShowDialog();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dt_customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_customer.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_customer.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_customer.customer_code = row.Cells["customer_code"].Value.ToString();
                edit_customer.customer_name = row.Cells["customer_name"].Value.ToString();
                edit_customer.address = row.Cells["address"].Value.ToString();
                edit_customer.status = bool.Parse(row.Cells["status"].Value.ToString());
                edit_customer.area = row.Cells["area"].Value.ToString();
                edit_customer.area_id = int.Parse(row.Cells["area_id"].Value.ToString());
                edit_customer.bcategory = row.Cells["business_category"].Value.ToString();
                edit_customer.bcategory_id = int.Parse(row.Cells["business_category_id"].Value.ToString());
                edit_customer.org = row.Cells["org"].Value.ToString();


                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Customer frm = new Frm_Add_Customer(this);
            frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomerBySearch();
            }
        }

        private void HeaderName()
        {
            dt_customer.Columns["id"].HeaderText = "Id";
            dt_customer.Columns["area"].HeaderText = "Area";
            dt_customer.Columns["business_category"].HeaderText = "Business Model";
            dt_customer.Columns["customer_code"].HeaderText = "Customer Code";
            dt_customer.Columns["customer_name"].HeaderText = "Customer Name";
            dt_customer.Columns["address"].HeaderText = "Route";
            dt_customer.Columns["status"].HeaderText = "Status";
            dt_customer.Columns["date_added"].HeaderText = "Date Added";

            dt_customer.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_customer.EnableHeadersVisualStyles = false;
        }

        private void dt_customer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_customer.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF CUSTOMER/S: " + (dt_customer.RowCount);
        }
    }
}
