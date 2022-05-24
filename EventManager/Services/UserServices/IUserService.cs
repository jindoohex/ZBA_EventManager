using EventManagerLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Services
{
    public interface IUserService
    {
        //User GetUserById(int id);

        User Create(User newUser);
        User ModifyUser(User modifiedUser);
        List<User> GetAllUsers();

        User GetUserById(int id);

        public User GetUserByName(int userId);

        List<Event> GetAllEvents();
        User GetUserByName(string name);
    }
}
