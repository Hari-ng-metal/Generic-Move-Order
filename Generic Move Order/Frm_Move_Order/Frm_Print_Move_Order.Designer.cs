
namespace Generic_Move_Order.Frm_Move_Order
{
    partial class Frm_Print_Move_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_exit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_area = new System.Windows.Forms.ComboBox();
            this.cb_copy = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_role_counting = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_generate = new System.Windows.Forms.Button();
            this.dt_move_order = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_move_order)).BeginInit();
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
            this.panel1.TabIndex = 22;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "MOVE ORDER PRINTING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 76);
            this.panel2.TabIndex = 25;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dp_start, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dp_end, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cb_area, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_copy, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 76);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "AREA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "START:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "LIST OF RECORD:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "END:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dp_start
            // 
            this.dp_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_start.Location = new System.Drawing.Point(580, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(187, 22);
            this.dp_start.TabIndex = 6;
            // 
            // dp_end
            // 
            this.dp_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_end.Location = new System.Drawing.Point(580, 28);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(187, 22);
            this.dp_end.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(53, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "# OF COPY/S:";
            // 
            // cb_area
            // 
            this.cb_area.FormattingEnabled = true;
            this.cb_area.Location = new System.Drawing.Point(157, 3);
            this.cb_area.Name = "cb_area";
            this.cb_area.Size = new System.Drawing.Size(225, 24);
            this.cb_area.TabIndex = 9;
            this.cb_area.SelectedIndexChanged += new System.EventHandler(this.cb_area_SelectedIndexChanged);
            // 
            // cb_copy
            // 
            this.cb_copy.FormattingEnabled = true;
            this.cb_copy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_copy.Location = new System.Drawing.Point(157, 28);
            this.cb_copy.Name = "cb_copy";
            this.cb_copy.Size = new System.Drawing.Size(225, 24);
            this.cb_copy.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(770, 100);
            this.panel3.TabIndex = 26;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.875F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.125F));
            this.tableLayoutPanel2.Controls.Add(this.label_role_counting, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 59);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label_role_counting
            // 
            this.label_role_counting.AutoSize = true;
            this.label_role_counting.Location = new System.Drawing.Point(3, 0);
            this.label_role_counting.Name = "label_role_counting";
            this.label_role_counting.Size = new System.Drawing.Size(93, 29);
            this.label_role_counting.TabIndex = 0;
            this.label_role_counting.Text = "TOTAL # OF RECORD/S:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.btn_print);
            this.panel5.Controls.Add(this.btn_generate);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(770, 41);
            this.panel5.TabIndex = 2;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_print.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_print.Location = new System.Drawing.Point(105, 0);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(105, 41);
            this.btn_print.TabIndex = 7;
            this.btn_print.Text = "PRINT";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_generate
            // 
            this.btn_generate.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_generate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_generate.Location = new System.Drawing.Point(0, 0);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(105, 41);
            this.btn_generate.TabIndex = 6;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseVisualStyleBackColor = false;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // dt_move_order
            // 
            this.dt_move_order.AllowUserToAddRows = false;
            this.dt_move_order.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_move_order.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dt_move_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_move_order.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_move_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_move_order.Location = new System.Drawing.Point(0, 116);
            this.dt_move_order.Name = "dt_move_order";
            this.dt_move_order.RowHeadersWidth = 51;
            this.dt_move_order.RowTemplate.Height = 24;
            this.dt_move_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_move_order.Size = new System.Drawing.Size(770, 311);
            this.dt_move_order.TabIndex = 29;
            // 
            // Frm_Print_Move_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(770, 527);
            this.Controls.Add(this.dt_move_order);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Print_Move_Order";
            this.Text = "Print Move Order";
            this.Load += new System.EventHandler(this.Frm_Print_Move_Order_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_move_order)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_role_counting;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.DataGridView dt_move_order;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_area;
        private System.Windows.Forms.ComboBox cb_copy;
    }
}