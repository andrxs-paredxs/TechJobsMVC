﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"employer", "Employer"},
            {"location", "Location"},
            {"positionType", "Position Type"},
            {"coreCompetency", "Skill"}
        };

        private bool ctrl = false;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        // POST: /<controller>/index
        //[HttpPost]
        //[Route("results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null || searchType.ToLower().Equals("all"))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ColumnChoices[searchType] + ": " + searchTerm;
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;

            //return View();
            return View("Index");
        }
    }
}
