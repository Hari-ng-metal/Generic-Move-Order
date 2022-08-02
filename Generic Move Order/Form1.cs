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

namespace Generic_Move_Order
{
    public partial class Frm_Main : Form
    {
        Connection connect = new Connection();
        public static System.Drawing.Color WindowFrame { get; }
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void DisableAccess()
        {
            menuStrip1.Visible = false;
            menuStrip2.Visible = false;
            menuStrip3.Visible = false;
            menuStrip4.Visible = false;
            menuStrip5.Visible = false;
            menuStrip6.Visible = false;
            menuStrip7.Visible = false;

            //MISC
            miscellaneousIssueToolStripMenuItem1.Visible = false;
            miscellaeousReceiptToolStripMenuItem.Visible = false;
            miscellaneousIssueRecordToolStripMenuItem.Visible = false;
            micellaneousReceiptRecordToolStripMenuItem.Visible = false;

            //INV
            toolStripMenuItem5.Visible = false;

            //REC
            toolStripMenuItem7.Visible = false;
            receiveOrderRecordsToolStripMenuItem.Visible = false;

            //MOVE
            toolStripMenuItem9.Visible = false;
            toolStripMenuItem10.Visible = false;
            transactMoveOrderToolStripMenuItem.Visible = false;

            //REPORT
            toolStripMenuItem12.Visible = false;
            toolStripMenuItem13.Visible = false;
            transactedMoveOrderHistoryToolStripMenuItem.Visible = false;
            miscellaneousIssueHistoryToolStripMenuItem.Visible = false;
            miscellaneousReceiptHistoryToolStripMenuItem.Visible = false;
            loadingChecklistReportToolStripMenuItem.Visible = false;
            loadingChecklistReportPerRouteToolStripMenuItem.Visible = false;
            cancelledMoveOrderReportToolStripMenuItem.Visible = false;
            moveOrderRecordTranasctionToolStripMenuItem.Visible = false;
            deliveryVarianceReportToolStripMenuItem.Visible = false;

            //SETUP
            toolStripMenuItem15.Visible = false;
            toolStripMenuItem16.Visible = false;
            toolStripMenuItem17.Visible = false;
            toolStripMenuItem18.Visible = false;
            toolStripMenuItem19.Visible = false;
            prodictCategoryToolStripMenuItem.Visible = false;
            areaToolStripMenuItem.Visible = false;
            businessCategoryToolStripMenuItem.Visible = false;
            cOACompanyToolStripMenuItem.Visible = false;
            cOADepartmentToolStripMenuItem.Visible = false;
            cOALocationToolStripMenuItem.Visible = false;
            cOAAccountToolStripMenuItem.Visible = false;
            warehouseToolStripMenuItem.Visible = false;
            taggingOfLocationToolStripMenuItem.Visible = false;
            farmSourceToolStripMenuItem.Visible = false;

            //USER
            toolStripMenuItem22.Visible = false;
            toolStripMenuItem23.Visible = false;
            toolStripMenuItem24.Visible = false;
            toolStripMenuItem20.Visible = false;
        }

        private void UserAccess()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUserAccess", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@role", User.role_id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_user_role.DataSource = dt;
            connect.con.Close();

            foreach (DataRow row in dt.Rows)
            {
                string mod_name = row[2].ToString();
                //MessageBox.Show("" + mod_name);

                //if (mod_name == "menuStrip1")
                //{
                //    menuStrip1.Visible = true;
                //}

                //if (mod_name == "menuStrip2")
                //{
                //    menuStrip2.Visible = true;
                //}

                //if (mod_name == "menuStrip3")
                //{
                //    menuStrip3.Visible = true;
                //}

                //if (mod_name == "menuStrip4")
                //{
                //    menuStrip4.Visible = true;
                //}
                //if (mod_name == "menuStrip5")
                //{
                //    menuStrip5.Visible = true;
                //}
                //if (mod_name == "menuStrip6")
                //{
                //    menuStrip6.Visible = true;
                //}

                //if (mod_name == "menuStrip7")
                //{
                //    menuStrip7.Visible = true;
                //}


                //MISCELLANEOUS MODULE
                if (mod_name == "miscellaneousIssueToolStripMenuItem1")
                {
                    miscellaneousIssueToolStripMenuItem1.Visible = true;
                    menuStrip7.Visible = true;
                }

                if (mod_name == "miscellaeousReceiptToolStripMenuItem")
                {
                    miscellaeousReceiptToolStripMenuItem.Visible = true;
                    menuStrip7.Visible = true;
                }

                if (mod_name == "miscellaneousIssueRecordToolStripMenuItem")
                {
                    miscellaneousIssueRecordToolStripMenuItem.Visible = true;
                    menuStrip7.Visible = true;
                }

                if (mod_name == "micellaneousReceiptRecordToolStripMenuItem")
                {
                    micellaneousReceiptRecordToolStripMenuItem.Visible = true;
                    menuStrip7.Visible = true;
                }

                //INVENTORY MODULE
                if (mod_name == "toolStripMenuItem5")
                {
                    toolStripMenuItem5.Visible = true;
                    menuStrip1.Visible = true;
                }

                //RECEIVING
                if (mod_name == "toolStripMenuItem7")
                {
                    toolStripMenuItem7.Visible = true;
                    menuStrip2.Visible = true;
                }

                if (mod_name == "receiveOrderRecordsToolStripMenuItem")
                {
                    receiveOrderRecordsToolStripMenuItem.Visible = true;
                    menuStrip2.Visible = true;
                }

                //MOVE ORDER
                if (mod_name == "toolStripMenuItem9")
                {
                    toolStripMenuItem9.Visible = true;
                    menuStrip3.Visible = true;
                }

                if (mod_name == "toolStripMenuItem10")
                {
                    toolStripMenuItem10.Visible = true;
                    menuStrip3.Visible = true;
                }

                if (mod_name == "transactMoveOrderToolStripMenuItem")
                {
                    transactMoveOrderToolStripMenuItem.Visible = true;
                    menuStrip3.Visible = true;
                }

                //REPORT
                if (mod_name == "toolStripMenuItem12")
                {
                    toolStripMenuItem12.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "toolStripMenuItem13")
                {
                    toolStripMenuItem13.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "transactedMoveOrderHistoryToolStripMenuItem")
                {
                    transactedMoveOrderHistoryToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "miscellaneousIssueHistoryToolStripMenuItem")
                {
                    miscellaneousIssueHistoryToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "miscellaneousReceiptHistoryToolStripMenuItem")
                {
                    miscellaneousReceiptHistoryToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "loadingChecklistReportToolStripMenuItem")
                {
                    loadingChecklistReportToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "loadingChecklistReportPerRouteToolStripMenuItem")
                {
                    loadingChecklistReportPerRouteToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "cancelledMoveOrderReportToolStripMenuItem")
                {
                    cancelledMoveOrderReportToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "moveOrderRecordTranasctionToolStripMenuItem")
                {
                    moveOrderRecordTranasctionToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                if (mod_name == "deliveryVarianceReportToolStripMenuItem")
                {
                    deliveryVarianceReportToolStripMenuItem.Visible = true;
                    menuStrip4.Visible = true;
                }

                //SETUP
                if (mod_name == "toolStripMenuItem15")
                {
                    toolStripMenuItem15.Visible = true;
                    menuStrip5.Visible = true;
                }

                if (mod_name == "toolStripMenuItem16")
                {
                    toolStripMenuItem16.Visible = true;
                    menuStrip5.Visible = true;
                }

                if (mod_name == "toolStripMenuItem17")
                {
                    toolStripMenuItem17.Visible = true;
                    menuStrip5.Visible = true;
                }

                if (mod_name == "toolStripMenuItem18")
                {
                    toolStripMenuItem18.Visible = true;
                    menuStrip5.Visible = true;
                }

                if (mod_name == "toolStripMenuItem19")
                {
                    toolStripMenuItem19.Visible = true;
                    menuStrip5.Visible = true;
                }


                //if (mod_name == "toolStripMenuItem20")
                //{
                //    toolStripMenuItem2020.Visible = true;
                //    menuStrip5.Visible = true;
                //}

                if (mod_name == "prodictCategoryToolStripMenuItem")
                {
                    prodictCategoryToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //area
                if (mod_name == "areaToolStripMenuItem")
                {
                    areaToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //business category
                if (mod_name == "businessCategoryToolStripMenuItem")
                {
                    businessCategoryToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //coa company
                if (mod_name == "cOACompanyToolStripMenuItem")
                {
                    cOACompanyToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //coa department
                if (mod_name == "cOADepartmentToolStripMenuItem")
                {
                    cOADepartmentToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //coa location
                if (mod_name == "cOALocationToolStripMenuItem")
                {
                    cOALocationToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //coa account
                if (mod_name == "cOAAccountToolStripMenuItem")
                {
                    cOAAccountToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //warehouse
                if (mod_name == "warehouseToolStripMenuItem")
                {
                    warehouseToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                //tagging of location
                if (mod_name == "taggingOfLocationToolStripMenuItem")
                {
                    taggingOfLocationToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }

                //farm_source
                if (mod_name == "farmSourceToolStripMenuItem")
                {
                    farmSourceToolStripMenuItem.Visible = true;
                    menuStrip5.Visible = true;
                }
                

                //USER
                if (mod_name == "toolStripMenuItem22")
                {
                    toolStripMenuItem22.Visible = true;
                    menuStrip6.Visible = true;
                }

                if (mod_name == "toolStripMenuItem23")
                {
                    toolStripMenuItem23.Visible = true;
                    menuStrip6.Visible = true;
                }

                if (mod_name == "toolStripMenuItem24")
                {
                    toolStripMenuItem24.Visible = true;
                    menuStrip6.Visible = true;
                }
                if (mod_name == "toolStripMenuItem20")
                {
                    toolStripMenuItem20.Visible = true;
                    menuStrip6.Visible = true;
                }
            }
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //user account
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_User")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_User.Frm_User frm_in = new Frm_User.Frm_User() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DisableAccess();
            UserAccess();
            label_user.Text = "Welcome, "+User.username +"!";
        }

    

        private void label_user_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to logout?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //Some task…
                this.Close();
                Frm_Login frm = new Frm_Login();
                frm.Show();

            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
        }

        private void pb_menu_Click(object sender, EventArgs e)
        {
            if (panel_side.Width == 45)
            {
                panel_side.Width = 200;
            }
            else
            {
                panel_side.Width = 45;
            }
        }

        private void masterItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rm
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_RM")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_RM.Frm_RM frm_in = new Frm_RM.Frm_RM() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //customer
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Customer")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Customer.Frm_Customer frm_in = new Frm_Customer.Frm_Customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void userRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //role
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Role")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Role.Frm_Role frm_in = new Frm_Role.Frm_Role() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void moduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //module
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Module")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Module.Frm_Module frm_in = new Frm_Module.Frm_Module() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //supplier
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Supplier")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Supplier.Frm_Supplier frm_in = new Frm_Supplier.Frm_Supplier() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //category
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Category")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Category.Frm_Category frm_in = new Frm_Category.Frm_Category() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void uOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //uom
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_UOM")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_UOM.Frm_UOM frm_in = new Frm_UOM.Frm_UOM() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //department
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Department")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Department.Frm_Department frm_in = new Frm_Department.Frm_Department() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void moveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Move_Order")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Move_Order frm_in = new Frm_Move_Order.Frm_Move_Order() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void moveOrderPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Move_Order_Record")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Move_Order_Record frm_in = new Frm_Move_Order.Frm_Move_Order_Record() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void mRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MRP
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_MRP")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Inventory.Frm_MRP frm_in = new Frm_Inventory.Frm_MRP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //MRP
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_MRP")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Inventory.Frm_MRP frm_in = new Frm_Inventory.Frm_MRP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Move_Order")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Move_Order frm_in = new Frm_Move_Order.Frm_Move_Order() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Move_Order_Record")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Move_Order_Record frm_in = new Frm_Move_Order.Frm_Move_Order_Record() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            //rm
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_RM")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_RM.Frm_RM frm_in = new Frm_RM.Frm_RM() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            //customer
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Customer")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Customer.Frm_Customer frm_in = new Frm_Customer.Frm_Customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            //supplier
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Supplier")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Supplier.Frm_Supplier frm_in = new Frm_Supplier.Frm_Supplier() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            //uom
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_UOM")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_UOM.Frm_UOM frm_in = new Frm_UOM.Frm_UOM() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            //category
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Category")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Category.Frm_Category frm_in = new Frm_Category.Frm_Category() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            //department
            //bool IsOpen = false;
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Text == "Frm_Department")
            //    {
            //        IsOpen = true;
            //        f.BringToFront();
            //        //MessageBox.Show("Already Open");
            //        break;
            //    }
            //}
            //if (IsOpen == false)
            //{
            //    Frm_Department.Frm_Department frm_in = new Frm_Department.Frm_Department() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //    this.panel_body.Controls.Add(frm_in);
            //    frm_in.Show();
            //    frm_in.BringToFront();
            //}
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            //user account
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_User")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_User.Frm_User frm_in = new Frm_User.Frm_User() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            //role
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Role")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Role.Frm_Role frm_in = new Frm_Role.Frm_Role() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            //module
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Module")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Module.Frm_Module frm_in = new Frm_Module.Frm_Module() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            //history move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Move_Order_History")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Move_Order_History frm_in = new Frm_Report.Frm_Move_Order_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //receiving
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Receiving")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Receiving.Frm_Receiving frm_in = new Frm_Receiving.Frm_Receiving() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void receiveOrderRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Records
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Receiving_Records")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Receiving.Frm_Receiving_Record frm_in = new Frm_Receiving.Frm_Receiving_Record() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            //receiving report
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Receiving_History")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Receiving_History frm_in = new Frm_Report.Frm_Receiving_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void transactMoveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //transact move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Available_Transact")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Available_Transact frm_in = new Frm_Move_Order.Frm_Available_Transact() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void prodictCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //product_category
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Product_Category")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Product_Category.Frm_Product_Category frm_in = new Frm_Product_Category.Frm_Product_Category() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void miscellaneousReceiptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //miscellaneousReceiptToolStripMenuItem1.BackColor = Color.White;
            //miscellaneousReceiptToolStripMenuItem1.ForeColor = Color.Black;
        }

        private void miscellaneousIssueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //issue
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Issue")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Miscellaneous_Issue.Frm_Issue frm_in = new Frm_Miscellaneous_Issue.Frm_Issue() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void miscellaeousReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //receipt
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Receipt")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Miscellaneous_Receipt.Frm_Receipt frm_in = new Frm_Miscellaneous_Receipt.Frm_Receipt() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void transactedMoveOrderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //transact report
            //receipt
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Transact_Move_Order_History")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Transact_Move_Order_History frm_in = new Frm_Report.Frm_Transact_Move_Order_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void miscellaneousIssueRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //issue record
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Issue_Record")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Miscellaneous_Issue.Frm_Issue_Record frm_in = new Frm_Miscellaneous_Issue.Frm_Issue_Record() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void micellaneousReceiptRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //receipt record
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Receipt_Record")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Miscellaneous_Receipt.Frm_Receipt_Record frm_in = new Frm_Miscellaneous_Receipt.Frm_Receipt_Record() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void miscellaneousIssueHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ISSUE REPORT
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Issue_History")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Issue_History frm_in = new Frm_Report.Frm_Issue_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void miscellaneousReceiptHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //receipt
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Issue_History")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Receipt_History frm_in = new Frm_Report.Frm_Receipt_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void miscellaneousReceiptToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            //miscellaneousReceiptToolStripMenuItem1.BackColor = Color.White;
            //miscellaneousReceiptToolStripMenuItem1.ForeColor = Color.Black;
        }

        private void miscellaneousReceiptToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            //miscellaneousReceiptToolStripMenuItem1.BackColor = WindowFrame;
            //miscellaneousReceiptToolStripMenuItem1.ForeColor = Color.White;
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //area
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Area")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Area.Frm_Area frm_in = new Frm_Area.Frm_Area() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void printMoveOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Area")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Move_Order.Frm_Print_Move_Order frm_in = new Frm_Move_Order.Frm_Print_Move_Order() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void businessCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //business category
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Business_Category")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Business_Category.Frm_Business_Category frm_in = new Frm_Business_Category.Frm_Business_Category() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void cOAAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //account
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Coa_Account")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Coa_Account.Frm_Coa_Account frm_in = new Frm_Coa_Account.Frm_Coa_Account() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void cOACompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //company
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Coa_Company")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Coa_Company.Frm_Company frm_in = new Frm_Coa_Company.Frm_Company() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void cOADepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //coa_department
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Coa_Department")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Coa_Department.Frm_Coa_Department frm_in = new Frm_Coa_Department.Frm_Coa_Department() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void cOALocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //location
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Coa_Location")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Coa_Location.Frm_Coa_Location frm_in = new Frm_Coa_Location.Frm_Coa_Location() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void departmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //department
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Department")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Department.Frm_Department frm_in = new Frm_Department.Frm_Department() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //warehouse
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Department")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Warehouse.Frm_Warehouse frm_in = new Frm_Warehouse.Frm_Warehouse() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void taggingOfLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tagging
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Department")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Dept_Location.Frm_Dept_Location frm_in = new Frm_Dept_Location.Frm_Dept_Location() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void loadingChecklistReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //loading checklist
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Loading_Checklist_Report")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Loading_Checklist_Report frm_in = new Frm_Report.Frm_Loading_Checklist_Report() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void loadingChecklistReportPerRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //per route checklist
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Loading_Checklist_Report")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Loading_Checklist_Per_Route frm_in = new Frm_Report.Frm_Loading_Checklist_Per_Route() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void cancelledMoveOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cancelled move order
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Loading_Checklist_Report")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Cancelled_MOS frm_in = new Frm_Report.Frm_Cancelled_MOS() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void moveOrderRecordTranasctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //move order record transactions
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Loading_Checklist_Report")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Move_Order_Record_History frm_in = new Frm_Report.Frm_Move_Order_Record_History() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void deliveryVarianceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delivery variance report
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Delivery_Variance_Report")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Report.Frm_Delivery_Variance_Report frm_in = new Frm_Report.Frm_Delivery_Variance_Report() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }

        private void farmSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //farmsource
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Frm_Farm_Source")
                {
                    IsOpen = true;
                    f.BringToFront();
                    //MessageBox.Show("Already Open");
                    break;
                }
            }
            if (IsOpen == false)
            {
                Frm_Farm_Source.Frm_Farm_Source frm_in = new Frm_Farm_Source.Frm_Farm_Source() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel_body.Controls.Add(frm_in);
                frm_in.Show();
                frm_in.BringToFront();
            }
        }
    }
}
