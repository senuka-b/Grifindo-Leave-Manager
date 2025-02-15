using Grifindo_Leave_Manager.db;
using Grifindo_Leave_Manager.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Leave_Manager.controller {
    internal class UserController {

        public bool AddEmployee(User employee) {

            SqlTransaction transaction = DBUtil.GetInstance().GetConnection().BeginTransaction();

            (bool isUserAdded, object _) = DBUtil.GetInstance().Execute(
                transaction,
                "INSERT INTO Users (Username, Password, Fullname, Role) VALUES (@Username, @Password, @Fullname, @Role)",
                employee.Username,
                employee.Password,
                employee.Fullname,
                employee.Role
             );

            if ( isUserAdded ) {

                (bool _, List<Dictionary<string, object>> results) = DBUtil.GetInstance().Execute(
                    transaction,
                    "SELECT (UserID) FROM Users WHERE Username = @Username AND Password = @Password",
                    employee.Username,
                    employee.Password
                );

                (bool isEmployeeAdded, object _) = DBUtil.GetInstance().Execute(
                    transaction,
                    "INSERT INTO Employees (EmployeeID, AnnualLeaves, CasualLeaves, ShortLeaves)" +
                    " VALUES (@UserID, @AnnualLeaves, @CasualLeaves, @ShortLeaves)",
                    results[0]["UserID"],
                    employee.AnnualLeaves,
                    employee.CasualLeaves,
                    employee.Shortleaves * 12 // for whole year
                );


                if (isEmployeeAdded) {
                    transaction.Commit();

                    return true;

                }
            }


            transaction.Rollback();
            return false;
        }


        public User searchEmployee(string searchQuery) {

            (bool _, List<Dictionary<string, object>> result) = DBUtil.GetInstance().Execute(
               "SELECT u.UserID, u.Username, u.Password, u.FullName, u.role, e.AnnualLeaves, e.CasualLeaves, e.ShortLeaves " +
               "FROM Employees e INNER JOIN Users u ON u.UserID = e.EmployeeID WHERE " +
               "u.username = @Username OR u.FullName LIKE '%' + @FullName + '%';",
               searchQuery,
               searchQuery

           );

            if (result.Count == 0) {
                return null;
            }


            return new User(
                (int) result[0]["UserID"],
                (string) result[0]["Username"],
                (string) result[0]["Password"],
                (string) result[0]["FullName"],
                (string) result[0]["role"],
                (int)result[0]["AnnualLeaves"],
                (int)result[0]["CasualLeaves"],
                (int)result[0]["ShortLeaves"] / 12 // per month

            );
        }

        public bool deleteEmployee(string username) {
            (bool isDeleted, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                "DELETE FROM Users WHERE Username = @Username",
                username
            );

            return isDeleted;

        }

        public bool updateEmployee(User user) {

            SqlTransaction transaction = DBUtil.GetInstance().GetConnection().BeginTransaction();

            (bool isUpdatedUser, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
               transaction,
               "UPDATE Users SET username = @Username, password = @Password, fullname = @FullName WHERE userID = @UserID",
               user.Username,
               user.Password,
               user.Fullname,
               user.UserID

            );

            Console.WriteLine(user.UserID + " " + user.Username);

            (bool isUpdatedEmployee, List<Dictionary<string, object>> _) = DBUtil.GetInstance().Execute(
                transaction,
                "UPDATE Employees SET AnnualLeaves = @AnnualLeaves, CasualLeaves = @CasualLeaves, ShortLeaves = @ShortLeaves WHERE EmployeeID = @UserID",
                user.AnnualLeaves,
                user.CasualLeaves,
                user.Shortleaves * 12,
                user.UserID

            );

            if (isUpdatedUser && isUpdatedEmployee) {
                transaction.Commit();

                return true;
            }



            return false;
        }

        public User login(string username, string password) {
            (bool _, List<Dictionary<string, object>> result) = DBUtil.GetInstance().Execute(
                "SELECT * FROM Users WHERE Username = @Username AND Password = @Password",
                username,
                password
             );

            if (result.Count > 0) {
                return new User(
                    (int)result[0]["UserID"],
                    (string)result[0]["Username"],
                    (string)result[0]["Password"],
                    (string)result[0]["FullName"],
                    (string)result[0]["Role"]
                );
            }

            return null;
        }
    }
}
