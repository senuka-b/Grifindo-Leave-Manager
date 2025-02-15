using Grifindo_Leave_Manager.db;
using Grifindo_Leave_Manager.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Leave_Manager.controller {
    internal class RoasterController {
        public bool assignRoaster(User user, Roaster roaster) {
            (bool _, List<Dictionary<string, object>> result) = DBUtil.GetInstance().Execute(
                "SELECT * FROM Roasters WHERE EmployeeID = @EmployeeID",
                user.UserID
                
             );

            if (result.Count != 0) {
                (bool isUpdated, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                    "UPDATE Roasters SET StartDateTime = @Start, EndDateTime = @End WHERE EmployeeID = @EmployeeID",
                    roaster.StartTime, roaster.EndTime, user.UserID
                    
                  );

                return isUpdated;
            }

            (bool isAdded, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                "INSERT INTO Roasters (EmployeeID, StartDateTime, EndDateTime) VALUES (@EmpID, @Start, @End)",
                user.UserID, roaster.StartTime, roaster .EndTime
             );

            return isAdded; 
        }

        public Roaster getRoaster(User user) {
            (bool _, List<Dictionary<string, object>> result) = DBUtil.GetInstance().Execute(
                "SELECT * FROM Roasters WHERE EmployeeID = @EmployeeID",
                user.UserID
                
             );

            if (result.Count != 0) {
                return new Roaster(user, (DateTime)result[0]["StartDateTime"], (DateTime)result[0]["EndDateTime"]);
            }

            return null;
        }
    }
}
