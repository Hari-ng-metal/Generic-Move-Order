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

namespace Generic_Move_Order.Frm_Supplier
{
    public partial class Frm_Supplier : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Supplier()
        {
            InitializeComponent();
        }

        private void Frm_Supplier_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
        }

        public void GetSupplier()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetSupplier", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_supplier.DataSource = dt;
            connect.con.Close();
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //status
            if (cb_status.Text == "Active")
            {
                status = bool.Parse(true.ToString());
            }
            else
            {
                status = bool.Parse(false.ToString());
            }
            GetSupplier();
            label_role_counting.Text = "TOTAL # OF SUPPLIER/S:" + (dt_supplier.RowCount);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_supplier.id = 0;
            Frm_Add_Supplier frm = new Frm_Add_Supplier();
            frm.ShowDialog();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dt_supplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_supplier.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_supplier.id = int.Parse(row.Cells["id"].Value.ToString());
                edit_supplier.supplier_code = row.Cells["supplier_code"].Value.ToString();
                edit_supplier.supplier_name = row.Cells["supplier_name"].Value.ToString();
                edit_supplier.address = row.Cells["address"].Value.ToString();
                edit_supplier.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_Supplier frm = new Frm_Add_Supplier();
            frm.ShowDialog();
        }
    }
}
