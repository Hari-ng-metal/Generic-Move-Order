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

namespace Generic_Move_Order.Frm_Warehouse
{
    public partial class Frm_Warehouse : Form
    {
        Connection connect = new Connection();
        bool status = true;
        public Frm_Warehouse()
        {
            InitializeComponent();
        }

        public void GetWarehouse()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetWarehouse", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_warehouse.DataSource = dt;
            connect.con.Close();

            dt_warehouse.ReadOnly = true;

        }

        public void GetWarehouseBySearch()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetWarehouseBySearch", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_warehouse.DataSource = dt;
            connect.con.Close();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            edit_warehouse.id = 0;
            Frm_Add_Warehouse frm = new Frm_Add_Warehouse(this);
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
            GetWarehouse();
            label_role_counting.Text = "TOTAL # OF WAREHOUSE/S:" + (dt_warehouse.RowCount);
        }

        private void Frm_Warehouse_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
            HeaderName();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_warehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_warehouse.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_warehouse.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_warehouse.code = row.Cells["code"].Value.ToString();
                edit_warehouse.warehouse = row.Cells["warehouse"].Value.ToString();
                edit_warehouse.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Warehouse frm = new Frm_Add_Warehouse(this);
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
                GetWarehouseBySearch();
            }
        }

        private void HeaderName()
        {
            dt_warehouse.Columns["id"].HeaderText = "Id";
            dt_warehouse.Columns["code"].HeaderText = "Code";
            dt_warehouse.Columns["warehouse"].HeaderText = "Warehouse";
            dt_warehouse.Columns["status"].HeaderText = "Status";

            dt_warehouse.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_warehouse.EnableHeadersVisualStyles = false;
        }

        private void dt_warehouse_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_warehouse.ClearSelection();

            btn_edit.Enabled = false;

            label_role_counting.Text = "TOTAL # OF WAREHOUSE/S: " + (dt_warehouse.RowCount);
        }
    }
}
