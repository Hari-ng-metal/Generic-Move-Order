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

namespace Generic_Move_Order.Frm_Business_Category
{
    public partial class Frm_Business_Category : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Business_Category()
        {
            InitializeComponent();
        }

        private void Frm_Business_Category_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_business_category.id = 0;
            Frm_Add_Business_Category frm = new Frm_Add_Business_Category(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
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
            GetBCategory();
            label_role_counting.Text = "TOTAL # OF BUSINESS CATEGORY/S: " + (dt_area.RowCount);
        }

        public void GetBCategory()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetBCategory", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_area.DataSource = dt;
            connect.con.Close();

            dt_area.ReadOnly = true;
        }

        public void GetBCategoryBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetBCategoryBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_area.DataSource = dt;
            connect.con.Close();
        }

        private void dt_area_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_area.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_business_category.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_business_category.business_category = row.Cells["business_category"].Value.ToString();
                edit_business_category.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetBCategoryBySearch();
            }
        }

        private void HeaderName()
        {
            dt_area.Columns["id"].HeaderText = "Id";
            dt_area.Columns["business_category"].HeaderText = "Business Category";
            dt_area.Columns["status"].HeaderText = "Status";
            dt_area.Columns["date_added"].HeaderText = "Date Added";

            dt_area.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_area.EnableHeadersVisualStyles = false;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Business_Category frm = new Frm_Add_Business_Category(this);
            frm.ShowDialog();
        }

        private void dt_area_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_area.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF BUSINESS CATEGORY/S: " + (dt_area.RowCount);
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
