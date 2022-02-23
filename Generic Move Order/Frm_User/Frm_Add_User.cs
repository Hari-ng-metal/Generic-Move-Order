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

namespace Generic_Move_Order.Frm_User
{
    public partial class Frm_Add_User : Form
    {
        Connection connect = new Connection();
        string role_id = "0";
        string department_id = "0";
        bool status;
        public Frm_Add_User()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetRole()
        {

            try
            {
                    connect.DatabaseConnection();
                    connect.con.Open();
                    SqlCommand cmd = new SqlCommand("SP_GetRoles", connect.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    cb_role.DataSource = dt;
                    connect.con.Close();

                    cb_role.ValueMember = "id";
                    cb_role.DisplayMember = "role_name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_role.SelectedIndex = -1;
        }

        public void GetDepartment()
        {
       
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetDepartment", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_department.DataSource = dt;
                connect.con.Close();

                cb_department.ValueMember = "id";
                cb_department.DisplayMember = "department";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_department.SelectedIndex = -1;
        }

        private void InsertUser()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertUser", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", text_name.Text);
                cmd.Parameters.AddWithValue("@user", text_user.Text);
                cmd.Parameters.AddWithValue("@pass", text_password.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@role", int.Parse(role_id.ToString()));
                cmd.Parameters.AddWithValue("@department", int.Parse(department_id.ToString()));
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

        private void UpdateUser()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateUser", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_user.id);
                cmd.Parameters.AddWithValue("@name", text_name.Text);
                cmd.Parameters.AddWithValue("@user", text_user.Text);
                cmd.Parameters.AddWithValue("@pass", text_password.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@role", int.Parse(role_id.ToString()));
                cmd.Parameters.AddWithValue("@department", int.Parse(department_id.ToString()));
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



        private void Frm_Add_User_Load(object sender, EventArgs e)
        {
            GetRole();
            GetDepartment();
            AddOrEdit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (text_name.Text == string.Empty || text_user.Text == string.Empty || text_password.Text == string.Empty || cb_status.Text == string.Empty || cb_role.Text == string.Empty || cb_department.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_user.id > 0)
                {
                    UpdateUser();
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
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_status.Text == "Active")
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

        private void cb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_department.SelectedIndex >=0)
            {
                department_id = cb_department.SelectedValue.ToString();
            }
           
        }

        private void cb_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_role.SelectedIndex >=0)
            {
                role_id = cb_role.SelectedValue.ToString();
                label_role.Text = role_id;
            }

        }

        private void AddOrEdit()
        {
            if (edit_user.id > 0)
            {
                text_name.Text = edit_user.name;
                text_user.Text = edit_user.username;
                text_password.Text = edit_user.password;
                cb_role.Text = edit_user.role_name;
                cb_department.Text = edit_user.department;
                role_id = edit_user.role_id.ToString();
                department_id = edit_user.department_id.ToString();
                label_status.Text = edit_user.status.ToString();
                if (label_status.Text == true.ToString())
                {
                    cb_status.SelectedIndex = 0;
                }
                else
                {
                    cb_status.SelectedIndex = 1;
                }
                btn_save.Text = "UPDATE";
                text_user.Enabled = false;
            }
            else
            {
                btn_save.Text = "SAVE";
            }
        }

        private void cb_department_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_role_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckIfItemExist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", text_user.Text);
            cmd.Parameters.AddWithValue("@mode", "user");
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
                InsertUser();
                this.Close();
            }
        }
    }
}
