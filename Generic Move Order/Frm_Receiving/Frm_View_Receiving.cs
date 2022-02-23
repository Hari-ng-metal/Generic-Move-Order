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

namespace Generic_Move_Order.Frm_Receiving
{
    public partial class Frm_View_Receiving : Form
    {
        Connection connect = new Connection();
        public Frm_View_Receiving()
        {
            InitializeComponent();
        }

        private void Frm_View_Receiving_Load(object sender, EventArgs e)
        {
            ShowReceiveDetails();
            label_counting.Text = "TOTAL # OF ITEM/S: " + (dt_receiving.RowCount);
        }

        private void ShowReceiveDetails()
        {
            text_sales_id.Text = view_receiving.id.ToString();
            text_date.Text = view_receiving.transaction_date.ToString();
            text_name.Text = view_receiving.supplier_name;
            text_code.Text = view_receiving.supplier_code;
            text_transaction_description.Text = view_receiving.description;

            GetReceiveItemById();
        }

        public void GetReceiveItemById()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetReceiveItemById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", view_receiving.id);
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
            Frm_Printing.printing.last_id = view_receiving.id;
            CallPrintOut();
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "Receiving";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }
    }
}
