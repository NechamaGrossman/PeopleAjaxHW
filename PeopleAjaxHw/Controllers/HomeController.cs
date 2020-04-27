using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleAjaxHw.Models;
using PeopleAjaxHw.Data;

namespace PeopleAjaxHw.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=People;Integrated Security=True";
        public IActionResult People()
        {
            PersonDb personDB = new PersonDb(_connectionString);
            List<Person> people = personDB.GetPeople();
            return Json(people);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditPerson(Person person )
        {
            PersonDb personDB = new PersonDb(_connectionString);
            personDB.EditPerson(person);
            return Json(person);
        }
        public IActionResult DeletePerson(int id)
        {
            PersonDb personDB = new PersonDb(_connectionString);
            personDB.DeletePerson(id);
            return Json(id);
        }

    }
}
