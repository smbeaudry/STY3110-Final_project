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
    public class Member
    {
        public int _MemberID { get; set; }
        public int _MemberStatusID { get; set; }
        public int _MembershipCategoryID { get; set; }
        public int _MembershipID { get; set; }
        public string _MemberFName { get; set; }
        public string _MemberLName { get; set; }
        public string _MemberAddress { get; set; }
        public string _MemberCity { get; set; }
        public string _MemberCountry { get; set; }
        public string _MemberState { get; set; }
        public string _MemberZip { get; set; }
        public string _MemberPhone { get; set; }
        public DateTime _MemberDateStarted { get; set; }

        // Selects all members from our Member table. Orders by Last Name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Member> getAllMembers()
        {
            List<Member> members = new List<Member>();
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllMembers";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Member myMember = new Member();
                    myMember._MemberID = (int)dr["MemberID"];
                    myMember._MemberStatusID = (int)dr["MemberStatusID"];
                    myMember._MembershipCategoryID = (int)dr["MembershipCategoryID"];
                    myMember._MembershipID = (int)dr["MembershipID"];
                    myMember._MemberFName = (string)dr["First Name"];
                    myMember._MemberLName = (string)dr["Last Name"];
                    myMember._MemberAddress = (string)dr["Street Address"];
                    myMember._MemberCountry = (string)dr["Country"];
                    myMember._MemberState = (string)dr["Province/State"];
                    myMember._MemberCity = (string)dr["City"];
                    myMember._MemberPhone = (string)dr["Phone"];
                    myMember._MemberZip = (string)dr["Postal Code/Zip"];
                    members.Add(myMember);

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
            return members;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Member> GetMemberByID(int MemberID)
        {
            List<Member> members = new List<Member>();

            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMemberByID";
                cmd.Parameters.AddWithValue("@_MemberID", MemberID);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    

                    while (dr.Read())
                    {

                        Member myMember = new Member();
                        myMember._MemberID = (int)dr["MemberID"];
                        myMember._MemberStatusID = (int)dr["MemberStatusID"];
                        myMember._MembershipCategoryID = (int)dr["MembershipCategoryID"];
                        myMember._MembershipID = (int)dr["MembershipID"];
                        myMember._MemberFName = (string)dr["First Name"];
                        myMember._MemberLName = (string)dr["Last Name"];
                        myMember._MemberAddress = (string)dr["Street Address"];
                        myMember._MemberCountry = (string)dr["Country"];
                        myMember._MemberState = (string)dr["Province/State"];
                        myMember._MemberCity = (string)dr["City"];
                        myMember._MemberPhone = (string)dr["Phone"];
                        myMember._MemberZip = (string)dr["Postal Code/Zip"];
                        members.Add(myMember);

                        
                    }
                    dr.Close();
                    return members;
                }
                catch (InvalidCastException e)
                {
                    conn.Close();
                    throw e;

                }
            }
        }

        // Inserts a Member into our Members table
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertMember(Member myMember)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertMember";

            cmd.Parameters.AddWithValue("@_MemberID", myMember._MemberID);
            cmd.Parameters.AddWithValue("@_MemberStatusID", myMember._MemberStatusID);
            cmd.Parameters.AddWithValue("@_MembershipCategoryID", myMember._MembershipCategoryID);
            cmd.Parameters.AddWithValue("@_MembershipID", myMember._MembershipID);
            cmd.Parameters.AddWithValue("@_MemberFName", myMember._MemberFName);
            cmd.Parameters.AddWithValue("@_MemberLNAme", myMember._MemberLName);
            cmd.Parameters.AddWithValue("@_MemberAddress", myMember._MemberAddress);
            cmd.Parameters.AddWithValue("@_MemberCountry", myMember._MemberCountry);
            cmd.Parameters.AddWithValue("@_MemberState", myMember._MemberState);
            cmd.Parameters.AddWithValue("@_MemberCity", myMember._MemberCity);
            cmd.Parameters.AddWithValue("@_MemberPhone", myMember._MemberPhone);
            cmd.Parameters.AddWithValue("@_MemberZip", myMember._MemberZip);

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

        //Deletes a Member from the Members Table
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteMember(Member myMember)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteMember";

            cmd.Parameters.AddWithValue("MemberID", myMember._MemberID);

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

        //Updates Member Information
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateMember(Member original_myMember, Member myMember)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateMember";

            cmd.Parameters.AddWithValue("original_MemberID", original_myMember._MemberID);
            cmd.Parameters.AddWithValue("MemberStatusID", myMember._MemberStatusID);
            cmd.Parameters.AddWithValue("MembershipCategoryID", myMember._MembershipCategoryID);
            cmd.Parameters.AddWithValue("MembershipID", myMember._MembershipID);
            cmd.Parameters.AddWithValue("First Name", myMember._MemberFName);
            cmd.Parameters.AddWithValue("Last Name", myMember._MemberLName);
            cmd.Parameters.AddWithValue("Street Address", myMember._MemberAddress);
            cmd.Parameters.AddWithValue("Country", myMember._MemberCountry);
            cmd.Parameters.AddWithValue("Province/State", myMember._MemberState);
            cmd.Parameters.AddWithValue("City", myMember._MemberCity);
            cmd.Parameters.AddWithValue("Postal Code/Zip", myMember._MemberZip);
            cmd.Parameters.AddWithValue("Phone", myMember._MemberPhone);

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