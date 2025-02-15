using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Leave_Manager.model {
    internal class LeaveType {
        private string leaveTypeName;
        private int remaining;

        public string LeaveTypeName {  get { return leaveTypeName; } set {  leaveTypeName = value; } }
        public int Remaining { get { return remaining; } set { remaining = value; } }

        public LeaveType(string leaveTypeName, int remaining) { 
            this.leaveTypeName = leaveTypeName;
            this.remaining = remaining;
        }

        public override string ToString() { 
            return $"{leaveTypeName} - ({remaining} remaining)";
        }

        public static LeaveType[] getLeaveTypes(int annual, int casual, int _short) {
            return new LeaveType[] { 
                new LeaveType("Annual Leaves", annual),
                new LeaveType("Casual Leaves", casual),
                new LeaveType("Short Leaves", _short),
            };
        }
    }
}
