﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPPIC.Public.Web.Controllers
{
    public class CasesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
