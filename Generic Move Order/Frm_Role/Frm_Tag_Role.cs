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
            HeaderNameTag();
            HeaderNameUntag();
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

            dt_untag.Columns["id"].Visible = false;
            dt_untag.ReadOnly = true;
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

            dt_tagged.Columns["id"].Visible = false;
            dt_tagged.Columns["path_name"].Visible = false;
            dt_tagged.ReadOnly = true;
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
                    btn_tag.Enabled = false;
                    btn_untag.Enabled = false;
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
                //MessageBox.Show("" + untag_id);

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
                    btn_tag.Enabled = false;
                    btn_untag.Enabled = false;
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HeaderNameTag()
        {
            dt_untag.Columns["id"].HeaderText = "Id";
            dt_untag.Columns["module_name"].HeaderText = "Module Name";

            dt_untag.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_untag.EnableHeadersVisualStyles = false;
        }

        private void HeaderNameUntag()
        {
            dt_tagged.Columns["id"].HeaderText = "Id";
            dt_tagged.Columns["module_name"].HeaderText = "Module Name";
            dt_tagged.Columns["path_name"].HeaderText = "Path Name";

            dt_tagged.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_tagged.EnableHeadersVisualStyles = false;
        }

        private void dt_tagged_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_tagged.ClearSelection();
        }

        private void dt_untag_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_untag.ClearSelection();
        }
    }
}
