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

namespace Generic_Move_Order.Frm_Role
{
    public partial class Frm_Tag_Role : Form
    {
        int module_id;
        int untag_id;
        Connection connect = new Connection();
        public Frm_Tag_Role()
        {
            InitializeComponent();
        }

        private void Frm_Tag_Role_Load(object sender, EventArgs e)
        {
            GetAvailableModule();
            GetTaggedModule();

            btn_tag.Enabled = false;
            btn_untag.Enabled = false;
        }
        public void GetAvailableModule()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetAvailableModule", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@role", edit_role.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_untag.DataSource = dt;
            connect.con.Close();
        }

        public void GetTaggedModule()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetTaggedModule", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@role", edit_role.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_tagged.DataSource = dt;
            connect.con.Close();
        }

        private void InsertTagModule()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertTagModule", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", edit_role.id);
                cmd.Parameters.AddWithValue("@module", module_id);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void DeleteTagModule()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteTagModule", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", untag_id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void dt_untag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_untag.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                module_id = int.Parse(row.Cells["id"].Value.ToString());
                //MessageBox.Show("" + module_id);

                btn_tag.Enabled = true;
            }
            else
            {
                btn_tag.Enabled = false;
            }
        }

        private void btn_tag_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Are you sure you want to activate?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…
                if (module_id > 0)
                {
                    InsertTagModule();
                    GetAvailableModule();
                    GetTaggedModule();
                }
                else
                {
                    MessageBox.Show("Please select module to activate", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void dt_tagged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dt_tagged.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                untag_id = int.Parse(row.Cells["id"].Value.ToString());
                MessageBox.Show("" + untag_id);

                btn_untag.Enabled = true;
            }
            else
            {
                btn_untag.Enabled = false;
            }
        }

        private void btn_untag_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to deactive?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…
                if (untag_id > 0)
                {
                    DeleteTagModule();
                    GetAvailableModule();
                    GetTaggedModule();
                }
                else
                {
                    MessageBox.Show("Please select module to deactive", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }
    }
}
