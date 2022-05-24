using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManager.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Services.EventServices;
using EventManagerLib.model;

namespace EventManager.Pages._Admin
{
    public class CreateModel : PageModel
    {
        private IEventService _eventService;
        

        [BindProperty]
        public Event Events { get; set; }
        public string MessageValidation { get; set; }


        public CreateModel(IEventService eventService)
        {
            _eventService = eventService;

            
        }

        public void OnGet()
        {
            MessageValidation = "";
        }

        //public void OnPost()
        //{
        //    Events = _eventService.CreateEvent(Events);
        //    if (Events != null)
        //    {
        //        MessageValidation = "The event has been created ";
        //    }
        //}

        public void OnPost()
        {
            Events = _eventService.CreateEvent(Events);
            if (Events != null)
            {
                MessageValidation = "The event has been created ";
            }

        }
    }
}
