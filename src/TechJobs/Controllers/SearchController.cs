using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {

        /// <summary>
  
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
 
        /// </summary>

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
           // ViewBag.columns = SearchController.columnChoices;
           // ViewBag.columns = columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        

        public IActionResult Results(string searchType, string searchTerm)
            //will enable query parameters with these names searchType searchTerm
        {
            //pass data to the view

            ViewBag.columns = ListController.columnChoices;

            if (searchType.Equals ("all"))
            {

                ViewBag.Jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All Jobs";
                return View("~/Views/Search/Index.cshtml");
            }
            else
            {
                ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                return View();
            }

            //return View();
 
        }
        public IActionResult Values(string column)
        {
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                List<string> items = JobData.FindAll(column);
                ViewBag.title = "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }
        public IActionResult Jobs(string column, string value)
        {
            List<Dictionary<String, System.String>> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
