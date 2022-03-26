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

namespace Generic_Move_Order.Frm_Module
{
    public partial class Frm_Module : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Module()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_module.id = 0;
            Frm_Add_Module frm = new Frm_Add_Module(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetModule()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetModule", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_module.DataSource = dt;
            connect.con.Close();

            dt_module.ReadOnly = true;
        }

        public void GetModuleBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetModuleBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_module.DataSource = dt;
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
            GetModule();
            label_role_counting.Text = "TOTAL # OF MODULE/S: " + (dt_module.RowCount);
        }

        private void Frm_Module_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void dt_module_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_module.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_module.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_module.module_name = row.Cells["module_name"].Value.ToString();
                edit_module.path_name = row.Cells["path_name"].Value.ToString();
                edit_module.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Module frm = new Frm_Add_Module(this);
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
                GetModuleBySearch();
            }
        }
        private void HeaderName()
        {
            dt_module.Columns["id"].HeaderText = "Id";
            dt_module.Columns["module_name"].HeaderText = "Module Name";
            dt_module.Columns["path_name"].HeaderText = "Module Path";
            dt_module.Columns["status"].HeaderText = "Status";
            dt_module.Columns["date_added"].HeaderText = "Date Added";

            dt_module.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_module.EnableHeadersVisualStyles = false;
        }

        private void dt_module_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_module.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF MODULE/S: " + (dt_module.RowCount);
        }
    }
}
