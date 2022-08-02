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

namespace Generic_Move_Order.Frm_RM
{
    public partial class Frm_Add_RM : Form
    {
        Connection connect = new Connection();
        string uom_id = "0";
        string category_id = "0";
        bool status;

        Frm_RM frm;
        public Frm_Add_RM(Frm_RM _frn)
        {
            InitializeComponent();
            this.frm = _frn;
        }

        private void Frm_Add_RM_Load(object sender, EventArgs e)
        {
            GetProductCategory();
            GetUOM();
            AddOrEdit();

           
        }

        public void GetProductCategory()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetProductCategory", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_category.DataSource = dt;
                connect.con.Close();

                cb_category.ValueMember = "id";
                cb_category.DisplayMember = "product_category";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_category.SelectedIndex = -1;
        }

        public void GetCtegory()
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

        public void GetUOM()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetUOM", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_uom.DataSource = dt;
                connect.con.Close();

                cb_uom.ValueMember = "id";
                cb_uom.DisplayMember = "uom";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_uom.SelectedIndex = -1;
        }

        private void cb_uom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_uom.SelectedIndex >= 0)
            {
                uom_id = cb_uom.SelectedValue.ToString();
                label_uom.Text = uom_id;
            }
            if(cb_uom.Text == "KG" || cb_uom.Text == "L")
            {
                text_conversion.Text = "1";
            }
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_category.SelectedIndex >= 0)
            {
                category_id = cb_category.SelectedValue.ToString();
                label_category.Text = category_id;
            }
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

        private void InsertItem()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertItem", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", text_code.Text);
                cmd.Parameters.AddWithValue("@desc", text_desc.Text);
                cmd.Parameters.AddWithValue("@uom", int.Parse(uom_id.ToString()));
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@category", int.Parse(category_id.ToString()));
                cmd.Parameters.AddWithValue("@conversion", decimal.Parse(text_conversion.Text.ToString()));
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

        private void UpdateItem()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateItem", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_rm.id);
                cmd.Parameters.AddWithValue("@code", text_code.Text);
                cmd.Parameters.AddWithValue("@desc", text_desc.Text);
                cmd.Parameters.AddWithValue("@uom", int.Parse(uom_id.ToString()));
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@category", int.Parse(category_id.ToString()));
                cmd.Parameters.AddWithValue("@conversion", decimal.Parse(text_conversion.Text.ToString()));
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
                if (text_code.Text == string.Empty || cb_status.Text == string.Empty || text_desc.Text == string.Empty || cb_category.Text == string.Empty || cb_uom.Text == string.Empty || text_conversion.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_rm.id > 0)
                {
                    UpdateItem();
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
            frm.GetMasterlist();
            frm.dt_rm.ClearSelection();
        }

        private void AddOrEdit()
        {
            if (edit_rm.id > 0)
            {
                text_code.Text = edit_rm.item_code;
                text_desc.Text = edit_rm.item_description;
                uom_id = edit_rm.uom_id.ToString();
                category_id = edit_rm.category_id.ToString();
                cb_category.Text = edit_rm.category;
                text_conversion.Text = edit_rm.conversion.ToString();
                cb_uom.Text = edit_rm.uom;
                label_status.Text = edit_rm.status.ToString();
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

        private void cb_category_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_uom_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cb_uom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckIfItemExist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", text_code.Text);
            cmd.Parameters.AddWithValue("@mode", "item_code");
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
                InsertItem();
                this.Close();
            }
        }

        private void text_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void text_conversion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
