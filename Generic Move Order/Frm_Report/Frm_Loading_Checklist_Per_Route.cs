using ClosedXML.Excel;
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

namespace Generic_Move_Order.Frm_Report
{
    public partial class Frm_Loading_Checklist_Per_Route : Form
    {
        Connection connect = new Connection();
        public Frm_Loading_Checklist_Per_Route()
        {
            InitializeComponent();
        }

        private void Frm_Loading_Checklist_Per_Route_Load(object sender, EventArgs e)
        {
            CustomDatePicker();
            GetRoute();
            GetChecklistReport();
        }

        private void CustomDatePicker()
        {
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
        }

        public void GetRoute()
        {

            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetDistinctRoute", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_route.DataSource = dt;
                connect.con.Close();

                cb_route.ValueMember = "address";
                cb_route.DisplayMember = "address";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_route.SelectedIndex = -1;
        }

        public void GetChecklistReport()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetLoadingChecklistReportPerRoute", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@route", cb_route.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_report.DataSource = dt;
            connect.con.Close();

            dt_report.ReadOnly = true;
        }

        private void CallPrintOut()
        {
            Frm_Printing.printing.report_name = "LoadingChecklistPerRoute";

            Frm_Printing.Frm_Printing frm = new Frm_Printing.Frm_Printing();
            frm.ShowDialog();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            GetChecklistReport();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Frm_Printing.printing.date_start = dateTimePicker1.Text;
            Frm_Printing.printing.route = cb_route.Text;

            CallPrintOut();
        }

        private void ExportToExcel()
        {
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dt_report.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dt_report.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt, "Report");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("You have successfully exported the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to export?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…  
                //ExportReport();
                ExportToExcel();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }
    }
}
