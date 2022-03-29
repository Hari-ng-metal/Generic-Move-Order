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

namespace Generic_Move_Order.Frm_Move_Order
{
    public partial class Frm_Print_Move_Order : Form
    {
        Connection connect = new Connection();
        string area_id = "0";
        public Frm_Print_Move_Order()
        {
            InitializeComponent();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Print_Move_Order_Load(object sender, EventArgs e)
        {
            GetArea();
        }

        public void GetArea()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetArea", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_area.DataSource = dt;
                connect.con.Close();

                cb_area.ValueMember = "id";
                cb_area.DisplayMember = "area";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_area.SelectedIndex = -1;
        }

        public void GetMoveOrderPrint()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMoveOrderPrinting", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@area", area_id);
            cmd.Parameters.AddWithValue("@start", dp_start.Text);
            cmd.Parameters.AddWithValue("@end", dp_end.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move_order.DataSource = dt;
            connect.con.Close();

            dt_move_order.ReadOnly = true;
            dt_move_order.ClearSelection();
        }

        private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_area.SelectedIndex >= 0)
            {
                area_id = (cb_area.SelectedValue.ToString());
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            if(cb_area.Text == "")
            {
                cb_area.Focus();
                btn_print.Enabled = false;
            }
            else if(dt_move_order.Rows.Count >1)
            {
                btn_print.Enabled = false;
            }
            else
            {
                btn_print.Enabled = true;
            }
            GetMoveOrderPrint();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if(cb_copy.Text == "")
            {
                cb_copy.Focus();
            }
            else
            {
                //here
            }
        }
    }
}
