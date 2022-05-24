using EventManager.MockData;
using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly List<Event> _events;
        //private static int nextId = 0;

        public EventService()
        {
            _events = MockEventData.GetEvents();
        }
        public Event BookingEvent(Event bookingEvent)
        {
            throw new NotImplementedException();
        }

        public Event DeleteEvent(int id)
        {
            Event deletedEv = GetById(id);
            _events.Remove(deletedEv);

            return deletedEv;
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Event CreateEvent(Event newEvent)
        {

            //newEvent.EventId = nextId++;
            _events.Add(newEvent);

            return newEvent;
        }


        public Event Edit(Event editedEvent)
        {
            throw new NotImplementedException();
        }

    }
}



