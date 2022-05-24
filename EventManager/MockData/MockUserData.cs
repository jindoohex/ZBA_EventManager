using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagerLib.model;

namespace EventManager.MockData
{
    public class MockUserData
    {

        private static List<User> listedUsers = new List<User>()
        {
            new User(1001, "KlaskerKlaus", "Klokkeværk", "09090909", "eafuihbea@mailting.com", "dyknedimig", User.UserStateType.Admin),
            new User(1002, "SjaskeLone", "Tunnellen", "09090910", "eafuihfjii@mailting.com", "klipdenderged", User.UserStateType.RegUser)
        };

        public static List<User> GetUsers()
        {
            return listedUsers;
        }
    }
}
