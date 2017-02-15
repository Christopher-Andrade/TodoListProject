using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Services.Interfaces;
using ToDoList.Web.Models.EventModels;

namespace ToDoList.Controllers
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
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var results = _eventService.GetEventsByLocale(search.ProvinceId ?? 0, search.CityId ?? 0);
            return new JsonResult(results);
        }
    }
}
