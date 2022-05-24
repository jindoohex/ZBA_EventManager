using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerLib.model
{
    public class Event
    {
        public enum SpecificEventType { MusicTent, Tribune, Lounge }

        private int _eventId;
        private DateTime _date;
        private TimeSpan _timeFrom;
        private TimeSpan _timeTo;
        private int _locationId;
        private string _eventName;
        private string _eventDesc;
        private SpecificEventType _eventType;


        public Event()
        {

        }

        public Event(int eventId, DateTime date, TimeSpan timeFrom, TimeSpan timeTo, int locationId, string eventName, string eventDesc, SpecificEventType eventType)
        {
            _eventId = eventId;
            _date = date;
            _timeFrom = timeFrom;
            _timeTo = timeTo;
            _locationId = locationId;
            _eventName = eventName;
            _eventDesc = eventDesc;
            _eventType = eventType;
        }

        public int EventID
        {
            get => _eventId;
            set => _eventId = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public TimeSpan TimeFrom
        {
            get => _timeFrom;
            set => _timeFrom = value;
        }

        public TimeSpan TimeTo
        {
            get => _timeTo;
            set => _timeTo = value;
        }

        public int LocationID
        {
            get => _locationId;
            set => _locationId = value;
        }

        public string EventName
        {
            get => _eventName;
            set => _eventName = value;
        }

        public string EventDesc
        {
            get => _eventDesc;
            set => _eventDesc = value;
        }

        public SpecificEventType EventType
        {
            get => _eventType;
            set => _eventType = value;
        }

        public override string ToString()
        {
            return $"{nameof(EventID)}: {EventID}, {nameof(Date)}: {Date}, {nameof(TimeFrom)}: {TimeFrom}, {nameof(TimeTo)}: {TimeTo}, {nameof(LocationID)}: {LocationID}, {nameof(EventName)}: {EventName}, {nameof(EventDesc)}: {EventDesc}, {nameof(EventType)}: {EventType}";
        }
    }
}
