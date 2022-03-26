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

namespace Generic_Move_Order.Frm_Role
{
    public partial class Frm_Add_Role : Form
    {
        Connection connect = new Connection();
        bool status;
        Frm_Role frm;
        public Frm_Add_Role(Frm_Role _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void InsertRole()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertRole", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", text_role.Text);
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

        private void UpdateRole()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateRole", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_role.id);
                cmd.Parameters.AddWithValue("@role", text_role.Text);
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
                if (text_role.Text == string.Empty || cb_status.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_role.id > 0)
                {
                    UpdateRole();
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
            frm.GetRole();
            frm.dt_role.ClearSelection();
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

        private void AddOrEdit()
        {
            if(edit_role.id > 0)
            {
                text_role.Text = edit_role.role_name;
                label_status.Text = edit_role.status.ToString();
                if(label_status.Text == true.ToString())
                {
                    cb_status.SelectedIndex = 0;
                }
                else
                {
                    cb_status.SelectedIndex = 1;
                }
                btn_save.Text = "UPDATE";
                text_role.Enabled = false;
            }
            else
            {
                btn_save.Text = "SAVE";
                cb_status.SelectedIndex = 0;
            }
        }

        private void Frm_Add_Role_Load(object sender, EventArgs e)
        {
            AddOrEdit();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            cmd.Parameters.AddWithValue("@role", text_role.Text);
            cmd.Parameters.AddWithValue("@mode", "role");
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
                InsertRole();
                this.Close();
            }
        }
    }
}
