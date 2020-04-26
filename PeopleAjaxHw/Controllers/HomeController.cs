using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleAjaxHw.Models;

namespace PeopleAjaxHw.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult People()
        {
            return View();
        }

    }
}
