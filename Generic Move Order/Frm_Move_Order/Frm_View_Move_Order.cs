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
    public partial class Frm_View_Move_Order : Form
    {
        Connection connect = new Connection();
        public Frm_View_Move_Order()
        {
            InitializeComponent();
        }

        private void Frm_View_Move_Order_Load(object sender, EventArgs e)
        {
            ShowMoeOrderDetails();
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_move.RowCount);
            HeaderName();
        }

        private void ShowMoeOrderDetails()
        {
            text_sales_id.Text = view_move_order.id.ToString();
            text_date.Text = view_move_order.transaction_date.ToString("yyyy-MM-dd");
            text_name.Text = view_move_order.customer_name;
            text_code.Text = view_move_order.customer_code;
            text_transaction_description.Text = view_move_order.description;
            text_account_title.Text = view_move_order.account_title;
            text_reference.Text = view_move_order.reference;

            GetMoveOrderItemById();
        }

        public void GetMoveOrderItemById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMoveOrderItemById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", view_move_order.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_move.DataSource = dt;
            connect.con.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            //
            Frm_Printing.printing.last_id = view_move_order.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "MoveOrder";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            //dt_move.Columns["id"].HeaderText = "Id";
            dt_move.Columns["item_code"].HeaderText = "Item Code";
            dt_move.Columns["item_description"].HeaderText = "Item Description";
            dt_move.Columns["uom"].HeaderText = "UOM";
            dt_move.Columns["quantity"].HeaderText = "Quantity";
            dt_move.Columns["slab"].HeaderText = "Slab/Bag";
            //dt_move.Columns["actual_quantity"].HeaderText = "Actual Quantity";

            dt_move.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_move.EnableHeadersVisualStyles = false;
        }

        private void dt_move_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_move.RowCount);
        }
    }
}
