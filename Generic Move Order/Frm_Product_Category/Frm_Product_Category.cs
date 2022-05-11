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

namespace Generic_Move_Order.Frm_Product_Category
{
    public partial class Frm_Product_Category : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Product_Category()
        {
            InitializeComponent();
        }

        private void Frm_Product_Category_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void HeaderName()
        {
            dt_p_category.Columns["id"].HeaderText = "Id";
            dt_p_category.Columns["category"].HeaderText = "Product Category";
            dt_p_category.Columns["product_category"].HeaderText = "Product Sub Category";
            dt_p_category.Columns["status"].HeaderText = "Status";
            dt_p_category.Columns["date_added"].HeaderText = "Date Added";

            dt_p_category.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_p_category.EnableHeadersVisualStyles = false;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_product_category.id = 0;
            Frm_Add_Product_Category frm = new Frm_Add_Product_Category(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetProductCategory()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetProductCategory", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_p_category.DataSource = dt;
            connect.con.Close();

            dt_p_category.Columns["category_id"].Visible = false;
            dt_p_category.ReadOnly = true;
        }

        public void GetProductCategoryBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetProductCategoryBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_p_category.DataSource = dt;
            connect.con.Close();

            dt_p_category.Columns["category_id"].Visible = false;
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
            GetProductCategory();
            label_role_counting.Text = "TOTAL # OF PRODUCT CATEGORY/S: " + (dt_p_category.RowCount);
        }

        private void dt_p_category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_p_category.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_product_category.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_product_category.category_id = int.Parse(row.Cells["category_id"].Value.ToString());
                edit_product_category.category = row.Cells["category"].Value.ToString();
                edit_product_category.product_category = row.Cells["product_category"].Value.ToString();
                edit_product_category.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Product_Category frm = new Frm_Add_Product_Category(this);
            frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetProductCategoryBySearch();
            }
        }

        private void dt_p_category_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_p_category.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF PRODUCT CATEGORY/S: " + (dt_p_category.RowCount);
        }
    }
}
