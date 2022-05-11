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

namespace Generic_Move_Order.Frm_Dept_Location
{
    public partial class Frm_Dept_Location : Form
    {
        Connection connect = new Connection();
        int location_id;
        int tagged_id;
        public Frm_Dept_Location()
        {
            InitializeComponent();
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

                cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_department.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_department.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            //cb_department.SelectedIndex = -1;
            //text_dept.Clear();
        }

        private void Frm_Dept_Location_Load(object sender, EventArgs e)
        {
            GetDepartment();
            //label_id.Text = "0";
        }

        public void SP_GetCustomerById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaDepartmentById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", (cb_department.Text));
            cmd.Parameters.AddWithValue("@status", true);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();

            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                label_id.Text = dt.Rows[0]["id"].ToString();
                GetAvailableLocation();
            }
            else
            {

            }
        }

        public void GetAvailableLocation()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetAvailableLocation", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@department", (label_id.Text));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_untagged.DataSource = dt;
            connect.con.Close();

            dt_untagged.ReadOnly = true;

        }

        public void GetAvailableLocationBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetAvailableLocationBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@department", (label_id.Text));
            cmd.Parameters.AddWithValue("@search", (textBox1.Text));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_untagged.DataSource = dt;
            connect.con.Close();

        }

        public void GetTaggedLocation()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTaggedLocation", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@department", (cb_department.Text));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_tagged.DataSource = dt;
            connect.con.Close();


            dt_tagged.ReadOnly = true;
        }

        private void InsertSelectedLocation()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertTagLocation", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@department", int.Parse(label_id.Text));
                cmd.Parameters.AddWithValue("@location", location_id);
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

        private void DeleteTagLocation()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteTagLocation", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", tagged_id);
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

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_department.SelectedIndex >= 0)
            {
                text_dept.Text = cb_department.SelectedValue.ToString();
                if(!string.IsNullOrEmpty(cb_department.Text))
                {
                    SP_GetCustomerById();
                    GetTaggedLocation();
                }
            }
        }

        private void dt_untagged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_untagged.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                location_id = int.Parse(row.Cells["id"].Value.ToString());
                //MessageBox.Show("" + module_id);

                btn_tag.Enabled = true;
            }
            else
            {
                btn_tag.Enabled = false;
            }
        }

        private void btn_tag_Click(object sender, EventArgs e)
        {
            //tag
            DialogResult res = MessageBox.Show("Are you sure you want to activate?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…
                if (location_id > 0)
                {
                    InsertSelectedLocation();
                    GetAvailableLocation();
                    GetTaggedLocation();

                    btn_tag.Enabled = false;
                    btn_untag.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please select module to activate", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void dt_tagged_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_tagged.ClearSelection();

            btn_tag.Enabled = false;

            label_role_counting.Text = "TOTAL # OF LOCATION/S: " + (dt_tagged.RowCount);
        }

        private void dt_untagged_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_untagged.ClearSelection();

            btn_untag.Enabled = false;
        }

        private void dt_tagged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_tagged.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                tagged_id = int.Parse(row.Cells["id"].Value.ToString());
                //MessageBox.Show("" + module_id);

                btn_untag.Enabled = true;
            }
            else
            {
                btn_untag.Enabled = false;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_untag_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to deactive?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…
                if (tagged_id > 0)
                {
                    DeleteTagLocation();
                    GetAvailableLocation();
                    GetTaggedLocation();

                    btn_tag.Enabled = false;
                    btn_untag.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please select module to deactive", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetAvailableLocationBySearch();
            }
        }

        private void cb_department_Leave(object sender, EventArgs e)
        {
            //if (!cb_department.Items.Contains(cb_department.Text))
            //{
            //    MessageBox.Show("Not on the list!");
            //}
        }
    }
}
