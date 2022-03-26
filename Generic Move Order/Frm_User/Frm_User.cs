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
    public partial class Frm_User : Form
    {
        Connection connect = new Connection();
        bool status = true;
        public Frm_User()
        {
            InitializeComponent();
        }

        public void GetUsers()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUser", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_user.DataSource = dt;
            connect.con.Close();

            dt_user.Columns["role_id"].Visible = false;
            dt_user.Columns["department_id"].Visible = false;
            dt_user.Columns["added_by"].Visible = false;
            dt_user.ReadOnly = true;

        }

        public void GetUsersBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUserBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_user.DataSource = dt;
            connect.con.Close();

            dt_user.Columns["role_id"].Visible = false;
            dt_user.Columns["department_id"].Visible = false;
            dt_user.Columns["added_by"].Visible = false;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            edit_user.id = 0;
            Frm_Add_User frm = new Frm_Add_User(this);
            frm.ShowDialog();

            btn_edit.Enabled = false;
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_status.Text == "Active")
            {
                status = bool.Parse(true.ToString());
            }
            else
            {
                status = bool.Parse(false.ToString());
            }
            GetUsers();
            label_role_counting.Text = "TOTAL # OF USER/S:" + (dt_user.RowCount);
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_user.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_user.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_user.name = row.Cells["name"].Value.ToString();
                edit_user.username = row.Cells["username"].Value.ToString();
                edit_user.password = row.Cells["password"].Value.ToString();
                edit_user.role_id = int.Parse(row.Cells["role_id"].Value.ToString());
                edit_user.role_name = row.Cells["role_name"].Value.ToString();
                edit_user.department_id = int.Parse(row.Cells["department_id"].Value.ToString());
                edit_user.department = row.Cells["department"].Value.ToString();
                edit_user.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_User frm = new Frm_Add_User(this);
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
                GetUsersBySearch();
            }
        }

        private void HeaderName()
        {
            dt_user.Columns["id"].HeaderText = "Id";
            dt_user.Columns["name"].HeaderText = "Name";
            dt_user.Columns["username"].HeaderText = "Username";
            dt_user.Columns["password"].HeaderText = "Password";
            dt_user.Columns["role_name"].HeaderText = "Role Name";
            dt_user.Columns["department"].HeaderText = "Department";
            dt_user.Columns["status"].HeaderText = "Status";
            dt_user.Columns["added_by"].HeaderText = "Added By";
            dt_user.Columns["date_added"].HeaderText = "Date Added";

            dt_user.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_user.EnableHeadersVisualStyles = false;
        }

        private void dt_user_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_user.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF USER/S: " + (dt_user.RowCount);
        }
    }
}
