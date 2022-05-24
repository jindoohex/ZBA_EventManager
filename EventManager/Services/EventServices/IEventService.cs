using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services.EventServices
{
    public interface IEventService
    {
        List<Event> GetEvents();

        Event CreateEvent(Event newEvent);

        Event DeleteEvent(int id);

        Event GetById(int id);

        Event Edit(Event editedEvent);
        
    }
}
