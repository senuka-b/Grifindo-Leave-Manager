using Grifindo_Leave_Manager.controller;
using Grifindo_Leave_Manager.db;
using Grifindo_Leave_Manager.model;
using Grifindo_Leave_Manager.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Leave_Manager {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e) {

            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (username.Equals("") || password.Equals("")) {
                MessageBox.Show("Please enter both the username and the password!");

                return;
            }

            User user = new UserController().login(username, password);
            if (user != null) {
                this.Hide();

                MessageBox.Show($"Welcome aboard {user.Fullname}!");

                if (user.Role == "admin") {
                    new AdminDashboardForm(user).Show();
                } else {
                    new EmployeeDashboardForm(user).Show();
                }
            } else {
                MessageBox.Show("Invalid credentials! Please try again");
            }

        }
    }
}
