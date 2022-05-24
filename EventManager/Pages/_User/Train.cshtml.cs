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
    public class TrainModel : PageModel
    {
        private TrainService _trainService;

        [BindProperty]
        public List<Train> Trains { get; private set; }

        public TrainModel(TrainService TrainService)
        {
            _trainService = TrainService;
        }

        public void OnGet()
        {
            Trains = _trainService.GetAll();
        }
    }
}
