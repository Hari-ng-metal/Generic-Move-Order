﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Move_Order.Frm_Module
{
    public partial class Frm_Add_Module : Form
    {
        Connection connect = new Connection();
        bool status;

        Frm_Module frm;
        public Frm_Add_Module(Frm_Module _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void InsertModule()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertModule", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@module", text_module.Text);
                cmd.Parameters.AddWithValue("@path", text_path.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void UpdateModule()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateModule", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", edit_module.id);
                cmd.Parameters.AddWithValue("@module", text_module.Text);
                cmd.Parameters.AddWithValue("@path", text_path.Text);
                cmd.Parameters.AddWithValue("@status", label_status.Text);
                cmd.Parameters.AddWithValue("@logged_user", User.id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                //dt_user.DataSource = dt;
                connect.con.Close();

                MessageBox.Show("Successfully Save!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void AddOrEdit()
        {
            if (edit_module.id > 0)
            {
                text_module.Text = edit_module.module_name;
                text_path.Text = edit_module.path_name;
                label_status.Text = edit_module.status.ToString();
                if (label_status.Text == true.ToString())
                {
                    cb_status.SelectedIndex = 0;
                }
                else
                {
                    cb_status.SelectedIndex = 1;
                }

                btn_save.Text = "UPDATE";
                text_module.Enabled = false;
            }
            else
            {
                btn_save.Text = "SAVE";
                cb_status.SelectedIndex = 0;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to save?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                if (text_module.Text == string.Empty || cb_status.Text == string.Empty || text_path.Text == string.Empty)
                {
                    MessageBox.Show("Please input the required field!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Some task…
                if (edit_module.id > 0)
                {
                    UpdateModule();
                    this.Close();
                }
                else
                {
                    CheckIfItemExist();
                }
            }
            if (res == DialogResult.No)
            {
                //Some task…  
            }
            frm.GetModule();
            frm.dt_module.ClearSelection();
        }

        private void cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (cb_status.Text == "Active")
            {
                status = true;
                label_status.Text = status.ToString();
            }
            else
            {
                status = false;
                label_status.Text = status.ToString();
            }
        }

        private void Frm_Add_Module_Load(object sender, EventArgs e)
        {
            AddOrEdit();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckIfItemExist()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_ValidateIfExistByMode", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@module", text_module.Text);
            cmd.Parameters.AddWithValue("@mode", "module");
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_report.DataSource = dt;
            connect.con.Close();
            if (dt.Rows.Count >= 1)
            {
                try
                {
                    MessageBox.Show("Item is already exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else
            {
                InsertModule();
                this.Close();
            }
        }
    }
}
