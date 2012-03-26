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
    public class Reservation
    {
        public int _ReservationID { get; set; }
        public int _MemberID { get; set; }
        public string _ReservationInfo { get; set; }
        public DateTime _ReservationDate { get; set; }

        // Selects all Reservations from our Reservation table. Orders by Last Name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Reservation> getAllReservations()
        {
            List<Reservation> Reservations = new List<Reservation>();
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllReservations";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Reservation myReservation = new Reservation();
                    myReservation._ReservationID = (int)dr["ReservationID"];
                    myReservation._MemberID = (int)dr["MemberID"];
                    myReservation._ReservationInfo = (string)dr["Reservation Details"];
					myReservation._ReservationDate = (datetime)dr["Reservation Date"];
                    Reservations.Add(myReservation);

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
            return Reservations;
        }

        // Inserts a Reservation into our Reservations table
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertReservation(Reservation myReservation)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertReservation";

            cmd.Parameters.AddWithValue("@_ReservationID", myReservation._ReservationID);
            cmd.Parameters.AddWithValue("@_MemberID", myReservation._MemberID);
            cmd.Parameters.AddWithValue("@_ReservationInfo", myReservation._ReservationInfo);
			cmd.Parameters.AddWithValue("@_ReservationDate", myReservation._ReservationDate);

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

        //Deletes a Reservation from the Reservations Table
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteReservation(Reservation myReservation)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteReservation";

            cmd.Parameters.AddWithValue("ReservationID", myReservation._ReservationID);

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

        //Updates Reservation Information
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateReservation(Reservation original_myReservation, Reservation myReservation)
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateReservation";

            cmd.Parameters.AddWithValue("original_ReservationID", original_myReservation._ReservationID);
            cmd.Parameters.AddWithValue("MemberID", myReservation._MemberID);
            cmd.Parameters.AddWithValue("Reservation Details", myReservation._ReservationInfo);
			cmd.Parameters.AddWithValue("Date of Reservation", myReservation._ReservationDate);

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