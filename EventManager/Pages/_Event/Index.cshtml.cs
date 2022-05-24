using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services;
using EventManager.Services.EventServices;
using EventManagerLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventManager.Pages._Event
{
    public class IndexModel : PageModel
    {
        private IEventService _eventService;
        


        [BindProperty]
        public List<Event> Events { get; set; }

        

        public IndexModel(IEventService eventService)
        {
            _eventService = eventService;
        }


        public void OnGet()
        {
            Events = _eventService.GetEvents();
        }


    }
}
