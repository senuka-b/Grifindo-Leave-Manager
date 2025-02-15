namespace Grifindo_Leave_Manager.view {
    partial class EmployeeDashboardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxEmployeeRooster = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimePickerRoasterEnd = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePickerRoasterStart = new System.Windows.Forms.DateTimePicker();
            this.listBoxAppliedLeaves = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonRequestLeave = new System.Windows.Forms.Button();
            this.buttonDeleteLeave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDaysOrHours = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDaysOrHoursValue = new System.Windows.Forms.Label();
            this.labelLeaveType = new System.Windows.Forms.Label();
            this.labelLeaveStatus = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelUsername.Location = new System.Drawing.Point(997, 25);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(102, 25);
            this.labelUsername.TabIndex = 6;
            this.labelUsername.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(779, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "You are logged in as :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.NavajoWhite;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(683, 69);
            this.label2.TabIndex = 4;
            this.label2.Text = "Griffindo Lanka Toys 🧸\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(491, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(176, 25);
            this.label16.TabIndex = 17;
            this.label16.Text = "Select Leave Type";
            // 
            // comboBoxEmployeeRooster
            // 
            this.comboBoxEmployeeRooster.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.comboBoxEmployeeRooster.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEmployeeRooster.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxEmployeeRooster.Items.AddRange(new object[] {
            ""});
            this.comboBoxEmployeeRooster.Location = new System.Drawing.Point(26, 122);
            this.comboBoxEmployeeRooster.Name = "comboBoxEmployeeRooster";
            this.comboBoxEmployeeRooster.Size = new System.Drawing.Size(428, 39);
            this.comboBoxEmployeeRooster.TabIndex = 16;
            this.comboBoxEmployeeRooster.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmployeeRooster_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(379, 195);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 25);
            this.label18.TabIndex = 24;
            this.label18.Text = "Leave End : ";
            // 
            // dateTimePickerRoasterEnd
            // 
            this.dateTimePickerRoasterEnd.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerRoasterEnd.CalendarTitleBackColor = System.Drawing.Color.AntiqueWhite;
            this.dateTimePickerRoasterEnd.CalendarTitleForeColor = System.Drawing.Color.AntiqueWhite;
            this.dateTimePickerRoasterEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerRoasterEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerRoasterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRoasterEnd.Location = new System.Drawing.Point(384, 235);
            this.dateTimePickerRoasterEnd.Name = "dateTimePickerRoasterEnd";
            this.dateTimePickerRoasterEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerRoasterEnd.Size = new System.Drawing.Size(301, 38);
            this.dateTimePickerRoasterEnd.TabIndex = 23;
            this.dateTimePickerRoasterEnd.Value = new System.DateTime(2025, 2, 1, 23, 20, 48, 0);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(21, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 25);
            this.label17.TabIndex = 22;
            this.label17.Text = "Leave Start :";
            // 
            // dateTimePickerRoasterStart
            // 
            this.dateTimePickerRoasterStart.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerRoasterStart.CalendarTitleBackColor = System.Drawing.Color.AntiqueWhite;
            this.dateTimePickerRoasterStart.CalendarTitleForeColor = System.Drawing.Color.AntiqueWhite;
            this.dateTimePickerRoasterStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerRoasterStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerRoasterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRoasterStart.Location = new System.Drawing.Point(26, 235);
            this.dateTimePickerRoasterStart.Name = "dateTimePickerRoasterStart";
            this.dateTimePickerRoasterStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerRoasterStart.Size = new System.Drawing.Size(301, 38);
            this.dateTimePickerRoasterStart.TabIndex = 21;
            this.dateTimePickerRoasterStart.Value = new System.DateTime(2025, 2, 1, 0, 0, 0, 0);
            // 
            // listBoxAppliedLeaves
            // 
            this.listBoxAppliedLeaves.BackColor = System.Drawing.Color.AntiqueWhite;
            this.listBoxAppliedLeaves.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAppliedLeaves.FormattingEnabled = true;
            this.listBoxAppliedLeaves.ItemHeight = 31;
            this.listBoxAppliedLeaves.Items.AddRange(new object[] {
            "No items here yet..."});
            this.listBoxAppliedLeaves.Location = new System.Drawing.Point(24, 308);
            this.listBoxAppliedLeaves.Name = "listBoxAppliedLeaves";
            this.listBoxAppliedLeaves.Size = new System.Drawing.Size(661, 252);
            this.listBoxAppliedLeaves.TabIndex = 25;
            this.listBoxAppliedLeaves.SelectedIndexChanged += new System.EventHandler(this.listBoxAppliedLeaves_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(712, 540);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(437, 20);
            this.label15.TabIndex = 26;
            this.label15.Text = "To delete a leave, select it from the list and press delete !";
            // 
            // buttonRequestLeave
            // 
            this.buttonRequestLeave.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRequestLeave.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRequestLeave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRequestLeave.Location = new System.Drawing.Point(889, 108);
            this.buttonRequestLeave.Name = "buttonRequestLeave";
            this.buttonRequestLeave.Size = new System.Drawing.Size(210, 66);
            this.buttonRequestLeave.TabIndex = 27;
            this.buttonRequestLeave.Text = "Request Leave";
            this.buttonRequestLeave.UseVisualStyleBackColor = false;
            this.buttonRequestLeave.Click += new System.EventHandler(this.buttonRequestLeave_Click);
            // 
            // buttonDeleteLeave
            // 
            this.buttonDeleteLeave.BackColor = System.Drawing.Color.LightSalmon;
            this.buttonDeleteLeave.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteLeave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDeleteLeave.Location = new System.Drawing.Point(889, 207);
            this.buttonDeleteLeave.Name = "buttonDeleteLeave";
            this.buttonDeleteLeave.Size = new System.Drawing.Size(210, 66);
            this.buttonDeleteLeave.TabIndex = 29;
            this.buttonDeleteLeave.Text = "Delete Leave";
            this.buttonDeleteLeave.UseVisualStyleBackColor = false;
            this.buttonDeleteLeave.Click += new System.EventHandler(this.buttonDeleteLeave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(722, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Leave info :";
            // 
            // labelDaysOrHours
            // 
            this.labelDaysOrHours.AutoSize = true;
            this.labelDaysOrHours.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDaysOrHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDaysOrHours.Location = new System.Drawing.Point(769, 364);
            this.labelDaysOrHours.Name = "labelDaysOrHours";
            this.labelDaysOrHours.Size = new System.Drawing.Size(162, 22);
            this.labelDaysOrHours.TabIndex = 31;
            this.labelDaysOrHours.Text = "Number of days :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(769, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 32;
            this.label5.Text = "Leave type :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(769, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Status : ";
            // 
            // labelDaysOrHoursValue
            // 
            this.labelDaysOrHoursValue.AutoSize = true;
            this.labelDaysOrHoursValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDaysOrHoursValue.Location = new System.Drawing.Point(937, 364);
            this.labelDaysOrHoursValue.Name = "labelDaysOrHoursValue";
            this.labelDaysOrHoursValue.Size = new System.Drawing.Size(20, 22);
            this.labelDaysOrHoursValue.TabIndex = 34;
            this.labelDaysOrHoursValue.Text = "0";
            // 
            // labelLeaveType
            // 
            this.labelLeaveType.AutoSize = true;
            this.labelLeaveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeaveType.Location = new System.Drawing.Point(895, 405);
            this.labelLeaveType.Name = "labelLeaveType";
            this.labelLeaveType.Size = new System.Drawing.Size(152, 22);
            this.labelLeaveType.TabIndex = 35;
            this.labelLeaveType.Text = "awaiting selection";
            // 
            // labelLeaveStatus
            // 
            this.labelLeaveStatus.AutoSize = true;
            this.labelLeaveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeaveStatus.Location = new System.Drawing.Point(860, 450);
            this.labelLeaveStatus.Name = "labelLeaveStatus";
            this.labelLeaveStatus.Size = new System.Drawing.Size(152, 22);
            this.labelLeaveStatus.TabIndex = 36;
            this.labelLeaveStatus.Text = "awaiting selection";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Magenta;
            this.buttonRefresh.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRefresh.Location = new System.Drawing.Point(582, 522);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(85, 28);
            this.buttonRefresh.TabIndex = 37;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // EmployeeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 586);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelLeaveStatus);
            this.Controls.Add(this.labelLeaveType);
            this.Controls.Add(this.labelDaysOrHoursValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDaysOrHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteLeave);
            this.Controls.Add(this.buttonRequestLeave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBoxAppliedLeaves);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dateTimePickerRoasterEnd);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dateTimePickerRoasterStart);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBoxEmployeeRooster);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "EmployeeDashboardForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "EmployeeDashboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxEmployeeRooster;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePickerRoasterEnd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePickerRoasterStart;
        private System.Windows.Forms.ListBox listBoxAppliedLeaves;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonRequestLeave;
        private System.Windows.Forms.Button buttonDeleteLeave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDaysOrHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDaysOrHoursValue;
        private System.Windows.Forms.Label labelLeaveType;
        private System.Windows.Forms.Label labelLeaveStatus;
        private System.Windows.Forms.Button buttonRefresh;
    }
}