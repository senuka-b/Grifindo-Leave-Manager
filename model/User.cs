using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Leave_Manager.model {
    public class User {
        private int userID;
        private string username;
        private string password;
        private string fullname;
        private string role;
        private int annualLeaves;
        private int casualLeaves;
        private int shortleaves;
        private object value;

        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Role { get => role; set => role = value; }
        public int AnnualLeaves { get => annualLeaves; set => annualLeaves = value; }
        public int CasualLeaves { get => casualLeaves; set => casualLeaves = value; }
        public int Shortleaves { get => shortleaves; set => shortleaves = value; }

        public User(int userID, string username, string password, string fullname, string role) {
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.Fullname = fullname;
            this.Role = role;
        }
       
        public User(int userID, string username,  string password, string fullname, string role, int annualLeaves, int casualLeaves, int shortLeaves) {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.role = role;
            this.annualLeaves = annualLeaves;
            this.casualLeaves = casualLeaves;
            this.shortleaves = shortLeaves;


        }

        public User(int userID, string username, string password, string fullname, string role, object value) : this(userID, username, password, fullname, role) {
            this.value = value;
        }
    }
}
