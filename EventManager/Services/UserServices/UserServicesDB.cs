using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services
{
    public class UserServicesDB : IUserService
    {
        private const string connectionString = @"Data Source=zbaeventmanagerserver.database.windows.net;Initial Catalog=ZBA_EventManager_DB;User ID=agj1234;Password=Kage1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<User> Users { get; set; }

        public User GetUserByName(int userId)
        {
            return Users.Find(user => user.UserId == userId);
        }

        public User Create(User newUser)
        {
            string sql = "insert into [dbo].[User] (FirstName, LastName, Phone, Email, Password, UserRole) VALUES(@FirstName, @LastName, @Phone, @Email, @Password, 1);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@Phone", newUser.Phone);
                cmd.Parameters.AddWithValue("@Email", newUser.Email);
                cmd.Parameters.AddWithValue("@Password", newUser.Password);
                cmd.Parameters.AddWithValue("@UserRole", newUser.UserState);

                // Always with insert, update and delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // Throw an exeception
                }

                return newUser;
            }
        }


        private User ReadUser(SqlDataReader reader)
        {
            User theUser = new User();

            theUser.UserId = reader.GetInt32(0);
            theUser.FirstName = reader.GetString(1);
            theUser.LastName = reader.GetString(2);
            theUser.Phone = reader.GetString(3);
            theUser.Email = reader.GetString(4);
            theUser.Password = reader.GetString(5);
            theUser.UserState = (User.UserStateType)reader.GetInt32(6);

            return theUser;
        }

        private Event ReadEvent(SqlDataReader reader)
        {
            Event theEvent = new Event();

            theEvent.EventID = reader.GetInt32(0);
            theEvent.LocationID = reader.GetInt32(1);
            theEvent.EventName = reader.GetString(2);
            theEvent.EventDesc = reader.GetString(3);

            return theEvent;
        }


        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            string sql = "Select * from [dbo].[User]";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Always for 'select' queries
                SqlDataReader reader = cmd.ExecuteReader();

                // Read all rows
                while (reader.Read())
                {
                    User theUser = ReadUser(reader);
                    userList.Add(theUser);
                }
            }
            return userList;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> eventList = new List<Event>();
            string sql = "Select * from Event";

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // Create SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Always for 'select' queries
                SqlDataReader reader = cmd.ExecuteReader();

                // Read all rows
                while (reader.Read())
                {
                    Event theEvent = ReadEvent(reader);
                    eventList.Add(theEvent);
                }
            }
            return eventList;
        }

        public User GetUserById(int id)
        {
            string sql = "Select * from [dbo].[User]  where UserID=@UserID";

            User theUser = new User();

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Opens connection
                connection.Open();

                // Creates SQL Query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // Insert the values
                cmd.Parameters.AddWithValue("@UserID", id);

                // Always with 'select'
                SqlDataReader reader = cmd.ExecuteReader();

                // Reads all rows
                while (reader.Read())
                {
                    theUser = ReadUser(reader);
                }

                return theUser;
            }
            
            
        }

        public User ModifyUser(User modifiedUser)
        {
            String sql = "UPDATE [dbo].[User] SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email WHERE UserID=@UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@UserID", modifiedUser.UserId);
                cmd.Parameters.AddWithValue("@FirstName", modifiedUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", modifiedUser.LastName);
                cmd.Parameters.AddWithValue("@Phone", modifiedUser.Phone);
                cmd.Parameters.AddWithValue("@Email", modifiedUser.Email);


                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {

                    throw new ArgumentException();
                }

                return modifiedUser;
            }

        }

        public User GetUserByName(string name)
        {
            //r/*eturn Users.Find(user => user.UserName);*/
            return null;
        }
    }
}