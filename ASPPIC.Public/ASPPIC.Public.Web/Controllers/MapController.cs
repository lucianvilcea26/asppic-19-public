using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ASPPIC.Public.Web.Controllers
{
    [EnableCors()]
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
