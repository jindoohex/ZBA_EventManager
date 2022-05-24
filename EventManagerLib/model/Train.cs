using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerLib.model
{
    public class Train
    {
        public string _departure;
        public string _description;
        public string _time;
        public string _walk;
        public string _time2;
        public string _description2;
        public string _arrival;

        public string Departure
        {
            get { return _departure; }
            set { _departure = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Walk
        {
            get { return _walk; }
            set { _walk = value; }
        }

        public string Time2
        {
            get { return _time2; }
            set { _time2 = value; }
        }

        public string Description2
        {
            get { return _description2; }
            set { _description2 = value; }
        }

        public string Arrival
        {
            get { return _arrival; }
            set { _arrival = value; }
        }

        public Train(string departure, string description, string time, string walk, string time2, string description2, string arrival)
        {
            _departure = departure;
            _description = description;
            _time = time;
            _walk = walk;
            _time2 = time2;
            _description2 = description2;
            _arrival = arrival;
        }

        

    }
}
