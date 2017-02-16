using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using ToDoList.Web.Models.EventModels;

namespace ToDoList.Web.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchModel search)
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
