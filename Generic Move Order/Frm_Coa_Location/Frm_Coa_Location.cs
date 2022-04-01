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

namespace Generic_Move_Order.Frm_Coa_Location
{
    public partial class Frm_Coa_Location : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Coa_Location()
        {
            InitializeComponent();
        }

        private void Frm_Coa_Location_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_coa_location.id = 0;
            Frm_Add_Coa_Location frm = new Frm_Add_Coa_Location(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetCoaLocation()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaLocation", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_location.DataSource = dt;
            connect.con.Close();

            dt_location.ReadOnly = true;
        }

        public void GetCoaLocationBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCoaLocationBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_location.DataSource = dt;
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
            GetCoaLocation();
            label_role_counting.Text = "TOTAL # OF DEPARTMENT/S: " + (dt_location.RowCount);
        }

        private void dt_location_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_location.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_coa_location.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_coa_location.code = row.Cells["code"].Value.ToString();
                edit_coa_location.location = row.Cells["location"].Value.ToString();
                edit_coa_location.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Coa_Location frm = new Frm_Add_Coa_Location(this);
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            dt_location.Columns["id"].HeaderText = "Id";
            dt_location.Columns["code"].HeaderText = "Code";
            dt_location.Columns["location"].HeaderText = "Location";
            dt_location.Columns["status"].HeaderText = "Status";
            dt_location.Columns["date_added"].HeaderText = "Date Added";

            dt_location.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_location.EnableHeadersVisualStyles = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetCoaLocationBySearch();
            }
        }

        private void dt_location_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_location.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF DEPARTMENT/S: " + (dt_location.RowCount);
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
