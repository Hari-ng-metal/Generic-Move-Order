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

namespace Generic_Move_Order.Frm_RM
{
    public partial class Frm_RM : Form
    {
        Connection connect = new Connection();
        bool status;

        public Frm_RM()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            edit_rm.id = 0;
            Frm_Add_RM frm = new Frm_Add_RM();
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
            GetMasterlist();
            label_counting.Text = "TOTAL # OF MATERIAL/S:"+(dt_rm.RowCount);
        }

        public void GetMasterlist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMasterlist", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", status);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_rm.DataSource = dt;
            connect.con.Close();

            dt_rm.Columns["uom_id"].Visible = false;
            dt_rm.Columns["category_id"].Visible = false;
        }

        private void Frm_RM_Load(object sender, EventArgs e)
        {
            //
            cb_status.SelectedIndex = 0;
            btn_edit.Enabled = false;
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dt_rm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_rm.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                edit_rm.id = int.Parse(row.Cells["int"].Value.ToString());
                edit_rm.item_code = row.Cells["item_code"].Value.ToString();
                edit_rm.item_description = row.Cells["item_description"].Value.ToString();
                edit_rm.uom_id = int.Parse(row.Cells["uom_id"].Value.ToString());
                edit_rm.uom = row.Cells["uom"].Value.ToString();
                edit_rm.category_id = int.Parse(row.Cells["category_id"].Value.ToString());
                edit_rm.category = row.Cells["category"].Value.ToString();
                edit_rm.status = bool.Parse(row.Cells["status"].Value.ToString());

                btn_edit.Enabled = true;

            }
            else
            {
                btn_edit.Enabled = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Frm_Add_RM frm = new Frm_Add_RM();
            frm.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //
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
        //            MessageBox.Show("No data found!","Information!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //        else
        //        {
        //            dt_rm.DataSource = re.CopyToDataTable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
