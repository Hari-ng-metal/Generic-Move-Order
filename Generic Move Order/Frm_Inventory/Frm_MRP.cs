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

namespace Generic_Move_Order.Frm_Inventory
{
    public partial class Frm_MRP : Form
    {
        Connection connect = new Connection();
        bool status;

        public Frm_MRP()
        {
            InitializeComponent();
        }

        private void Frm_MRP_Load(object sender, EventArgs e)
        {
            cb_status.SelectedIndex = 0;
        }
        public void GetMRP()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMRP", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_mrp.DataSource = dt;
            connect.con.Close();

            dt_mrp.Columns["status"].Visible = false;
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
            GetMRP();
            label_role_counting.Text = "TOTAL # OF RM/S: " + (dt_mrp.RowCount);
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //search();
            }
        }

        //private void search()
        //{
        //    string searchValue = textBox1.Text;
        //    try
        //    {
        //        var re = from row in dt.AsEnumerable()
        //                 where row[1].ToString().Contains(searchValue)
        //                 select row;
        //        if (re.Count() == 0)
        //        {
        //            MessageBox.Show("No data found!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //        else
        //        {
        //            dt_mrp.DataSource = re.CopyToDataTable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
