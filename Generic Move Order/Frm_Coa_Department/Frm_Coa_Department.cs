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

namespace Generic_Move_Order.Frm_Coa_Department
{
    public partial class Frm_Coa_Department : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Coa_Department()
        {
            InitializeComponent();
        }

        private void Frm_Coa_Department_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_coa_department.id = 0;
            Frm_Add_Coa_Department frm = new Frm_Add_Coa_Department(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetCoaDepartment()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaDepartment", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_department.DataSource = dt;
            connect.con.Close();

            dt_department.ReadOnly = true;
        }

        public void GetCoaDepartmentBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaDepartmentBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_department.DataSource = dt;
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
            GetCoaDepartment();
            label_role_counting.Text = "TOTAL # OF DEPARTMENT/S: " + (dt_department.RowCount);
        }

        private void dt_department_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_department.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_coa_department.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_coa_department.code = row.Cells["code"].Value.ToString();
                edit_coa_department.department = row.Cells["department"].Value.ToString();
                edit_coa_department.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Coa_Department frm = new Frm_Add_Coa_Department(this);
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            dt_department.Columns["id"].HeaderText = "Id";
            dt_department.Columns["code"].HeaderText = "Code";
            dt_department.Columns["department"].HeaderText = "Department";
            dt_department.Columns["status"].HeaderText = "Status";
            dt_department.Columns["date_added"].HeaderText = "Date Added";

            dt_department.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_department.EnableHeadersVisualStyles = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetCoaDepartmentBySearch();
            }
        }

        private void dt_department_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_department.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF DEPARTMENT/S: " + (dt_department.RowCount);
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
