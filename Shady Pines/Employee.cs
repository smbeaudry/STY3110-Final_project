using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace Shady_Pines
{
    [DataObject(true)]
    public class Employee
    {
        public int _EmployeeID { get; set; }
        public int _PermissionID { get; set; }
        public string _EmployeeFName { get; set; }
        public string _EmployeeLName { get; set; }
        public string _EmployeeAddress { get; set; }
        public string _EmployeeCity { get; set; }
        public string _EmployeeCountry { get; set; }
        public string _EmployeeState { get; set; }
        public string _EmployeeZip { get; set; }
        public string _EmployeePhone { get; set; }
        public DateTime _EmployeeDOB { get; set; }

        // Selects all Employees from our Employee table. Orders by Last Name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllEmployees";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee myEmployee = new Employee();
                    myEmployee._EmployeeID = (int)dr["EmployeeID"];
                    myEmployee._PermissionID = (int)dr["PermissionID"];
                    myEmployee._EmployeeFName = (string)dr["First Name"];
                    myEmployee._EmployeeLName = (string)dr["Last Name"];
                    myEmployee._EmployeeAddress = (string)dr["Street Address"];
                    myEmployee._EmployeeCountry = (string)dr["Country"];
                    myEmployee._EmployeeState = (string)dr["Province/State"];
                    myEmployee._EmployeeCity = (string)dr["City"];
                    myEmployee._EmployeePhone = (string)dr["Phone"];
                    myEmployee._EmployeeZip = (string)dr["Postal Code/Zip"];
					myEmployee._EmployeeDOB = (datetime)dr["Employee Date of Birth"];
                    employees.Add(myEmployee);

                }
                conn.Close();
            }
            catch (SqlException myEx)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            finally
            {
            }
            return Employees;
        }

        // Inserts a Employee into our Employees table
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertEmployee(Employee myEmployee)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@_EmployeeID", myEmployee._EmployeeID);
            cmd.Parameters.AddWithValue("@_PermissionID", myEmployee._PermissionID);
            cmd.Parameters.AddWithValue("@_EmployeeFName", myEmployee._EmployeeFName);
            cmd.Parameters.AddWithValue("@_EmployeeLNAme", myEmployee._EmployeeLName);
            cmd.Parameters.AddWithValue("@_EmployeeAddress", myEmployee._EmployeeAddress);
            cmd.Parameters.AddWithValue("@_EmployeeCountry", myEmployee._EmployeeCountry);
            cmd.Parameters.AddWithValue("@_EmployeeState", myEmployee._EmployeeState);
            cmd.Parameters.AddWithValue("@_EmployeeCity", myEmployee._EmployeeCity);
            cmd.Parameters.AddWithValue("@_EmployeePhone", myEmployee._EmployeePhone);
            cmd.Parameters.AddWithValue("@_EmployeeZip", myEmployee._EmployeeZip);
			cmd.Parameters.AddWithValue("@_EmployeeDOB", myEmployee._EmployeeDOB);

            try
            {
                conn.Open();
            }
            catch (SqlException myEx)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            finally
            {
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }

        //Deletes a Employee from the Employees Table
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteEmployee(Employee myEmployee)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteEmployee";

            cmd.Parameters.AddWithValue("EmployeeID", myEmployee._EmployeeID);

            conn.Open();
            int delete = cmd.ExecuteNonQuery();
            try
            {
                //conn.Open();
            }
            catch (SqlException myEx)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            finally
            {
            }
            conn.Close();
            return delete;
        }

        //Updates Employee Information
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateEmployee(Employee original_myEmployee, Employee myEmployee)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";

            cmd.Parameters.AddWithValue("original_EmployeeID", original_myEmployee._EmployeeID);
            cmd.Parameters.AddWithValue("PermissionID", myEmployee._PermissionID);
            cmd.Parameters.AddWithValue("First Name", myEmployee._EmployeeFName);
            cmd.Parameters.AddWithValue("Last Name", myEmployee._EmployeeLName);
            cmd.Parameters.AddWithValue("Street Address", myEmployee._EmployeeAddress);
            cmd.Parameters.AddWithValue("Country", myEmployee._EmployeeCountry);
            cmd.Parameters.AddWithValue("Province/State", myEmployee._EmployeeState);
            cmd.Parameters.AddWithValue("City", myEmployee._EmployeeCity);
            cmd.Parameters.AddWithValue("Postal Code/Zip", myEmployee._EmployeeZip);
            cmd.Parameters.AddWithValue("Phone", myEmployee._EmployeePhone);
			cmd.Parameters.AddWithValue("Date of Birth", myEmployee._EmployeeDOB);

            int i = -1;


            try
            {
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException myEx)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            finally
            {

            }
            return i;
        }

        private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ShadyPinesDB"].ConnectionString;
        }
    }
}