using EventManager.MockData;
using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services
{
    public class TrainService
    {
        private List<Train> _trains;

        public TrainService()
        {
            _trains = MockTrainData.GetMockTrains();
        }

        public List<Train> GetAll()
        {
            return _trains;
        }
    }
}
