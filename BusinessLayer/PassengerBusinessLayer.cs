using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    class PassengerBusinessLayer
    {
        public IAsyncEnumerable<Passenger> Passengers
        {
            get
            {
                string connectionString = "Data Source=.;Initial Catalog=mydb;Integrated Security=True";
                List<Passenger> passengers = new List<Passenger>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllPassengers",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Passenger passenger = new Passenger();
                        passenger.name = dr["Full_Name"].ToString();
                        passenger.city = dr["From_City"].ToString();
                        passenger.singleConfig = dr["Single_lady"].ToString();
                        passenger.date = dr["From_Date"].ToString();
                        passenger.ticketNumbers = Convert.ToInt32(dr["Number_of_Tickets"]);
                        passenger.mobileNumber = dr["Mobile_Number"].ToString();
                        passenger.address = dr["Address"].ToString();
                        passenger.toCity = dr["Full_Name"].ToString();
                        passenger.roundTrip = dr["Round_Trip"].ToString();
                        passenger.toDate = dr["To_Date"].ToString();
                        passenger.insuranceOpt = dr["Insurance_Opt"].ToString();
                        passenger.email = dr["Email"].ToString();
                        passengers.Add(passenger);
                    }
                }
                return Passengers;
            }
        }

        public void AddPassenger (Passenger passenger)
        {
            string connectionString = "Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertPassengerDetails",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Full_Name",passenger.name);
                cmd.Parameters.AddWithValue("@From_City", passenger.city);
                cmd.Parameters.AddWithValue("@Single_Lady", passenger.singleConfig);
                cmd.Parameters.AddWithValue("@From_Date", passenger.date);
                cmd.Parameters.AddWithValue("@Number_of_Tickets", passenger.ticketNumbers);
                cmd.Parameters.AddWithValue("@Mobile_Number", passenger.mobileNumber);
                cmd.Parameters.AddWithValue("@Address", passenger.address);
                cmd.Parameters.AddWithValue("@To_City", passenger.city);
                cmd.Parameters.AddWithValue("@Round_Trip", passenger.roundTrip);
                cmd.Parameters.AddWithValue("@To_Date", passenger.toDate);
                cmd.Parameters.AddWithValue("@Insurance_Opt", passenger.insuranceOpt);
                cmd.Parameters.AddWithValue("@Email", passenger.email);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePassengers (Passenger passenger)
        {
            string connectionString = "Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdatePassengerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Full_Name", passenger.name);
                cmd.Parameters.AddWithValue("@From_City", passenger.city);
                cmd.Parameters.AddWithValue("@Single_Lady", passenger.singleConfig);
                cmd.Parameters.AddWithValue("@From_Date", passenger.date);
                cmd.Parameters.AddWithValue("@Number_of_Tickets", passenger.ticketNumbers);
                cmd.Parameters.AddWithValue("@Mobile_Number", passenger.mobileNumber);
                cmd.Parameters.AddWithValue("@Address", passenger.address);
                cmd.Parameters.AddWithValue("@To_City", passenger.city);
                cmd.Parameters.AddWithValue("@Round_Trip", passenger.roundTrip);
                cmd.Parameters.AddWithValue("@To_Date", passenger.toDate);
                cmd.Parameters.AddWithValue("@Insurance_Opt", passenger.insuranceOpt);
                cmd.Parameters.AddWithValue("@Email", passenger.email);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePassengers(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spDeletePassengerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PassengerId",id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
