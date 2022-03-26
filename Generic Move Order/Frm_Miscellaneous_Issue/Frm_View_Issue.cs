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

namespace Generic_Move_Order.Frm_Miscellaneous_Issue
{
    public partial class Frm_View_Issue : Form
    {
        Connection connect = new Connection();
        public Frm_View_Issue()
        {
            InitializeComponent();
        }

        private void Frm_View_Issue_Load(object sender, EventArgs e)
        {
            ShowMoeOrderDetails();
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_receiving.RowCount);
            HeaderName();
        }

        private void ShowMoeOrderDetails()
        {
            text_sales_id.Text = view_issue.id.ToString();
            text_date.Text = view_issue.transaction_date.ToString();
            text_name.Text = view_issue.customer_name;
            text_code.Text = view_issue.customer_code;
            text_transaction_description.Text = view_issue.description;

            GetIssueItemById();
        }

        public void GetIssueItemById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetIssueItemById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", view_issue.id);
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
            Frm_Printing.printing.last_id = view_issue.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Issue";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void HeaderName()
        {
            //dt_move.Columns["id"].HeaderText = "Id";
            dt_receiving.Columns["item_code"].HeaderText = "Item Code";
            dt_receiving.Columns["item_description"].HeaderText = "Item Description";
            dt_receiving.Columns["uom"].HeaderText = "UOM";
            dt_receiving.Columns["quantity"].HeaderText = "Quantity";
            //dt_move.Columns["actual_quantity"].HeaderText = "Actual Quantity";

            dt_receiving.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_receiving.EnableHeadersVisualStyles = false;
        }
    }
}
