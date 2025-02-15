using Grifindo_Leave_Manager.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Grifindo_Leave_Manager.controller;
using Grifindo_Leave_Manager.model;

namespace Grifindo_Leave_Manager.view {
    public partial class AdminDashboardForm : Form {

        private UserController employeeController = new UserController();
        private LeaveController leaveController = new LeaveController();
        private RoasterController roasterController = new RoasterController();

        private User user;
        public AdminDashboardForm(User user) {
            InitializeComponent();


            this.user = user;
            labelUsername.Text = user.Fullname; 

            mainTabControl.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            populateEmployeeComboBox();

        }

        private void AdminDashboardForm_Load(object sender, EventArgs e) {
            
        }

        private void populateEmployeeComboBox() {
            comboBoxEmployee.Items.Clear();
            comboBoxEmployeeRooster.Items.Clear();

            (bool _, List<Dictionary<string, object>> employees) = DBUtil.GetInstance().Execute(
                    "SELECT UserID, Username FROM Users WHERE role = @role",
                    "employee"
                );

            foreach (var emp in employees) {
                comboBoxEmployee.Items.Add(""+emp["UserID"] + " | " + (string)emp["Username"]);
                comboBoxEmployeeRooster.Items.Add(""+emp["UserID"] + " | " + (string)emp["Username"]);
            }

        }


        // This method paints the text in the tab control widget.h
        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e) {
            Graphics g = e.Graphics;
            Brush _textBrush;

            TabPage _tabPage = mainTabControl.TabPages[e.Index];

            Rectangle _tabBounds = mainTabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected) {

                _textBrush = new SolidBrush(Color.Coral);
                g.FillRectangle(Brushes.Black, e.Bounds);
            } else {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Arial", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            if (validateTextFields("employee")) {

                string fullName = textBoxFullName.Text.Trim();
                string username = textBoxUsername.Text.Trim();
                string password = textBoxPassword.Text.Trim();

                User user = new User(
                    -1,
                    username,
                    password,
                    fullName,
                    "employee",
                    decimal.ToInt32(numericAnnualLeave.Value),
                    decimal.ToInt32(numericCasualLeave.Value),
                    decimal.ToInt32(numericShortLeave.Value)
                 );


                if (employeeController.AddEmployee(user)) {

                    MessageBox.Show("Added employee succesfully!");

                    clearTextFields("employee");
                } else {

                    MessageBox.Show("Unable to add employee");
                }


            } else {
                MessageBox.Show("Please enter all the required fields!");
            }
        }

        private TextBox[] getTextBoxArray(string type) {
            TextBox[] textBoxes = null;

            switch (type) {
                case "employee":
                    textBoxes = new TextBox[] { textBoxFullName, textBoxPassword, textBoxUsername };
                    break;

                
            }

            return textBoxes;

        }

        private bool validateTextFields(string type) {
            TextBox[] textBoxes = getTextBoxArray(type);

            foreach (TextBox box in textBoxes) {
                if (box.Text.Trim().Length == 0) {
                    return false;
                }
            }

            return true;

        }

        private void clearTextFields(string type) {
            TextBox[] textBoxes = getTextBoxArray(type);

            foreach (TextBox box in textBoxes) {
                box.Text = null;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            if (textBoxSearch.Text.Trim().Length == 0 && textBoxUsername.Text.Trim().Length == 0) {
                MessageBox.Show("Please search for a user first!");
                return;

            }

            bool isDeleted = employeeController.deleteEmployee(textBoxUsername.Text.Trim());

            if (isDeleted) {
                MessageBox.Show("Successfully deleted user!");

                clearTextFields("employee");
                return;
            }

            MessageBox.Show("Unable to delete user!");


        }

        private void buttonSearch_Click(object sender, EventArgs e) {
            string searchQuery = textBoxSearch.Text.Trim();

            if (searchQuery.Length == 0) {
                MessageBox.Show("Please enter a search query!");
                return;
            }

            User user = employeeController.searchEmployee(searchQuery);

            if (user == null) {
                MessageBox.Show("No result found!");
                return;
            }


            textBoxUsername.Text = user.Username;
            textBoxPassword.Text = user.Password;
            textBoxFullName.Text = user.Fullname;

            numericAnnualLeave.Value = user.AnnualLeaves;
            numericCasualLeave.Value = user.CasualLeaves;
            numericShortLeave.Value = user.Shortleaves;

            MessageBox.Show("Result found!");


        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            if (textBoxSearch.Text.Trim().Length == 0 && textBoxUsername.Text.Trim().Length == 0) {
                MessageBox.Show("Please search for a user first!");
                return;

            }

            bool isUpdated = employeeController.updateEmployee(
                    new User(
                        employeeController.searchEmployee(textBoxSearch.Text).UserID, // User ID
                        textBoxUsername.Text, textBoxPassword.Text, textBoxFullName.Text, "employee",
                        decimal.ToInt32(numericAnnualLeave.Value),
                        decimal.ToInt32(numericCasualLeave.Value),
                        decimal.ToInt32(numericShortLeave.Value)

                    )
                
                );

            if (isUpdated) {
                MessageBox.Show("User updated successfully!");
                return;
            }

            MessageBox.Show("Unable to update user!");


        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e) {
                loadAppliedLeaves();

        }

        private void loadAppliedLeaves() {


            if (comboBoxEmployee.SelectedItem.ToString().Trim().Equals("") || comboBoxEmployee.SelectedItem == null) return;

            listBoxAppliedLeaves.DataSource = null;
            listBoxAppliedLeaves.Items.Clear();

            string selectedUserName = comboBoxEmployee.SelectedItem.ToString().Split('|')[1].Trim();


            User employee = employeeController.searchEmployee(selectedUserName);
            List<Leave> leaves = leaveController.getLeaves(employee);

            if (leaves == null) {
                listBoxAppliedLeaves.Items.Add("No items here yet...");
                return;
            }

            listBoxAppliedLeaves.DataSource = leaves;
        }
            
        private void buttonRefresh_Click(object sender, EventArgs e) {
            populateEmployeeComboBox();
        }

        private void buttonApproveLeave_Click(object sender, EventArgs e) {
            Leave selectedLeave = (Leave)listBoxAppliedLeaves.SelectedItem;

            if (selectedLeave == null) return;

            if (leaveController.updateLeave(selectedLeave, true)) {
                MessageBox.Show($"Leave {selectedLeave.LeaveID} approved !");
                loadAppliedLeaves();
                return;
            }

            MessageBox.Show("Unable to update leave!");
        }

        private void buttonRejectLeave_Click(object sender, EventArgs e) {
            Leave selectedLeave = (Leave)listBoxAppliedLeaves.SelectedItem;

            if (selectedLeave == null) return;

            if (leaveController.updateLeave(selectedLeave, false)) {
                MessageBox.Show($"Leave {selectedLeave.LeaveID} rejected !");
                loadAppliedLeaves();
                return;
            }

            MessageBox.Show("Unable to update leave!");


        }

        private void buttonRefreshRooster_Click(object sender, EventArgs e) {
            populateEmployeeComboBox();
        }

        private void buttonAssignRoaster_Click(object sender, EventArgs e) {
            if (comboBoxEmployeeRooster.SelectedItem.ToString().Trim().Equals("")) return;
            
            DateTime start = dateTimePickerRoasterStart.Value;
            DateTime end = dateTimePickerRoasterEnd.Value;

            string selectedUserName = comboBoxEmployeeRooster.SelectedItem.ToString().Split('|')[1].Trim();
            User employee = employeeController.searchEmployee(selectedUserName);

            bool isAssigned = roasterController.assignRoaster(employee, new Roaster(
                employee,
                start,
                end
            ));

            if (isAssigned) {
                MessageBox.Show("Assigned roaster successfully!");
            } else {
                MessageBox.Show("Unable to assign roaster!");
            }
        }

        private void comboBoxEmployeeRooster_SelectedIndexChanged(object sender, EventArgs e) {

            string selectedUserName = comboBoxEmployeeRooster.SelectedItem.ToString().Split('|')[1].Trim();
            User employee = employeeController.searchEmployee(selectedUserName);

            Roaster roaster = roasterController.getRoaster(employee);

            if (roaster != null) {

                dateTimePickerRoasterStart.Value = roaster.StartTime;
                dateTimePickerRoasterEnd.Value = roaster.EndTime;
            }
        }

        private void listBoxAppliedLeaves_SelectedIndexChanged(object sender, EventArgs e) {
            Leave selectedLeave = (Leave) listBoxAppliedLeaves.SelectedItem;

            if (selectedLeave == null) return;

            labelLeaveStatus.Text = selectedLeave.Status;
        }

        public string generateReport() {
            StringBuilder report = new StringBuilder();

            string queryUsers = @"
            SELECT U.UserID, U.Username, U.FullName, U.Role, 
                   E.AnnualLeaves, E.CasualLeaves, E.ShortLeaves, E.IsOnLeave
            FROM Users U
            LEFT JOIN Employees E ON U.UserID = E.EmployeeID";

            var (successUsers, users) = DBUtil.GetInstance().Execute(queryUsers);

            if (successUsers && users.Count > 0) {
                report.AppendLine("===== Employee Details =====");
                foreach (var row in users) {
                    report.AppendLine($"ID: {row["UserID"]}, Username: {row["Username"]}");
                    report.AppendLine($"Name: {row["FullName"]}, Role: {row["Role"]}");
                    report.AppendLine($"Annual Leaves: {row["AnnualLeaves"]}, Casual Leaves: {row["CasualLeaves"]}, Short Leaves: {row["ShortLeaves"]}");
                    report.AppendLine("----------------------------------------");
                }
            }

            string queryLeaves = @"
            SELECT LA.LeaveApplicationID, U.Username, LA.LeaveType, LA.StartDateTime, LA.EndDateTime, LA.Status
            FROM LeaveApplications LA
            INNER JOIN Employees E ON LA.EmployeeID = E.EmployeeID
            INNER JOIN Users U ON E.EmployeeID = U.UserID
            ORDER BY LA.StartDateTime DESC";

            var (successLeaves, leaves) = DBUtil.GetInstance().Execute(queryLeaves);

            if (successLeaves && leaves.Count > 0) {
                report.AppendLine("\n===== Leave Applications =====");
                foreach (var row in leaves) {
                    report.AppendLine($"ID: {row["LeaveApplicationID"]}, Employee: {row["Username"]}");
                    report.AppendLine($"Leave Type: {row["LeaveType"]}");
                    report.AppendLine($"From: {(DateTime)(row["StartDateTime"])}");
                    report.AppendLine($"To: {(DateTime)(row["EndDateTime"])}");
                    report.AppendLine($"Status: {row["Status"]}");
                    report.AppendLine("----------------------------------------");
                }
            }

            string queryRoasters = @"
            SELECT R.RoasterID, U.Username, R.StartDateTime, R.EndDateTime
            FROM Roasters R
            INNER JOIN Employees E ON R.EmployeeID = E.EmployeeID
            INNER JOIN Users U ON E.EmployeeID = U.UserID
            ORDER BY R.StartDateTime DESC";

            var (successRoasters, roasters) = DBUtil.GetInstance().Execute(queryRoasters);

            if (successRoasters && roasters.Count > 0) {
                report.AppendLine("\n===== Work Roasters =====");
                foreach (var row in roasters) {
                    report.AppendLine($"ID: {row["RoasterID"]}, Employee: {row["Username"]}");
                    report.AppendLine($"Shift Start: {(DateTime)(row["StartDateTime"])}");
                    report.AppendLine($"Shift End: {(DateTime)(row["EndDateTime"])}");
                    report.AppendLine("----------------------------------------");
                }
            }

            return report.ToString();
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e) {
            reportRichTextBox.Text = generateReport();
        }
    }
}
