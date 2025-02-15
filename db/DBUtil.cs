    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    namespace Grifindo_Leave_Manager.db {
        internal class DBUtil {

            private readonly string connectionString = "Data Source=Yeti-PC\\MSSQLSERVER01;Initial Catalog=Grifindo_Leave_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            private static DBUtil instance;
            private static SqlConnection connection;

            private DBUtil() { 
                connection = new SqlConnection(connectionString);
            }

            public static DBUtil GetInstance() {
                if (instance == null) {
                    instance = new DBUtil();
                }

                return instance;
            }

            public SqlConnection GetConnection() {

                if (connection.State == System.Data.ConnectionState.Closed) {
                    connection.Open();
                }

                return connection;
            }



            // Takes a query parameter and a vararg parameter of arguments, and executes it.
            // returns if the query was succesful and a data reader object if any

            public (bool, List<Dictionary<string, object>>) Execute(string query, params object[] arguments) {


                return this.Execute(null, query, arguments);
            
            }

            public (bool, List<Dictionary<string, object>>) Execute(SqlTransaction transaction = null, string query = "", params object[] arguments) {
                try {

                    if (connection.State == System.Data.ConnectionState.Closed) {
                        connection.Open();

                    }


                    SqlCommand command = transaction == null ? 
                        new SqlCommand(query, connection) :
                        new SqlCommand(query, connection, transaction);


                    MatchCollection parameterCollection = Regex.Matches(query, @"@\w+"); // regex for parameter matching

                    if (arguments.Length > 0 && parameterCollection.Count == arguments.Length) {
                        for (int i = 0; i < parameterCollection.Count; i++) {
                            command.Parameters.AddWithValue(parameterCollection[i].Value, arguments[i]);
                        }
                    }
                    List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();


                    if (query.Trim().ToUpper().StartsWith("SELECT")) {

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read()) {
                            var row = new Dictionary<string, object>();

                            for (int i = 0; i < reader.FieldCount; i++) {
                                row[reader.GetName(i)] = reader[i];
                            }

                            results.Add(row);
                        }

                        reader.Close();

                        return (true, results);
                    }

                    bool isExecuted = command.ExecuteNonQuery() > 0;

                    return (isExecuted, results);


                } catch (Exception e) {

                    if (transaction != null) {

                        transaction.Rollback();
                    }

                    throw e;

                } 


                //return (false, null); 
            }




        }
    }
