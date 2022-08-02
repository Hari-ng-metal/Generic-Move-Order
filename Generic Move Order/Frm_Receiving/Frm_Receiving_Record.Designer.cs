
namespace Generic_Move_Order.Frm_Receiving
{
    partial class Frm_Receiving_Record
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_exit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_role_counting = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_inactive = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.dt_receiving = new System.Windows.Forms.DataGridView();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_receiving)).BeginInit();
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
            this.panel1.TabIndex = 27;
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
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RECEIVING RECORD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 76);
            this.panel2.TabIndex = 28;
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
            this.tableLayoutPanel1.Controls.Add(this.cb_status, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dp_start, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dp_end, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
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
            this.label2.Location = new System.Drawing.Point(83, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "SEARCH:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(507, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "STATUS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "LIST OF RECEIVING:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Items.AddRange(new object[] {
            "Active",
            "inActive"});
            this.cb_status.Location = new System.Drawing.Point(580, 3);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(121, 24);
            this.cb_status.TabIndex = 3;
            this.cb_status.SelectedIndexChanged += new System.EventHandler(this.cb_status_SelectedIndexChanged);
            this.cb_status.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_status_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(770, 100);
            this.panel3.TabIndex = 29;
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
            this.label_role_counting.Size = new System.Drawing.Size(137, 29);
            this.label_role_counting.TabIndex = 0;
            this.label_role_counting.Text = "TOTAL # OF MOVE RECEIVING/S:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.btn_inactive);
            this.panel5.Controls.Add(this.btn_print);
            this.panel5.Controls.Add(this.btn_view);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(770, 41);
            this.panel5.TabIndex = 2;
            // 
            // btn_inactive
            // 
            this.btn_inactive.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_inactive.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_inactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inactive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_inactive.Location = new System.Drawing.Point(210, 0);
            this.btn_inactive.Name = "btn_inactive";
            this.btn_inactive.Size = new System.Drawing.Size(105, 41);
            this.btn_inactive.TabIndex = 8;
            this.btn_inactive.Text = "INACTIVE";
            this.btn_inactive.UseVisualStyleBackColor = false;
            this.btn_inactive.Click += new System.EventHandler(this.btn_inactive_Click);
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
            // btn_view
            // 
            this.btn_view.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_view.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_view.Location = new System.Drawing.Point(0, 0);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(105, 41);
            this.btn_view.TabIndex = 6;
            this.btn_view.Text = "VIEW";
            this.btn_view.UseVisualStyleBackColor = false;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // dt_receiving
            // 
            this.dt_receiving.AllowUserToAddRows = false;
            this.dt_receiving.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_receiving.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dt_receiving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_receiving.DefaultCellStyle = dataGridViewCellStyle3;
            this.dt_receiving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_receiving.Location = new System.Drawing.Point(0, 116);
            this.dt_receiving.Name = "dt_receiving";
            this.dt_receiving.RowHeadersWidth = 51;
            this.dt_receiving.RowTemplate.Height = 24;
            this.dt_receiving.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_receiving.Size = new System.Drawing.Size(770, 311);
            this.dt_receiving.TabIndex = 30;
            this.dt_receiving.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_receiving_CellClick);
            this.dt_receiving.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dt_receiving_DataBindingComplete);
            // 
            // dp_start
            // 
            this.dp_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_start.Location = new System.Drawing.Point(580, 28);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(121, 22);
            this.dp_start.TabIndex = 9;
            this.dp_start.ValueChanged += new System.EventHandler(this.dp_start_ValueChanged);
            // 
            // dp_end
            // 
            this.dp_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_end.Location = new System.Drawing.Point(580, 53);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(121, 22);
            this.dp_end.TabIndex = 10;
            this.dp_end.ValueChanged += new System.EventHandler(this.dp_end_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(516, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "START:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(533, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "END:";
            // 
            // Frm_Receiving_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(770, 527);
            this.Controls.Add(this.dt_receiving);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Receiving_Record";
            this.Text = "Frm_Receiving_Record";
            this.Load += new System.EventHandler(this.Frm_Receiving_Record_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dt_receiving)).EndInit();
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
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_role_counting;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_inactive;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.DataGridView dt_receiving;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}