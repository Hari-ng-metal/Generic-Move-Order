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
            DatagridHeader();
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
            dt_mrp.ReadOnly = true;
        }

        public void GetMRPByName()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMRPbyName", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@search", textBox1.Text);
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
                GetMRPByName();
            }
        }

        private void DatagridHeader()
        {
            dt_mrp.Columns["int"].HeaderText = "Id";
            dt_mrp.Columns["item_code"].HeaderText = "Item Code";
            dt_mrp.Columns["item_description"].HeaderText = "Item Description";
            dt_mrp.Columns["uom"].HeaderText = "UOM";
            dt_mrp.Columns["category"].HeaderText = "Category";
            dt_mrp.Columns["status"].HeaderText = "Status";
            dt_mrp.Columns["received"].HeaderText = "Received";
            dt_mrp.Columns["move_order"].HeaderText = "Move Order";
            dt_mrp.Columns["stock"].HeaderText = "Stock";
            dt_mrp.Columns["product_category"].HeaderText = "Product Category";
            dt_mrp.Columns["receipt"].HeaderText = "Receipt";
            dt_mrp.Columns["issue"].HeaderText = "Issue";
            dt_mrp.Columns["reserve"].HeaderText = "Reserve";
            dt_mrp.Columns["transat_move_order"].HeaderText = "Transact Move Order";

            dt_mrp.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_mrp.EnableHeadersVisualStyles = false;

        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dt_mrp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_mrp.ClearSelection();
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
