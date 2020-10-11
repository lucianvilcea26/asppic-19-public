using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ASPPIC.Public.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITutorialGroupService  _tutorialGroupService;

        public HomeController(ITutorialGroupService tutorialGroupService)
        {
            _tutorialGroupService = tutorialGroupService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _tutorialGroupService.Get();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }        

        public async Task<IActionResult> CategoryDetails(Guid id)
        {
            var result = await _tutorialGroupService.Get(id);
            return View(result);
        }
    }
}
