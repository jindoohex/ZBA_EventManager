using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EventManager.Services;
using EventManagerLib.model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManager.Pages._Login
{
    public class IndexModel : PageModel
    {
        public static User LoggedInUser { get; set; } = null;

        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            List<User> users = _userService.GetAllUsers();

            foreach (User user in users)
            {
                if (Username == user.Email && Password == user.Password)
                {
                    LoggedInUser = user;

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username),
                        new Claim(ClaimTypes.Role, user.UserState.ToString())

                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    if (user.UserState == EventManagerLib.model.User.UserStateType.Admin)
                    {
                        return RedirectToPage("/_Admin/Index");
                    }

                    return RedirectToPage("/_User/Index");

                }
            }
            

            Message = "Invalid attempt, check the input.";
            return Page();
        }
    }
}
