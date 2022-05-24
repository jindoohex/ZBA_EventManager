using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services.EventServices
{
    public class EventServiceDB : IEventService
    {
        private const string connectionString = @"Data Source=zbaeventmanagerserver.database.windows.net;Initial Catalog=ZBA_EventManager_DB;User ID=agj1234;Password=Kage1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private Event ReadEvent(SqlDataReader reader)
        {
            Event events = new Event();

            events.EventID = reader.GetInt32(0);
            events.Date = reader.GetDateTime(1);
            events.TimeFrom = reader.GetTimeSpan(2);
            events.TimeTo = reader.GetTimeSpan(3);
            events.LocationID = reader.GetInt32(4);
            events.EventName = reader.GetString(5);
            events.EventDesc = reader.GetString(6);
            events.EventType = Enum.Parse<Event.SpecificEventType>(reader.GetString(7));

            return events;
        }

        

        public Event DeleteEvent(int id)
        {
            Event deletedEv = GetById(id);
            

            String sql = "delete from Event where EventID=@ID";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();


                SqlCommand cmd = new SqlCommand(sql, connection);


                cmd.Parameters.AddWithValue("@ID", id);



                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Not deleted");
                }

                return deletedEv;
            }
        }

        public Event GetById(int id)
        {
            String sql = "select * from Event where EventID=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();


                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Id", id);


                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Event Ev = ReadEvent(reader);
                    return Ev;
                }
            }
            return null;
        }

        List<Event> IEventService.GetEvents()
        {
            List<Event> liste = new List<Event>();
            String sql = "select * from Event";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // altid ved select
                SqlDataReader reader = cmd.ExecuteReader();

                // læser alle rækker
                while (reader.Read())
                {
                    Event ev = ReadEvent(reader);
                    liste.Add(ev);
                }
            }

            return liste;
        }

        public Event CreateEvent(Event newEvent)
        {

            String sql = "INSERT INTO [Event] (Date, TimeFrom, TimeTo, LocationID, EventName, EventDesc, EventType) VALUES (@Date, @TimeFrom, @TimeTo, @LocationID, @EventName, @EventDesc, @EventType);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Date", newEvent.Date);
                cmd.Parameters.AddWithValue("@TimeFrom", newEvent.TimeFrom);
                cmd.Parameters.AddWithValue("@TimeTo", newEvent.TimeTo);
                cmd.Parameters.AddWithValue("@LocationID", newEvent.LocationID);
                cmd.Parameters.AddWithValue("@EventName", newEvent.EventName);
                cmd.Parameters.AddWithValue("@EventDesc", newEvent.EventDesc);
                cmd.Parameters.AddWithValue("@EventType", newEvent.EventType);

                // Altid når indsætter
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Not Created");
                }
                return newEvent;
            }
        }

        public Event Edit(Event editedEvent)
        {
            String sql = "update Event set Date=@Date, EventDesc=@EventDesc, TimeFrom=@TimeFrom, TimeTo=@TimeTo, LocationID=@LocationID, EventName=@EventName, EventType=@EventType " +
                         "WHERE EventID=@EventID";

            // opret forbindelse
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // åbner forbindelsen
                connection.Open();

                // opretter sql query
                SqlCommand cmd = new SqlCommand(sql, connection);

                // indsæt værdierne
                cmd.Parameters.AddWithValue("@EventID", editedEvent.EventID);
                cmd.Parameters.AddWithValue("@EventDesc", editedEvent.EventDesc);
                cmd.Parameters.AddWithValue("@Date", editedEvent.Date);
                cmd.Parameters.AddWithValue("@TimeFrom", editedEvent.TimeFrom);
                cmd.Parameters.AddWithValue("@TimeTo", editedEvent.TimeTo);
                cmd.Parameters.AddWithValue("@LocationID", editedEvent.LocationID);
                cmd.Parameters.AddWithValue("@EventName",editedEvent.EventName);
                cmd.Parameters.AddWithValue("@EventType", editedEvent.EventType);


                // altid ved Insert, update, delete
                int rows = cmd.ExecuteNonQuery();

                if (rows != 1)
                {
                    // fejl
                    throw new ArgumentException("Could not update Event with id = " + editedEvent.EventID);
                }

                return editedEvent;
            }
        }

    }
}