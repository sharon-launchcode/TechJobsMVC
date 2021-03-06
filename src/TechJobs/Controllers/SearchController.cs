﻿using System;
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
                //return View("~/Views/Search/Index.cshtml");
            }
            else
            {
                ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //return View("~/Views/Search/Index.cshtml");
            }

            return View("Index");
            //March 6 2018 incorporating Victor's recommendation

        }

    }
}
