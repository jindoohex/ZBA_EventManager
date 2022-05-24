using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.MockData
{
    public class MockTrainData
    {
        private static List<Train> Trains = new List<Train>()
        {
            new Train("9:00 from KBH", "Train to Roskilde sp: 7", "10:00 Roskilde st. sp: 7", "Walk 6 min to Roskilde st hospital", "10:11", "Bus 212 to Hastrup", "10:25 Zealand"),
            new Train("9:20 from KBH", "Train to Roskilde sp: 7", "10:20 Roskilde st. sp: 6", "Walk 6 min to Roskilde st hospital", "10:35", "Bus 202A to Musicon", "11:00 Zealand"),
            new Train("8:00 from KBH", "Train to Roskilde sp: 6", "8:45 Roskilde st. sp: 6", "Walk 6 min to Roskilde st hospital", "9:15", "Bus 212 to Hastrup", "9:30 Zealand"),
            new Train("10:00 from KBH", "Train to Roskilde sp: 7", "10:45 Roskilde st. sp: 7", "Walk 6 min to Roskilde st hospital", "11:00", "Bus 202A to Musicon", "11:20 Zealand"),
            new Train("10:30 from KBH", "Train to Roskilde sp: 7", "11:15 Roskilde st. sp: 7", "Walk 6 min to Roskilde st hospital", "11:25", "Bus 202A to Musicon", "11:40 Zealand"),

            new Train("16:30 from Zealand", "Bus 202A mod Roskilde st", "16:45 Roskilde st hospital", "walk 6 min to Roskilde st", "17:00", "Train to KBH sp: 7", "17:45 KBH"),
            new Train("17:00 from Zealand", "Bus 202A mod Roskilde st", "17:15 Roskilde st hospital", "walk 6 min to Roskilde st", "17:30", "Train to KBH sp: 7", "18:15 KBH"),
            new Train("18:00 from Zealand", "Bus 202A mod Roskilde st", "18:15 Roskilde st hospital", "walk 6 min to Roskilde st", "18:30", "Train to KBH sp: 6", "19:15 KBH"),
            new Train("19:00 from Zealand", "Bus 202A mod Roskilde st", "19:15 Roskilde st hospital", "walk 6 min to Roskilde st", "19:30", "Train to KBH sp: 7", "20:15 KBH"),
            new Train("20:00 from Zealand", "Bus 202A mod Roskilde st", "20:15 Roskilde st hospital", "walk 6 min to Roskilde st", "20:30", "Train to KBH sp: 7", "21:15 KBH"),
        };

        public static List<Train> GetMockTrains()
        {
            return Trains;
        }
    }
}
