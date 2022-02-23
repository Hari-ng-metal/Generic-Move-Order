using CrystalDecisions.CrystalReports.Engine;
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
        ReportDocument rpt = new ReportDocument();
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
            rpt.Load(path + "\\MoveOrder.rpt");
            //rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
        }

        private void ReceivingReport()
        {
            rpt.Load(path + "\\ReceivingOrder.rpt");
            //rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            rpt.Refresh();
            int ddate = printing.last_id;
            rpt.SetParameterValue("@last_id", ddate);

            crv_report.ReportSource = rpt;
            crv_report.Refresh();
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
        }
    }
}
