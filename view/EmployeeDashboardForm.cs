using Grifindo_Leave_Manager.controller;
using Grifindo_Leave_Manager.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Leave_Manager.view {
    public partial class EmployeeDashboardForm : Form {

        private User user;

        private UserController employeeController = new UserController();
        private RoasterController roasterController = new RoasterController();
        private LeaveController leaveController = new LeaveController();    

        public EmployeeDashboardForm(User user) {
            InitializeComponent();


            //this.user = employeeController.searchEmployee("senuka"); // TESTING

            this.user = employeeController.searchEmployee(user.Username);
            labelUsername.Text = this.user.Fullname;

            populateComboBoxEmployee();
            loadLeaves();
        }

        private void populateComboBoxEmployee() {
            comboBoxEmployeeRooster.DataSource = null;
            comboBoxEmployeeRooster.Items.Clear();

            LeaveType[] leaveTypes = LeaveType.getLeaveTypes(user.AnnualLeaves, user.CasualLeaves, user.Shortleaves);

            comboBoxEmployeeRooster.DataSource = leaveTypes;

        }

        private void loadLeaves() {
            listBoxAppliedLeaves.DataSource = null;
            listBoxAppliedLeaves.Items.Clear();

            List<Leave> leaves = leaveController.getLeaves(this.user);

            if (leaves != null) {

                listBoxAppliedLeaves.DataSource = leaves;
            } else {
                listBoxAppliedLeaves.Items.Add("No items here yet...");
            }


        }

        private void comboBoxEmployeeRooster_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void buttonRequestLeave_Click(object sender, EventArgs e) {

            int addedLeaveStatus = leaveController.addLeave(user,
                    new Leave(
                            user,
                            ((LeaveType) comboBoxEmployeeRooster.SelectedItem).LeaveTypeName,
                            dateTimePickerRoasterStart.Value,
                            dateTimePickerRoasterEnd.Value,
                            "pending"
                        )

                ) ;
            
            switch ( addedLeaveStatus ) {
                case 0:
                    MessageBox.Show("Unable to add leave ! Insufficient days balance.");
                    break;

                case 1:
                    MessageBox.Show("Succesfully added leave ! ");
                    populateComboBoxEmployee();
                    loadLeaves();

                    break;

                case 2:
                    MessageBox.Show("Short leave range invalid ! ");
                    break;

                case 3:
                    MessageBox.Show("Annual leave range invalid ! \n Make sure you apply atleast 7 days before your roaster.");
                    break;
            }

        }

        private void buttonDeleteLeave_Click(object sender, EventArgs e) {
            if (listBoxAppliedLeaves.SelectedItem?.ToString() == "No items here yet...") return;


            if (leaveController.deleteLeave((Leave) listBoxAppliedLeaves.SelectedItem)) {
                MessageBox.Show("Succesfully Deleted Leave !");
                loadLeaves();

                return;
            }

            MessageBox.Show("Failed to delete leave !");
        }

        private void listBoxAppliedLeaves_SelectedIndexChanged(object sender, EventArgs e) {

            if (listBoxAppliedLeaves.SelectedItem == null) return;


            if (listBoxAppliedLeaves.SelectedItem?.ToString() == "No items here yet...") return;
            
            Leave selectedLeave = (Leave)listBoxAppliedLeaves.SelectedItem;

            
            if (selectedLeave.Type.Equals("short")) {
                labelDaysOrHours.Text = "Number of hours : ";
                labelDaysOrHoursValue.Text = selectedLeave.getShortString();

            } else {
                labelDaysOrHours.Text = "Number of days : ";
                labelDaysOrHoursValue.Text = selectedLeave.getDays() + " days";

            }

            labelLeaveType.Text = selectedLeave.Type;
            labelLeaveStatus.Text = selectedLeave.Status;


        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            loadLeaves();
        }
    }
}
