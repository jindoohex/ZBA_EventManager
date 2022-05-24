using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services;
using EventManagerLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManager.Pages._User
{
    public class ProfileModel : PageModel
    {

        private IUserService _userService;

        private static List<User> _userList;

        public List<User> Users { get; private set; }

        [BindProperty]
        public User LoggedInUser { get; set; }


        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {

            // By using the input below, we make sure that IndexModel which is bound to 'Layout' gets called with a proper ID.
            // If 'GetUserById' had not been used, we would need to logout and back in to see changes made to the profile.
            // And by doing as below, we make sure it updates properly on page shift and such.
            LoggedInUser = _userService.GetUserById(_Login.IndexModel.LoggedInUser.UserId);

            //LoggedInUser = _Login.IndexModel.LoggedInUser;

            _userList = _userService.GetAllUsers();
            Users = new List<User>(_userList);

        }

        public IActionResult OnPost(int id)
        {
            LoggedInUser.UserId = id;

            _userService.ModifyUser(LoggedInUser);
            return RedirectToPage("/_User/Profile");
        }
    }
}
