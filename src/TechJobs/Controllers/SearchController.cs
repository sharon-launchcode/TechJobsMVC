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
        static SearchController()
        {

            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }
        /// </summary>

        public IActionResult Index()
        {
            // ViewBag.columns = ListController.columnChoices;
            ViewBag.columns = SearchController.columnChoices;
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







            if (searchType == "skill")
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View();
            }

            if (searchType == "employer")
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View();
            }

            if (searchType == "location")
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View();
            }

            if (searchType == "position type")
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View();
            }
            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View();
            }

            if (string.IsNullOrEmpty(searchType))
            {
                searchType = "SEARCHTYPE NEEDED";
            }


            if (string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = "SEARCHTERM NEEDED";
            }
            return Content(string.Format("searchType is {0} and searchTerm is {1}", searchType, searchTerm), "text/html");
 
        }

        /// <summary>
        /// 



        public IActionResult Values(string column)
        //Notice that the Values Action is NOT in the Search Views and is not kicked out
        {
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Results");
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
        /// </summary>
    }
}
