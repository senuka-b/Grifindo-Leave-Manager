using Grifindo_Leave_Manager.db;
using Grifindo_Leave_Manager.model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Leave_Manager.controller {
    internal class LeaveController {
        public List<Leave> getLeaves(User user) {
            (bool _, List<Dictionary<string, object>> result) = DBUtil.GetInstance().Execute(
                "SELECT * FROM LeaveApplications WHERE EmployeeID = @EmployeeID ",
                user.UserID
                
             );            

            if (result.Count != 0) {
                
                List<Leave> leaves = new List<Leave>();

                foreach (var value in result) {
                    leaves.Add(
                        new Leave(
                            user,
                            (int) value["LeaveApplicationID"],
                            value["LeaveType"].ToString(),
                            (DateTime)value["StartDateTime"],
                            (DateTime)value["EndDateTime"],
                            value["Status"].ToString()

                         )    
                    );
                }

                return leaves;
            }

            return null;
        }

        private bool validateLeaves(string type, User user, TimeSpan timeSpan) {

            switch (type) {
                case "short":
                    return user.Shortleaves != 0;

                case "annual":
                    
                    return user.AnnualLeaves >= timeSpan.Days;

                case "casual":
                    return user.CasualLeaves >= timeSpan.Days;

            }

            return false;
        }

        public int addLeave(User user, Leave leave) {
            // 0 -> unable to add leave
            // 1 -> succesfully added leave
            // 2 -> short leave range invalid
            // 3 -> annual leave invalid range

            string leaveType = null;
            bool isEmployeeValueDecremented = false;
            TimeSpan timeSpan = leave.EndTime - leave.StartTime;

            if (leave.Type.Equals("Short Leaves")) {
                leaveType = "short";

                if (timeSpan > new TimeSpan(1, 30, 0)) {
                    return 2;
                }

                if (validateLeaves(leaveType, user, timeSpan)) {
                    

                    (bool ok, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                        "UPDATE Employees SET ShortLeaves = ShortLeaves - @Short WHERE EmployeeID = @EmpID",
                        1,
                        user.UserID
                     );

                    Console.WriteLine("YES");

                    isEmployeeValueDecremented = ok;

                   
                }

            } else if (leave.Type.Equals("Annual Leaves")) {

                leaveType = "annual"; 

                if (validateLeaves(leaveType, user, timeSpan)) {

                    Roaster roaster = new RoasterController().getRoaster(user);

                    if (leave.StartTime > roaster?.StartTime.AddDays(7) || timeSpan.Days == 0) {
                        return 3;
                    }

                    (bool ok, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                        "UPDATE Employees SET AnnualLeaves = AnnualLeaves - @Annual WHERE EmployeeID = @EmpID",
                        timeSpan.Days,
                        user.UserID
                     );


                    isEmployeeValueDecremented = ok;

                } 

            } else {
                leaveType = "casual";

                if (validateLeaves(leaveType, user, timeSpan)) {

                    Roaster roaster = new RoasterController().getRoaster(user);

                    if (leave.StartTime > roaster.StartTime.AddDays(7) || timeSpan.Days == 0) {
                        return 3;
                    }

                    (bool ok, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                        "UPDATE Employees SET CasualLeaves = CasualLeaves - @Casual WHERE EmployeeID = @EmpID",
                        timeSpan.Days,
                        user.UserID
                     );


                    isEmployeeValueDecremented = ok;

                } else return 3;
                }
                
            if (isEmployeeValueDecremented ) {

                (bool isLeaveApplicationAdded, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                    "INSERT INTO LeaveApplications (EmployeeID, LeaveType, StartDateTime, EndDateTime, Status) " +
                    "VALUES (@EmpID, @LeaveType, @Start, @End, @Status)",
                    user.UserID,
                    leaveType,
                    leave.StartTime,
                    leave.EndTime,
                    leave.Status

                 );

                return isLeaveApplicationAdded ? 1 : 0;
            }




            return  0;
        }

        public bool deleteLeave(Leave leave) {
            (bool isDeleted, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                "DELETE FROM LeaveApplications WHERE LeaveApplicationID = @LeaveID",
                leave.LeaveID
             );

            // TODO: Restore leave counts in employee.
            
            return isDeleted;
        }

        public bool updateLeave(Leave leave, bool approve) {
            (bool isApproved, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                "UPDATE LeaveApplications SET Status = @Status WHERE LeaveApplicationID = @LeaveID",
                approve ? "approved" : "rejected",
                leave.LeaveID
             );

            return isApproved;  
        }
    }
}
