using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagerLib.model;

namespace EventManager.MockData
{
    public class MockEventData
    {

        private static List<Event> listedEvent = new List<Event>()
        {
            //new Event(1, "1", "1", 1, "Snøvsen", "Den gådefulde mini-narkoman."),
            //new Event(2, "2", "2", 2, "Klapsko", "31284907312847328479832749823743.")
        };

        public static List<Event> GetEvents()
        {
            return listedEvent;
        }
    }
}
