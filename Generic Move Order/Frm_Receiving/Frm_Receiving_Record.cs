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

namespace Generic_Move_Order.Frm_Receiving
{
    public partial class Frm_Receiving_Record : Form
    {
        Connection connect = new Connection();
        bool status;
        public Frm_Receiving_Record()
        {
            InitializeComponent();
        }

        private void Frm_Receiving_Record_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
            btn_print.Enabled = false;
            btn_inactive.Enabled = false;
            btn_view.Enabled = false;
        }

        public void GetReceivingRecords()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetReceivingRecords", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_receiving.DataSource = dt;
            connect.con.Close();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Frm_View_Receiving frm = new Frm_View_Receiving();
            frm.ShowDialog();
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
            GetReceivingRecords();
            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_receiving.RowCount);
        }

        private void dt_receiving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_receiving.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                view_receiving.id = int.Parse(row.Cells["id"].Value.ToString());
                view_receiving.supplier_code = row.Cells["supplier_code"].Value.ToString();
                view_receiving.supplier_name = row.Cells["supplier_name"].Value.ToString();
                view_receiving.description = row.Cells["description"].Value.ToString();
                view_receiving.transaction_date = DateTime.Parse(row.Cells["transaction_date"].Value.ToString());

                btn_view.Enabled = true;
                btn_inactive.Enabled = true;
                btn_print.Enabled = true;

            }
            else
            {
                btn_view.Enabled = false;
                btn_inactive.Enabled = false;
                btn_print.Enabled = false;
            }
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Frm_Printing.printing.last_id = view_receiving.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Receiving";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }
    }
}
