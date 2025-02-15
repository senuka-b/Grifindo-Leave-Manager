using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Leave_Manager.model {
    internal class Leave {
        private int leaveID;
        private User user;
        private string type;
        private DateTime startTime;
        private DateTime endTime;
        private string status;

        public User User { get => user; set => user = value; }
        public string Type { get => type; set => type = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public string Status { get => status; set => status = value; }
        public int LeaveID { get => leaveID; set => leaveID = value; }

        public Leave(User user, string type, DateTime startTime, DateTime endTime, string status) {
            this.user = user;
            this.type = type; 
            this.startTime = startTime;
            this.endTime = endTime;
            this.status = status;
        }

        public Leave(User user, int leaveID, string type, DateTime startTime, DateTime endTime, string status) {
            this.user = user;
            this.leaveID = leaveID;
            this.type = type;
            this.startTime = startTime;
            this.endTime = endTime;
            this.status = status;
        }



        public override string ToString() {
            return $"[{this.type}] - {(Type.Equals("short") ? getShortString() : getDays() + " days")} | {getFormattedStatus()}";
        }

        public string getFormattedStatus() {
            switch (status) {
                case "approved":
                    return "Approved ✅";
                case "pending":
                    return "Pending ⌚";
                case "rejected":
                    return "Rejected ❌";
            }

            return null;
        }

        public int getDays() {
            TimeSpan timeSpan = endTime - startTime;

            return timeSpan.Days;
        }

        public int getHours() {
            TimeSpan timeSpan = endTime - startTime;

            return timeSpan.Hours;
        }

        public int getMinutes() {
            TimeSpan timeSpan = endTime - startTime;

            return timeSpan.Minutes;
        }

        public string getShortString() { 
            int hours = getHours();
            int minutes = getMinutes();

            return hours + " hours " + minutes + " minutes.";
        }
    }
}
