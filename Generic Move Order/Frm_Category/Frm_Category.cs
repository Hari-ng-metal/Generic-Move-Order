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

namespace Generic_Move_Order.Frm_Category
{
    public partial class Frm_Category : Form
    {
        Connection connect = new Connection();
        bool status;
   
        public Frm_Category()
        {
            InitializeComponent();
        }

        private void Frm_Category_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_category.id = 0;
            Frm_Add_Category frm = new Frm_Add_Category(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetCategory()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCategory", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_category.DataSource = dt;
            connect.con.Close();

            dt_category.ReadOnly = true;
        }

        public void GetCategoryBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCategoryBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_category.DataSource = dt;
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
            GetCategory();
            label_role_counting.Text = "TOTAL # OF CATEGORY/S: " + (dt_category.RowCount);
        }

        private void dt_category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_category.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_category.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_category.category = row.Cells["category"].Value.ToString();
                edit_category.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Category frm = new Frm_Add_Category(this);
            frm.ShowDialog();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetCategoryBySearch();
            }
        }

        private void HeaderName()
        {
            dt_category.Columns["id"].HeaderText = "Id";
            dt_category.Columns["category"].HeaderText = "Category";
            dt_category.Columns["status"].HeaderText = "Status";
            dt_category.Columns["date_added"].HeaderText = "Date Added";

            dt_category.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_category.EnableHeadersVisualStyles = false;
        }

        private void dt_category_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_category.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF CATEGORY/S: " + (dt_category.RowCount);
        }
    }
}
