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
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_uom.id = 0;
            Frm_Add_UOM frm = new Frm_Add_UOM();
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
            Frm_Add_UOM frm = new Frm_Add_UOM();
            frm.ShowDialog();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
