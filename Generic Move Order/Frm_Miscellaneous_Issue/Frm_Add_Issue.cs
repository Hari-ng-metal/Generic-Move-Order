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

namespace Generic_Move_Order.Frm_Miscellaneous_Issue
{
    public partial class Frm_Add_Issue : Form
    {
        Connection connect = new Connection();
        Frm_Issue frm;
        public Frm_Add_Issue(Frm_Issue _frm)
        {
            InitializeComponent();
            this.frm = _frm;
        }

        private void Frm_Add_Issue_Load(object sender, EventArgs e)
        {
            cb_code.Select();
            cb_code.Focus();
            GetMasterlist();
            GetFarmSource();
            text_desc.Clear();
            text_uom.Clear();

            cb_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_code.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_code.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void AddItem()
        {
            try
            {
                frm.dt_issue.Rows.Add(label_id.Text, cb_code.Text, text_desc.Text, text_uom.Text, text_qty.Text, text_slab.Text, cb_farm.Text, text_production_date.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }


            this.Close();
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

        public void GetFarmSource()
        {
            try
            {
                connect.DatabaseConnection();
                connect.con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetFarmSource", connect.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", true);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cb_farm.DataSource = dt;
                connect.con.Close();

                cb_farm.ValueMember = "farm_source";
                cb_farm.DisplayMember = "code";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            cb_farm.SelectedIndex = -1;
            cb_farm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cb_farm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_farm.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void cb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_code.SelectedIndex >= 0)
            {
                text_desc.Text = cb_code.SelectedValue.ToString();
                GetUOMbyItemCode();
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void text_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                GetMaserlistByCode();
                if (string.IsNullOrEmpty(cb_code.Text) || string.IsNullOrEmpty(text_desc.Text) || string.IsNullOrEmpty(text_qty.Text) || string.IsNullOrEmpty(text_slab.Text) || string.IsNullOrEmpty(text_production_date.Text) || string.IsNullOrEmpty(cb_farm.Text))
                {
                    //MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_code.Focus();
                }
                else
                {
                    GetMaserlistByCode();
                    if (int.Parse(label_id.Text.ToString()) > 0)
                    {
                        AddItem();
                    }
                    else
                    {
                        cb_code.Focus();
                    }
                }
                frm.dt_issue.ClearSelection();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            GetMaserlistByCode();
            if (string.IsNullOrEmpty(cb_code.Text) || string.IsNullOrEmpty(text_desc.Text) || string.IsNullOrEmpty(text_qty.Text) || string.IsNullOrEmpty(text_slab.Text) || string.IsNullOrEmpty(text_production_date.Text) || string.IsNullOrEmpty(cb_farm.Text)) 
            {
                //MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_code.Focus();
            }
            else
            {
                GetMaserlistByCode();
                if (int.Parse(label_id.Text.ToString()) > 0)
                {
                    AddItem();
                }
                else
                {
                    cb_code.Focus();
                }
            }
            frm.dt_issue.ClearSelection();
        }

        private void cb_farm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                GetMaserlistByCode();
                if (string.IsNullOrEmpty(cb_code.Text) || string.IsNullOrEmpty(text_desc.Text) || string.IsNullOrEmpty(text_qty.Text) || string.IsNullOrEmpty(text_slab.Text) || string.IsNullOrEmpty(text_production_date.Text) || string.IsNullOrEmpty(cb_farm.Text))
                {
                    //MessageBox.Show("Please input the required field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_code.Focus();
                }
                else
                {
                    GetMaserlistByCode();
                    if (int.Parse(label_id.Text.ToString()) > 0)
                    {
                        AddItem();
                    }
                    else
                    {
                        cb_code.Focus();
                    }
                }
                frm.dt_issue.ClearSelection();
            }
        }

        private void cb_farm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void text_production_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }
    }
    }
