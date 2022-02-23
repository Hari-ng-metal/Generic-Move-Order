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

                if (mod_name == "menuStrip1")
                {
                    menuStrip1.Visible = true;
                }

                if (mod_name == "menuStrip2")
                {
                    menuStrip2.Visible = true;
                }

                if (mod_name == "menuStrip3")
                {
                    menuStrip3.Visible = true;
                }

                if (mod_name == "menuStrip4")
                {
                    menuStrip4.Visible = true;
                }
                if (mod_name == "menuStrip5")
                {
                    menuStrip5.Visible = true;
                }
                if (mod_name == "menuStrip6")
                {
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
            label_user.Text = "Welcome, "+User.username;
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
    }
}
