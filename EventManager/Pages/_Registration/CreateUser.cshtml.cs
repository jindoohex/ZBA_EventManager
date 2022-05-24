using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Data;
using EventManager.Services;
using EventManagerLib.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Pages._Login;

namespace EventManager.Pages._Registration
{
    [AllowAnonymous]
    public class CreateUserModel : PageModel
    {
        private IUserService _userService;

        [BindProperty]
        public User Users { get; set; }

        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Users = _userService.Create(Users);
            return RedirectToPage();
        }
    }
}
