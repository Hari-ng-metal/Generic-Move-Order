using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Generic_Move_Order
{
    public partial class Frm_Login : Form
    {
        Connection connect = new Connection();
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //Login();
            Ping();
        }

        private void Ping()
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send("10.10.2.6", 1000);
            //MessageBox.Show(reply.Status.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(reply.Status.ToString() == "Success")
            {
                Login();
            }
            else
            {
                MessageBox.Show(reply.Status.ToString()+"!", "Network Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetLoginUser", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", text_username.Text);
            cmd.Parameters.AddWithValue("@pass", text_mypassword.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count == 1)
            {
                try
                {
                    User.id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    User.name = dt.Rows[0]["name"].ToString();
                    User.username = dt.Rows[0]["username"].ToString();
                    User.role_id = int.Parse(dt.Rows[0]["role_id"].ToString());
                    User.role_name = dt.Rows[0]["role_name"].ToString();

                    Frm_Main frm_main = new Frm_Main();
                    this.Hide();
                    frm_main.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password!", "Login Dialog!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                text_username.Focus();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void text_mypassword_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (e.KeyCode == Keys.Enter)
            {
                //Login();
                Ping();
            }
        }
    }
}
