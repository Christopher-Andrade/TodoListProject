using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsEvents.Services.Interfaces;
using SportsEvents.Web.Models.RegionModels;

namespace SportsEvents.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public IActionResult GetAllProvinces()
        {
            return new JsonResult(_regionService.GetAllProvinces());
        }


        [HttpGet]
        public IActionResult GetAllCities()
        {
            return new JsonResult(_regionService.GetAllCities());

        }

        [HttpGet]
        public IActionResult GetCitiesByProvince(int provinceId)
        {
            return new JsonResult(_regionService.GetCitiesByProvince(provinceId));
        }

    }
}
