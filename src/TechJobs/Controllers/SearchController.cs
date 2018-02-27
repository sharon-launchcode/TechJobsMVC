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







        static private List<string> Searches = new List<string>();
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
            //will enable query parameters with these names searchType searchTerm
        {
            //pass data to the view


            if (string.IsNullOrEmpty(searchType))
            {
                searchType = "SEARCHTYPE NEEDED";
            }
            if (string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = "SEARCHTERM NEEDED";
            }
            return Content(string.Format("searchType is {0}", searchType,
                "searchTerm is {1}", searchTerm), "text/html");
           // Searches.Contains(searchType, searchTerm);

            //display the data


            ViewBag.searches = Searches;

            return View();
        }


    }
}
