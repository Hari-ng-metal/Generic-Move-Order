
namespace Generic_Move_Order.Frm_Move_Order
{
    partial class Frm_Move_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.text_transaction_description = new System.Windows.Forms.TextBox();
            this.text_sales_id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_customer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.cb_reason = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_bcategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.text_reference = new System.Windows.Forms.TextBox();
            this.dp_delivery_date = new System.Windows.Forms.DateTimePicker();
            this.text_date = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_customer_id = new System.Windows.Forms.Label();
            this.text_account = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_counting = new System.Windows.Forms.Label();
            this.label_bcategory_id = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.dt_move = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pb_exit = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_move)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pb_exit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 40);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "MOVE ORDER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 120);
            this.panel2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.9621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.54455F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31539F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.17796F));
            this.tableLayoutPanel1.Controls.Add(this.text_transaction_description, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.text_sales_id, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cb_customer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.text_name, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cb_reason, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cb_bcategory, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.text_reference, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.dp_delivery_date, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 132);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // text_transaction_description
            // 
            this.text_transaction_description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_transaction_description.Location = new System.Drawing.Point(172, 95);
            this.text_transaction_description.Name = "text_transaction_description";
            this.text_transaction_description.Size = new System.Drawing.Size(236, 22);
            this.text_transaction_description.TabIndex = 4;
            this.text_transaction_description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_transaction_description_KeyDown);
            // 
            // text_sales_id
            // 
            this.text_sales_id.Enabled = false;
            this.text_sales_id.Location = new System.Drawing.Point(172, 3);
            this.text_sales_id.Name = "text_sales_id";
            this.text_sales_id.Size = new System.Drawing.Size(236, 22);
            this.text_sales_id.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(102, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 28);
            this.label6.TabIndex = 41;
            this.label6.Text = "Order Id:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(421, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 28);
            this.label8.TabIndex = 42;
            this.label8.Text = "Delivery Date:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Customer Code:";
            // 
            // cb_customer
            // 
            this.cb_customer.FormattingEnabled = true;
            this.cb_customer.Location = new System.Drawing.Point(172, 61);
            this.cb_customer.Name = "cb_customer";
            this.cb_customer.Size = new System.Drawing.Size(236, 24);
            this.cb_customer.TabIndex = 2;
            this.cb_customer.SelectedIndexChanged += new System.EventHandler(this.cb_customer_SelectedIndexChanged);
            this.cb_customer.TextChanged += new System.EventHandler(this.cb_customer_TextChanged);
            this.cb_customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_customer_KeyDown);
            this.cb_customer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_customer_KeyPress);
            this.cb_customer.Leave += new System.EventHandler(this.cb_customer_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(36, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 30);
            this.label2.TabIndex = 44;
            this.label2.Text = "Business Category:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 34);
            this.label3.TabIndex = 10;
            this.label3.Text = "Customer Name:";
            // 
            // text_name
            // 
            this.text_name.Enabled = false;
            this.text_name.Location = new System.Drawing.Point(524, 61);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(243, 22);
            this.text_name.TabIndex = 6;
            // 
            // cb_reason
            // 
            this.cb_reason.FormattingEnabled = true;
            this.cb_reason.Items.AddRange(new object[] {
            "PICK-UP",
            "DELIVERY"});
            this.cb_reason.Location = new System.Drawing.Point(524, 31);
            this.cb_reason.Name = "cb_reason";
            this.cb_reason.Size = new System.Drawing.Size(243, 24);
            this.cb_reason.TabIndex = 3;
            this.cb_reason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_reason_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(457, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 30);
            this.label4.TabIndex = 47;
            this.label4.Text = "Reason:";
            // 
            // cb_bcategory
            // 
            this.cb_bcategory.FormattingEnabled = true;
            this.cb_bcategory.Location = new System.Drawing.Point(172, 31);
            this.cb_bcategory.Name = "cb_bcategory";
            this.cb_bcategory.Size = new System.Drawing.Size(236, 24);
            this.cb_bcategory.TabIndex = 1;
            this.cb_bcategory.SelectedIndexChanged += new System.EventHandler(this.cb_bcategory_SelectedIndexChanged);
            this.cb_bcategory.SelectionChangeCommitted += new System.EventHandler(this.cb_bcategory_SelectionChangeCommitted);
            this.cb_bcategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_bcategory_KeyDown);
            this.cb_bcategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_bcategory_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(83, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 40);
            this.label9.TabIndex = 49;
            this.label9.Text = "Description:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Location = new System.Drawing.Point(440, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 40);
            this.label10.TabIndex = 50;
            this.label10.Text = "Reference:";
            // 
            // text_reference
            // 
            this.text_reference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_reference.Location = new System.Drawing.Point(524, 95);
            this.text_reference.Name = "text_reference";
            this.text_reference.Size = new System.Drawing.Size(243, 22);
            this.text_reference.TabIndex = 5;
            // 
            // dp_delivery_date
            // 
            this.dp_delivery_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_delivery_date.Location = new System.Drawing.Point(524, 3);
            this.dp_delivery_date.Name = "dp_delivery_date";
            this.dp_delivery_date.Size = new System.Drawing.Size(243, 22);
            this.dp_delivery_date.TabIndex = 0;
            this.dp_delivery_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dp_delivery_date_KeyPress);
            // 
            // text_date
            // 
            this.text_date.Enabled = false;
            this.text_date.Location = new System.Drawing.Point(3, 32);
            this.text_date.Name = "text_date";
            this.text_date.Size = new System.Drawing.Size(147, 22);
            this.text_date.TabIndex = 43;
            this.text_date.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(770, 32);
            this.panel3.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.33181F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.66819F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_customer_id, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.text_account, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 32);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Account Title:";
            // 
            // label_customer_id
            // 
            this.label_customer_id.AutoSize = true;
            this.label_customer_id.Location = new System.Drawing.Point(383, 0);
            this.label_customer_id.Name = "label_customer_id";
            this.label_customer_id.Size = new System.Drawing.Size(16, 17);
            this.label_customer_id.TabIndex = 12;
            this.label_customer_id.Text = "0";
            this.label_customer_id.Visible = false;
            // 
            // text_account
            // 
            this.text_account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_account.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_account.Location = new System.Drawing.Point(103, 3);
            this.text_account.Name = "text_account";
            this.text_account.Size = new System.Drawing.Size(274, 22);
            this.text_account.TabIndex = 6;
            this.text_account.TextChanged += new System.EventHandler(this.text_account_TextChanged);
            this.text_account.DoubleClick += new System.EventHandler(this.text_account_DoubleClick);
            this.text_account.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_account_KeyDown);
            this.text_account.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_account_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.btn_save);
            this.panel5.Controls.Add(this.btn_cancel);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(770, 41);
            this.panel5.TabIndex = 11;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_save.Location = new System.Drawing.Point(481, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(105, 41);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cancel.Location = new System.Drawing.Point(586, 0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 41);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(691, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(79, 41);
            this.panel7.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 427);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 100);
            this.panel4.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.875F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.125F));
            this.tableLayoutPanel3.Controls.Add(this.label_counting, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_bcategory_id, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.text_date, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(770, 59);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label_counting
            // 
            this.label_counting.AutoSize = true;
            this.label_counting.Location = new System.Drawing.Point(3, 0);
            this.label_counting.Name = "label_counting";
            this.label_counting.Size = new System.Drawing.Size(142, 17);
            this.label_counting.TabIndex = 0;
            this.label_counting.Text = "TOTAL # OF ITEM/S:";
            // 
            // label_bcategory_id
            // 
            this.label_bcategory_id.AutoSize = true;
            this.label_bcategory_id.Location = new System.Drawing.Point(156, 0);
            this.label_bcategory_id.Name = "label_bcategory_id";
            this.label_bcategory_id.Size = new System.Drawing.Size(16, 17);
            this.label_bcategory_id.TabIndex = 1;
            this.label_bcategory_id.Text = "0";
            this.label_bcategory_id.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.btn_edit);
            this.panel6.Controls.Add(this.btn_new);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 59);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(770, 41);
            this.panel6.TabIndex = 2;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_edit.Location = new System.Drawing.Point(105, 0);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(105, 41);
            this.btn_edit.TabIndex = 9;
            this.btn_edit.Text = "EDIT";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_new.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_new.Location = new System.Drawing.Point(0, 0);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(105, 41);
            this.btn_new.TabIndex = 4;
            this.btn_new.Text = "NEW";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // dt_move
            // 
            this.dt_move.AllowUserToAddRows = false;
            this.dt_move.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_move.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dt_move.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_move.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.item_code,
            this.item_description,
            this.UOM,
            this.quantity,
            this.slab,
            this.remove});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_move.DefaultCellStyle = dataGridViewCellStyle8;
            this.dt_move.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_move.Location = new System.Drawing.Point(0, 233);
            this.dt_move.Name = "dt_move";
            this.dt_move.RowHeadersWidth = 51;
            this.dt_move.RowTemplate.Height = 24;
            this.dt_move.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_move.Size = new System.Drawing.Size(770, 194);
            this.dt_move.TabIndex = 13;
            this.dt_move.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_move_CellClick);
            this.dt_move.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_move_CellContentClick);
            this.dt_move.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dt_move_RowStateChanged);
            // 
            // id
            // 
            this.id.FillWeight = 111.631F;
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            // 
            // item_code
            // 
            this.item_code.FillWeight = 111.631F;
            this.item_code.HeaderText = "item_code";
            this.item_code.MinimumWidth = 6;
            this.item_code.Name = "item_code";
            // 
            // item_description
            // 
            this.item_description.FillWeight = 111.631F;
            this.item_description.HeaderText = "item_description";
            this.item_description.MinimumWidth = 6;
            this.item_description.Name = "item_description";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "uom";
            this.UOM.MinimumWidth = 6;
            this.UOM.Name = "UOM";
            // 
            // quantity
            // 
            this.quantity.FillWeight = 111.631F;
            this.quantity.HeaderText = "quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            // 
            // slab
            // 
            this.slab.HeaderText = "slab";
            this.slab.MinimumWidth = 6;
            this.slab.Name = "slab";
            this.slab.ReadOnly = true;
            // 
            // remove
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.remove.DefaultCellStyle = dataGridViewCellStyle7;
            this.remove.FillWeight = 53.47594F;
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.HeaderText = "remove";
            this.remove.MinimumWidth = 3;
            this.remove.Name = "remove";
            this.remove.Text = "(-)";
            // 
            // pb_exit
            // 
            this.pb_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_exit.Image = global::Generic_Move_Order.Properties.Resources.delete_sign_FLAT_32px;
            this.pb_exit.Location = new System.Drawing.Point(738, 0);
            this.pb_exit.Name = "pb_exit";
            this.pb_exit.Size = new System.Drawing.Size(32, 40);
            this.pb_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_exit.TabIndex = 7;
            this.pb_exit.TabStop = false;
            this.pb_exit.Click += new System.EventHandler(this.pb_exit_Click);
            // 
            // Frm_Move_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(770, 527);
            this.Controls.Add(this.dt_move);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Move_Order";
            this.Text = "Frm_Move_Order";
            this.Load += new System.EventHandler(this.Frm_Move_Order_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Move_Order_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_Move_Order_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_move)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox text_sales_id;
        private System.Windows.Forms.ComboBox cb_customer;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_date;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox text_transaction_description;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_customer_id;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_counting;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_new;
        public System.Windows.Forms.DataGridView dt_move;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn slab;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_reason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_bcategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_reference;
        private System.Windows.Forms.Label label_bcategory_id;
        public System.Windows.Forms.TextBox text_account;
        private System.Windows.Forms.DateTimePicker dp_delivery_date;
    }
}