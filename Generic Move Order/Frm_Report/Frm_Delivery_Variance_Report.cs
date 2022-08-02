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
    public partial class Frm_Delivery_Variance_Report : Form
    {
        Connection connect = new Connection();
        public Frm_Delivery_Variance_Report()
        {
            InitializeComponent();
        }

        private void Frm_Delivery_Variance_Report_Load(object sender, EventArgs e)
        {
            CustomDatePicker();
            GetHistory();
        }

        private void CustomDatePicker()
        {
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetHistory()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetDeliveryVarianceReportHistory", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt_report.DataSource = dt;
            connect.con.Close();

            dt_report.ReadOnly = true;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            GetHistory();
        }

        private void dt_report_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            label_role_counting.Text = "TOTAL # OF RECORD/S: " + (dt_report.RowCount);
        }

        private void dt_report_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dt_report.ClearSelection();
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

        private void btn_export_Click(object sender, EventArgs e)
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
