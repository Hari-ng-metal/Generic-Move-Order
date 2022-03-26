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
    public partial class Frm_Role : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Role()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {

        }

        private void btn_new_Click_1(object sender, EventArgs e)
        {
            edit_role.id = 0;
            dt_role.ClearSelection();

            Frm_Add_Role frm = new Frm_Add_Role(this);
            frm.ShowDialog();

            btn_edit.Enabled = false;
            btn_inactive.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetRole()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetRole", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_role.DataSource = dt;
            connect.con.Close();

            dt_role.ReadOnly = true;
        }

        public void GetRoleBySearcg()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetRoleBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_role.DataSource = dt;
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
            GetRole();
            label_role_counting.Text = "TOTAL # OF ROLE/S:" + (dt_role.RowCount);
        }

        private void Frm_Role_Load(object sender, EventArgs e)
        {
            btn_edit.Enabled = false;
            btn_inactive.Enabled = false;
            cb_status.SelectedIndex = 0;

            dt_role.ClearSelection();
            HeaderName();
        }

        private void dt_role_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_role.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_role.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_role.role_name = row.Cells["role_name"].Value.ToString();
                edit_role.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;
                btn_inactive.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
                btn_inactive.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Role frm = new Frm_Add_Role(this);
            frm.ShowDialog();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_inactive_Click(object sender, EventArgs e)
        {
            Frm_Tag_Role frm = new Frm_Tag_Role();
            frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetRoleBySearcg();
            }
        }

        private void HeaderName()
        {
            dt_role.Columns["id"].HeaderText = "Id";
            dt_role.Columns["role_name"].HeaderText = "Role Name";
            dt_role.Columns["status"].HeaderText = "Status";
            dt_role.Columns["date_added"].HeaderText = "Date Added";

            dt_role.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_role.EnableHeadersVisualStyles = false;
        }

        private void dt_role_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_role.ClearSelection();

            btn_edit.Enabled = false;
            btn_inactive.Enabled = false;

            label_role_counting.Text = "TOTAL # OF ROLE/S: " + (dt_role.RowCount);
        }
    }
}
