using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Services.EventServices;
using EventManagerLib.model;

namespace EventManager.Pages._Admin
{
    public class DeleteModel : PageModel
    {
        private IEventService _eventService;

        public DeleteModel(IEventService eventService)
        {
            _eventService = eventService;
        }


        [BindProperty]
        public Event Event { get; set; }


        public void OnGet(int id)

        {
            Event = _eventService.GetById(id);

        }

        public IActionResult OnPost(int id)
        {
            Event deletedEvent = _eventService.DeleteEvent(id);

            return RedirectToPage("Index");
        }


    }
}
