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

namespace Generic_Move_Order.Frm_Miscellaneous_Receipt
{
    public partial class Frm_View_Receipt : Form
    {
        Connection connect = new Connection();
        public Frm_View_Receipt()
        {
            InitializeComponent();
        }

        private void Frm_View_Receipt_Load(object sender, EventArgs e)
        {
            ShowReceiveDetails();
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_receiving.RowCount);
            HeaderName();
        }

        private void ShowReceiveDetails()
        {
            text_sales_id.Text = view_receipt.id.ToString();
            text_date.Text = view_receipt.transaction_date.ToString();
            text_name.Text = view_receipt.supplier_name;
            text_code.Text = view_receipt.supplier_code;
            text_transaction_description.Text = view_receipt.description;
            text_reference.Text = view_receipt.reference;
            text_account_title.Text = view_receipt.account_title;

            GetReceiveItemById();
        }

        public void GetReceiveItemById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetReceiptItemById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", view_receipt.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_receiving.DataSource = dt;
            connect.con.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Frm_Printing.printing.last_id = view_receipt.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Receipt";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            dt_receiving.Columns["item_code"].HeaderText = "Item Code";
            dt_receiving.Columns["item_description"].HeaderText = "Item Description";
            dt_receiving.Columns["uom"].HeaderText = "UOM";
            dt_receiving.Columns["quantity"].HeaderText = "Quantity";

            dt_receiving.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_receiving.EnableHeadersVisualStyles = false;
        }
    }
}
