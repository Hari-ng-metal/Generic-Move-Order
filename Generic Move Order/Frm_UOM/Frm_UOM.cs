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

namespace Generic_Move_Order.Frm_UOM
{
    public partial class Frm_UOM : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_UOM()
        {
            InitializeComponent();
        }

        private void Frm_UOM_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_uom.id = 0;
            Frm_Add_UOM frm = new Frm_Add_UOM(this);
            frm.ShowDialog();
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetUOM()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUOM", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_uom.DataSource = dt;
            connect.con.Close();

            dt_uom.ReadOnly = true;
        }

        public void GetUOMBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUOMBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_uom.DataSource = dt;
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
            GetUOM();
            label_role_counting.Text = "TOTAL # OF UOM/S: " + (dt_uom.RowCount);
        }

        private void dt_uom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_uom.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_uom.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_uom.uom = row.Cells["uom"].Value.ToString();
                edit_uom.uom_desc = row.Cells["uom_description"].Value.ToString();
                edit_uom.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_UOM frm = new Frm_Add_UOM(this);
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
                //search();
                GetUOMBySearch();
            }
        }

        private void HeaderName()
        {
            dt_uom.Columns["id"].HeaderText = "Id";
            dt_uom.Columns["uom"].HeaderText = "UOM";
            dt_uom.Columns["uom_description"].HeaderText = "Description";
            dt_uom.Columns["status"].HeaderText = "Status";
            dt_uom.Columns["date_added"].HeaderText = "Date Added";

            dt_uom.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_uom.EnableHeadersVisualStyles = false;
        }

        private void dt_uom_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_uom.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF UOM/S: " + (dt_uom.RowCount);
        }
    }
}
