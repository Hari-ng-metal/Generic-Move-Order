using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Move_Order.Frm_Report
{
    public partial class Frm_Issue_History : Form
    {
        Connection connect = new Connection();
        public Frm_Issue_History()
        {
            InitializeComponent();
        }

        private void Frm_Issue_History_Load(object sender, EventArgs e)
        {
            CustomDatePicker();
            GetHistory();
            HeaderName();
        }

        private void CustomDatePicker()
        {
            dp_start.CustomFormat = "MM/dd/yyyy";
            dp_end.CustomFormat = "MM/dd/yyyy";
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetHistory()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetIssueTransactionHistory", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", dp_start.Value);
            cmd.Parameters.AddWithValue("@date2", dp_end.Value);
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

        private void ExportReport()
        {

            if (dt_report.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dt_report.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dt_report.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dt_report.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dt_report.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dt_report.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to export?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                //Some task…  
                ExportReport();
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void HeaderName()
        {
            dt_report.Columns["id"].HeaderText = "Id";
            dt_report.Columns["customer_code"].HeaderText = "Customer Code";
            dt_report.Columns["customer_name"].HeaderText = "Customer Name";
            dt_report.Columns["area"].HeaderText = "Area";
            dt_report.Columns["item_code"].HeaderText = "Item Code";
            dt_report.Columns["item_description"].HeaderText = "Item Description";
            dt_report.Columns["uom"].HeaderText = "UOM";
            dt_report.Columns["quantity"].HeaderText = "Quantity";
            dt_report.Columns["transaction_date"].HeaderText = "Transaction Date";

            dt_report.Columns["account_title"].HeaderText = "Account Title";
            dt_report.Columns["company"].HeaderText = "Company";
            dt_report.Columns["department"].HeaderText = "Department";
            dt_report.Columns["location"].HeaderText = "Location";
            dt_report.Columns["account"].HeaderText = "Account";

            dt_report.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dt_report.EnableHeadersVisualStyles = false;
        }

        private void btn_export_Click_1(object sender, EventArgs e)
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
    }
}
