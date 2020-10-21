using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Data.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace ASPPIC.Public.Web.Controllers
{
    public class CasesController : Controller
    {
        private readonly ICountyService _countyService;

        public CasesController(ICountyService countyService)
        {
            _countyService = countyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _countyService.GetDashboardInfo();
            return View(result);
        }
    }
}
