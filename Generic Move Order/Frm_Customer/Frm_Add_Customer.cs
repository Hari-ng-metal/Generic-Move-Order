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
    public partial class Frm_Add_Customer : Form
    {
        Connection connect = new Connection();
        bool status;
        string area_id = "0";
        string bcategory_id = "0";

        Frm_Customer frm;
        public Frm_Add_Customer(Frm_Customer _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void text_desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
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

        private void InsertCustomer()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertCustomer", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", text_code.Text);
                cmd.Parameters.AddWithValue("@name", text_name.Text);
                cmd.Parameters.AddWithValue("@address", text_address.Text);
                cmd.Parameters.AddWithValue("@area", area_id);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                cmd.Parameters.AddWithValue("@b_category_id", label_bcategory_id.Text);
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

        private void UpdateCustomer()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_customer.id);
                cmd.Parameters.AddWithValue("@code", text_code.Text);
                cmd.Parameters.AddWithValue("@name", text_name.Text);
                cmd.Parameters.AddWithValue("@address", text_address.Text);
                cmd.Parameters.AddWithValue("@area", label_area_id.Text);
                cmd.Parameters.AddWithValue("@b_category_id", label_bcategory_id.Text);
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (text_code.Text == string.Empty || cb_status.Text == string.Empty || text_name.Text == string.Empty || text_address.Text == string.Empty || cb_area.Text == string.Empty || cb_bcategory.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_customer.id > 0)
                {
                    UpdateCustomer();
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
            frm.GetCustomer();
            frm.dt_customer.ClearSelection();
        }

        private void AddOrEdit()
        {
            if (edit_customer.id > 0)
            {
                text_code.Text = edit_customer.customer_code;
                text_name.Text = edit_customer.customer_name;
                text_address.Text = edit_customer.address;
                area_id = edit_customer.area_id.ToString();
                cb_area.Text = edit_customer.area;
                bcategory_id = edit_customer.bcategory_id.ToString();
                cb_bcategory.Text = edit_customer.bcategory;
                label_status.Text = edit_customer.status.ToString();
                if (label_status.Text == true.ToString())
                {
                    cb_status.SelectedIndex = 0;
                }
                else
                {
                    cb_status.SelectedIndex = 1;
                }

                btn_save.Text = "UPDATE";
                text_code.Enabled = false;
            }
            else
            {
                btn_save.Text = "SAVE";
                cb_status.SelectedIndex = 0;
            }
        }


        private void Frm_Add_Customer_Load(object sender, EventArgs e)
        {
            GetArea();
            GetBCategory();
            AddOrEdit();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckIfItemExist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store_code", text_code.Text);
            cmd.Parameters.AddWithValue("@mode", "store");
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
                InsertCustomer();
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetArea()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetArea", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_area.DataSource = dt;
                connect.con.Close();

                cb_area.ValueMember = "id";
                cb_area.DisplayMember = "area";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_area.SelectedIndex = -1;
        }


        public void GetBCategory()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetBCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_bcategory.DataSource = dt;
                connect.con.Close();

                cb_bcategory.ValueMember = "id";
                cb_bcategory.DisplayMember = "business_category";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_bcategory.SelectedIndex = -1;
        }


        private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_area.SelectedIndex >= 0)
            {
                area_id = cb_area.SelectedValue.ToString();
                label_area_id.Text = area_id;
            }
        }

        private void cb_bcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_bcategory.SelectedIndex >= 0)
            {
                bcategory_id = cb_bcategory.SelectedValue.ToString();
                label_bcategory_id.Text = bcategory_id;
            }
        }
    }
}
