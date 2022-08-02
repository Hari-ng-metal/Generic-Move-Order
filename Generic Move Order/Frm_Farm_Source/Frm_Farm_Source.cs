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

namespace Generic_Move_Order.Frm_Farm_Source
{
    public partial class Frm_Farm_Source : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Farm_Source()
        {
            InitializeComponent();
        }

        private void Frm_Farm_Source_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_farmsource.id = 0;
            Frm_Add_Farm_Source frm = new Frm_Add_Farm_Source(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
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
            GetFarmSource();
            label_role_counting.Text = "TOTAL # OF FARM/S: " + (dt_farm.RowCount);
        }

        public void GetFarmSource()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetFarmSource", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_farm.DataSource = dt;
            connect.con.Close();

            dt_farm.ReadOnly = true;
        }

        public void GetFarmSourceBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetFarmSourceBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_farm.DataSource = dt;
            connect.con.Close();
        }

        private void dt_farm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_farm.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_farmsource.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_farmsource.code = row.Cells["code"].Value.ToString();
                edit_farmsource.farm_source = row.Cells["farm_source"].Value.ToString();
                edit_farmsource.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
                GetFarmSourceBySearch();
            }
        }

        private void HeaderName()
        {
            dt_farm.Columns["id"].HeaderText = "Id";
            dt_farm.Columns["code"].HeaderText = "Code";
            dt_farm.Columns["farm_source"].HeaderText = "Farm Source";
            dt_farm.Columns["status"].HeaderText = "Status";
            dt_farm.Columns["date_added"].HeaderText = "Date Added";

            dt_farm.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_farm.EnableHeadersVisualStyles = false;
        }

        private void dt_farm_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_farm.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF FARM/S: " + (dt_farm.RowCount);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Farm_Source frm = new Frm_Add_Farm_Source(this);
            frm.ShowDialog();
        }
    }
}
