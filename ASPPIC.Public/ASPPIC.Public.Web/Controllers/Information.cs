using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPPIC.Public.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPPIC.Public.Web.Controllers
{
    public class InformationController : Controller
    {
        private readonly ITutorialGroupService _tutorialGroupService;
        private readonly ITutorialService _tutorialService;

        public InformationController(ITutorialGroupService tutorialGroupService, ITutorialService tutorialService)
        {
            _tutorialGroupService = tutorialGroupService;
            _tutorialService = tutorialService;
        }

        public async Task<IActionResult> Category(Guid id)
        {
            var result = await _tutorialGroupService.Get(id);
            return View(result);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _tutorialService.GetById(id);
            return View(result);
        }
    }
}
