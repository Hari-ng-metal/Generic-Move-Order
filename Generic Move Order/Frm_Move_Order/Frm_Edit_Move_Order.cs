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

namespace Generic_Move_Order.Frm_Move_Order
{
    public partial class Frm_Edit_Move_Order : Form
    {
        Connection connect = new Connection();
        Frm_Move_Order frm;
        public Frm_Edit_Move_Order(Frm_Move_Order _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void Frm_Edit_Move_Order_Load(object sender, EventArgs e)
        {
            GetMasterlist();
            EditItem();

            cb_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_code.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_code.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void EditItem()
        {
            cb_code.Text = edit_move_item.item_code;
            label_id.Text = edit_move_item.id.ToString();
            text_desc.Text = edit_move_item.item_description;
            text_uom.Text = edit_move_item.uom.ToString();
            text_qty.Text = edit_move_item.quantity.ToString();
            text_slab.Text = edit_move_item.slab.ToString();
            label_index.Text = edit_move_item.index.ToString();
        }

        public void GetMasterlist()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetMasterlist", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_code.DataSource = dt;
                connect.con.Close();

                cb_code.ValueMember = "item_description";
                cb_code.DisplayMember = "item_code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_code.SelectedIndex = -1;
        }

        public void GetMaserlistByCode()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMasterlistById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_code.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();

            try
            {
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                    label_id.Text = dt.Rows[0]["int"].ToString();
                    text_desc.Text = dt.Rows[0]["item_description"].ToString();
                }
                else
                {
                    MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_desc.Clear();
                    label_id.Text = "0";
                    cb_code.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
        }

        public void GetUOMbyItemCode()
        {
            connect.DatabaseConnection();
            connect.con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMasterlistById", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", cb_code.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //dt_module.DataSource = dt;
            connect.con.Close();

            try
            {
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("" + dt.Rows[0]["item_description"]);
                    label_id.Text = dt.Rows[0]["int"].ToString();
                    text_desc.Text = dt.Rows[0]["item_description"].ToString();
                    text_uom.Text = dt.Rows[0]["uom"].ToString();
                }
                else
                {
                    //MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_desc.Clear();
                    text_uom.Clear();
                    label_id.Text = "0";
                    cb_code.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void text_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cb_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetMaserlistByCode();
                if (string.IsNullOrEmpty(label_id.Text))
                {
                    MessageBox.Show("You enter invalid item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_desc.Clear();
                    label_id.Text = "0";
                }
            }
        }

        public void UpdateItem()
        {
            frm.dt_move.Rows[edit_move_item.index].Cells[0].Value = label_id.Text;
            frm.dt_move.Rows[edit_move_item.index].Cells[1].Value = cb_code.Text;
            frm.dt_move.Rows[edit_move_item.index].Cells[2].Value = text_desc.Text;
            frm.dt_move.Rows[edit_move_item.index].Cells[3].Value = text_uom.Text;
            frm.dt_move.Rows[edit_move_item.index].Cells[4].Value = text_qty.Text;
            frm.dt_move.Rows[edit_move_item.index].Cells[5].Value = text_slab.Text;

            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            GetMaserlistByCode();
            if (string.IsNullOrEmpty(cb_code.Text) || string.IsNullOrEmpty(text_desc.Text) || string.IsNullOrEmpty(text_qty.Text))
            {
                //MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_code.Focus();
            }
            else
            {
                GetMaserlistByCode();
                if (int.Parse(label_id.Text.ToString()) > 0)
                {
                    UpdateItem();
                    frm.dt_move.ClearSelection();
                }
                else
                {
                    cb_code.Focus();
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_code.SelectedIndex >= 0)
            {
                text_desc.Text = cb_code.SelectedValue.ToString();
                GetUOMbyItemCode();
            }
        }

        private void text_slab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void text_slab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                GetMaserlistByCode();
                if (string.IsNullOrEmpty(cb_code.Text) || string.IsNullOrEmpty(text_desc.Text) || string.IsNullOrEmpty(text_qty.Text))
                {
                    //MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_code.Focus();
                }
                else
                {
                    GetMaserlistByCode();
                    if (int.Parse(label_id.Text.ToString()) > 0)
                    {
                        UpdateItem();
                        frm.dt_move.ClearSelection();
                    }
                    else
                    {
                        cb_code.Focus();
                    }
                }
            }
        }
    }
}
