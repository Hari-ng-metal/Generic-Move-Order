
namespace Generic_Move_Order.Frm_Move_Order
{
    partial class Frm_Edit_Move_Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_index = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.label_uom = new System.Windows.Forms.Label();
            this.cb_code = new System.Windows.Forms.ComboBox();
            this.text_desc = new System.Windows.Forms.TextBox();
            this.text_qty = new System.Windows.Forms.TextBox();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 40);
            this.panel1.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.label_index);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 222);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(695, 41);
            this.panel5.TabIndex = 12;
            // 
            // label_index
            // 
            this.label_index.AutoSize = true;
            this.label_index.Location = new System.Drawing.Point(12, 15);
            this.label_index.Name = "label_index";
            this.label_index.Size = new System.Drawing.Size(46, 17);
            this.label_index.TabIndex = 15;
            this.label_index.Text = "label8";
            this.label_index.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_id, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_uom, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cb_code, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_desc, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_qty, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 182);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(105, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 45);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(95, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(403, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 45);
            this.label4.TabIndex = 3;
            this.label4.Text = "Item Description:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cancel.Location = new System.Drawing.Point(522, 138);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 41);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_save.Location = new System.Drawing.Point(411, 138);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(105, 41);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "UPDATE";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(3, 135);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(16, 17);
            this.label_id.TabIndex = 13;
            this.label_id.Text = "0";
            this.label_id.Visible = false;
            // 
            // label_uom
            // 
            this.label_uom.AutoSize = true;
            this.label_uom.Location = new System.Drawing.Point(176, 135);
            this.label_uom.Name = "label_uom";
            this.label_uom.Size = new System.Drawing.Size(46, 17);
            this.label_uom.TabIndex = 14;
            this.label_uom.Text = "label8";
            this.label_uom.Visible = false;
            // 
            // cb_code
            // 
            this.cb_code.FormattingEnabled = true;
            this.cb_code.Location = new System.Drawing.Point(176, 3);
            this.cb_code.Name = "cb_code";
            this.cb_code.Size = new System.Drawing.Size(167, 24);
            this.cb_code.TabIndex = 17;
            this.cb_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_code_KeyDown);
            // 
            // text_desc
            // 
            this.text_desc.Enabled = false;
            this.text_desc.Location = new System.Drawing.Point(522, 3);
            this.text_desc.Name = "text_desc";
            this.text_desc.Size = new System.Drawing.Size(170, 22);
            this.text_desc.TabIndex = 18;
            // 
            // text_qty
            // 
            this.text_qty.Location = new System.Drawing.Point(176, 48);
            this.text_qty.Name = "text_qty";
            this.text_qty.Size = new System.Drawing.Size(167, 22);
            this.text_qty.TabIndex = 19;
            this.text_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_qty_KeyPress);
            // 
            // Frm_Edit_Move_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 263);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Edit_Move_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Edit_Move_Order";
            this.Load += new System.EventHandler(this.Frm_Edit_Move_Order_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label_index;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_uom;
        private System.Windows.Forms.ComboBox cb_code;
        private System.Windows.Forms.TextBox text_desc;
        private System.Windows.Forms.TextBox text_qty;
    }
}