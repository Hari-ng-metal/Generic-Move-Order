using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Move_Order.Frm_Printing
{
    public partial class Frm_Printing : Form
    {
        string path = "";
        string APPPATH = "";
        ReportDocument rpt = new ReportDocument();
        int copy = 2;

        public Frm_Printing()
        {
            InitializeComponent();
        }

        private void Frm_Printing_Load(object sender, EventArgs e)
        {
            path = Generic_Move_Order.Properties.Settings.Default.report;
            CheckPrint();
        }

        private void MoveOrderReport()
        {
            var dialog = new PrintDialog();


            //rpt.Load(path + "\\MoveOrder.rpt");
            APPPATH = Environment.CurrentDirectory + "\\MoveOrder.rpt";
            rpt.Load(APPPATH);
            rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22");
            //rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22", @"10.10.2.6,1433", "MoveOrder");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
            rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;

            DialogResult res = MessageBox.Show("Do you want to print?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                rpt.PrintToPrinter(copy, false, 0, 0);
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void ReceivingReport()
        {
            var dialog = new PrintDialog();

            //rpt.Load(path + "\\ReceivingOrder.rpt");
            APPPATH = Environment.CurrentDirectory + "\\ReceivingOrder.rpt";
            rpt.Load(APPPATH);
            rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22");
            //rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22", @"10.10.2.6,1433", "MoveOrder");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
            rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;

            DialogResult res = MessageBox.Show("Do you want to print?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                rpt.PrintToPrinter(copy, false, 0, 0);
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void IssueReport()
        {
            var dialog = new PrintDialog();

            //rpt.Load(path + "\\Issue.rpt");
            APPPATH = Environment.CurrentDirectory + "\\Issue.rpt";
            rpt.Load(APPPATH);
            rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22");
            //rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22", @"10.10.2.6,1433", "MoveOrder");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
            rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;

            DialogResult res = MessageBox.Show("Do you want to print?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                rpt.PrintToPrinter(copy, false, 0, 0);
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }


        private void ReceiptReport()
        {
            var dialog = new PrintDialog();

            //rpt.Load(path + "\\Receipt.rpt");
            APPPATH = Environment.CurrentDirectory + "\\Receipt.rpt";
            rpt.Load(APPPATH);
            rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22");
            //rpt.SetDatabaseLogon("sa", "ULtR@MaVD3p0t2o22", @"10.10.2.6,1433", "MoveOrder");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
            rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;

            DialogResult res = MessageBox.Show("Do you want to print?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                rpt.PrintToPrinter(copy, false, 0, 0);
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void CheckPrint()
        {
            if(printing.report_name == "MoveOrder")
            {
                MoveOrderReport();
            }
            if (printing.report_name == "Receiving")
            {
                ReceivingReport();
            }
            if (printing.report_name == "Issue")
            {
                IssueReport();
            }

            if (printing.report_name == "Receipt")
            {
                ReceiptReport();
            }
        }

        private void Frm_Printing_KeyDown(object sender, KeyEventArgs e)
        {
            //print
            if (e.Control && e.KeyCode == Keys.P)
            {
                MessageBox.Show("Sample Lang");
                //crv_report.PrintReport();
            }
        }

        private void crv_report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                MessageBox.Show("Sample Lang");
            }
        }
    }
}
