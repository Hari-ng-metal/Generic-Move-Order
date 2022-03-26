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
    public partial class Frm_Add_Product_Category : Form
    {
        Connection connect = new Connection();
        string category_id = "0";
        bool status;

        Frm_Product_Category frm;
        public Frm_Add_Product_Category(Frm_Product_Category _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_status.Text == "Active")
            {
                status = true;
                label_status.Text = status.ToString();
            }
            else
            {
                status = false;
                label_status.Text = status.ToString();
            }
        }

        private void Frm_Add_Product_Category_Load(object sender, EventArgs e)
        {
            GetCategory();
            AddOrEdit();
        }

        private void InsertProductCategory()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertProductCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@category_id", int.Parse(category_id).ToString());
                cmd.Parameters.AddWithValue("@product_category", text_p_category.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void UpdateProductCategory()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateProductCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_product_category.id);
                cmd.Parameters.AddWithValue("@category_id", int.Parse(category_id).ToString());
                cmd.Parameters.AddWithValue("@product_category", text_p_category.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void GetCategory()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_category.DataSource = dt;
                connect.con.Close();

                cb_category.ValueMember = "id";
                cb_category.DisplayMember = "category";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_category.SelectedIndex = -1;
        }

        private void AddOrEdit()
        {
            if (edit_product_category.id > 0)
            {
                text_p_category.Text = edit_product_category.product_category;
                category_id = edit_product_category.category_id.ToString();
                cb_category.Text = edit_product_category.category;
                label_status.Text = edit_product_category.status.ToString();
                if (label_status.Text == true.ToString())
                {
                    cb_status.SelectedIndex = 0;
                }
                else
                {
                    cb_status.SelectedIndex = 1;
                }

                btn_save.Text = "UPDATE";
                text_p_category.Enabled = false;
            }
            else
            {
                btn_save.Text = "SAVE";
                cb_status.SelectedIndex = 0;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (text_p_category.Text == string.Empty || cb_status.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_product_category.id > 0)
                {
                    UpdateProductCategory();
                    this.Close();
                }
                else
                {
                    CheckIfItemExist();
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
            frm.GetProductCategory();
            frm.dt_p_category.ClearSelection();
        }

        private void CheckIfItemExist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@category_id", label_category_id.Text);
            cmd.Parameters.AddWithValue("@product_category", text_p_category.Text);
            cmd.Parameters.AddWithValue("@mode", "product_category");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                InsertProductCategory();
                this.Close();
            }
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_category.SelectedIndex >= 0)
            {
                category_id = cb_category.SelectedValue.ToString();
                label_category_id.Text = category_id;
            }
        }

        private void cb_category_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
