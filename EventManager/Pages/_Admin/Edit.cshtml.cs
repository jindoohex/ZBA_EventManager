using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManagerLib.model;
using EventManager.Services.EventServices;
using Microsoft.AspNetCore.Authorization;

namespace EventManager.Pages._Admin
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private IEventService _eventService;

        public EditModel(IEventService eventService)
        {
            _eventService = eventService;

        }


        [BindProperty]
        public Event Event { get; set; }

        


        public String ErrorMessage { get; private set; }
       



        public void OnGet(int id)
        {
            ErrorMessage = "";
            try
            {
                Event = _eventService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"An Event with id={id} Does not Exist";
            }

        }

        public IActionResult OnPost(int id)
        {
            Event.EventID = id;
            

            _eventService.Edit(Event);
            return RedirectToPage("/_Event/Index");
        }
    }
}
