using System;
using Microsoft.AspNetCore.Mvc;
using SportsEvents.Services.Interfaces;
using SportsEvents.Web.Models.EventModels;

namespace SportsEvents.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        private EventController()
        {
        }

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
           // ..return new JsonResult(_eventService.GetAllEvents());
            return View();
        }

        public IActionResult GetAll()
        {
            return new JsonResult(_eventService.GetAllEvents());
        }

        [HttpPost]
        public IActionResult GetEventsByCityAndProvince(SearchModel search)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var results = _eventService.GetEventsByLocale(search.ProvinceId ?? 0, search.CityId ?? 0);
                return new JsonResult(results);

            }
            catch (Exception ex)
            {
                return null;
            }
     
        }
    }
}
