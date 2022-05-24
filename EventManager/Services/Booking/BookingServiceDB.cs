using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services.Booking
{
    public class BookingServiceDB : IBookingService
    {
        private const string connectionString = @"Data Source=zbaeventmanagerserver.database.windows.net;Initial Catalog=ZBA_EventManager_DB;User ID=agj1234;Password=Kage1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UserBooking Create(UserBooking newUserBooking)
        {
            string sql = "insert into UserBooking (Capacity, UserID, VIP, EventID) values (@Capacity, @UserID, @VIP, @EventID);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Capacity", newUserBooking.Capacity);
                cmd.Parameters.AddWithValue("@UserID", newUserBooking.UserId);
                cmd.Parameters.AddWithValue("@VIP", newUserBooking.Vip);
                cmd.Parameters.AddWithValue("@EventID", newUserBooking.EventId);


                // Always with insert, update and delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Throw an exeception
                }

                newUserBooking.BookingId = FindBookingId(connection);

                return newUserBooking;
            }
        }

        private int FindBookingId(SqlConnection con)
        {
            string sql = "select MAX(BookingID) from UserBooking";

            SqlCommand cmd = new SqlCommand(sql, con);

            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return 0;
        }


        public UserBooking GetById(int BookingId)
        {
            String Sql = "select * from UserBooking where BookingId=@BookingId";

            //lav forbindelse
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //åben forb.
                connection.Open();

                // Ny SQL query
                SqlCommand cmd = new SqlCommand(Sql, connection);
                // indsæt værdi'erne
                cmd.Parameters.AddWithValue("@BookingId", BookingId);

                //altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                // læs alle rækker
                while (reader.Read())
                {
                    UserBooking userBooking = ReadUserBooking(reader);
                    return userBooking;
                }
            }

            return null;
        }

        public UserBooking Delete(int bookingId)
        {
            // throw new NotImplementedException();
            UserBooking deletedUserBooking = GetById(bookingId);

            String sql = "delete from UserBooking where BookingId=@BookingId";

            // lav forbindelse 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // åben
                connection.Open();

                // Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // vælg værdierne
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                // altid ved insert, update og delete!!
                int rows = cmd.ExecuteNonQuery();

                if(rows !=1)
                {
                    //fail
                }
            }

            return deletedUserBooking;
        }

        public List<UserBooking> GetAllBookings()
        {
            //throw new NotImplementedException();

            List<UserBooking> userBookingList = new List<UserBooking>();
            string Sql = "select * from [dbo].[UserBooking]";

            //Connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // åben forbindelse
                connection.Open();

                // lav Query
                SqlCommand cmd = new SqlCommand(Sql, connection);

                // ved select:
                SqlDataReader reader = cmd.ExecuteReader();

                // Læs alle rækker
                while (reader.Read())
                {
                    UserBooking theUserBooking = ReadUserBooking(reader);
                    userBookingList.Add(theUserBooking);
                }
            }

            return userBookingList;
        }


        private UserBooking ReadUserBooking(SqlDataReader reader)
        {
            UserBooking theUserBookig = new UserBooking();

            theUserBookig.BookingId = reader.GetInt32(0);
            theUserBookig.Capacity = reader.GetInt32(1);
            theUserBookig.UserId = reader.GetInt32(2);
            theUserBookig.Vip = reader.GetBoolean(3);
            theUserBookig.EventId = reader.GetInt32(4);

            return theUserBookig;
        }

    }
}
