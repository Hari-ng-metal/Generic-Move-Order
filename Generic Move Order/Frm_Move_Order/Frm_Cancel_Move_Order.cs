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
    public partial class Frm_Cancel_Move_Order : Form
    {
        Connection connect = new Connection();
        Frm_Move_Order_Record frm;
        public Frm_Cancel_Move_Order(Frm_Move_Order_Record _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void Frm_Cancel_Move_Order_Load(object sender, EventArgs e)
        {
            //load reason
            GetCancellationReason();
            btn_ok.Enabled = false;
        }

        public void GetCancellationReason()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCancellationReason", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_reason.DataSource = dt;
                connect.con.Close();

                cb_reason.ValueMember = "id";
                cb_reason.DisplayMember = "cancellation_reason";

                cb_reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cb_reason.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb_reason.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_reason.SelectedIndex = -1;
        }

        private void InactiveMoveORder()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateMoveOrderStatusToInactive", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@user", User.id);
            cmd.Parameters.AddWithValue("@reason", cb_reason.Text);
            cmd.Parameters.AddWithValue("@cancel_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", view_move_order.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_move_order.DataSource = dt;
            connect.con.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            InactiveMoveORder();
            frm.GetMoveOrderRecords();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_reason.SelectedIndex >= 0)
            {
                btn_ok.Enabled = true;
            }
        }

        private void cb_reason_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
