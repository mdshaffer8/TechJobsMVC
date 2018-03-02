using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController() 
        {
            
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }

        //displays the different types of lists that the user can view
        public IActionResult Index()
        {
            ViewBag.columns = columnChoices;
            return View();
        }

        //in the Values action, the controller uses the query parameter passed in as column to determine which values to fetch from JobData.
        public IActionResult Values(string column)
        {
            //will fetch all job data then render the Jobs.cshtml view template rather than the default view
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title =  "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            //fetches only the values for the given column and passes them to the Values.cshtml view template (default)
            else
            {
                List<string> items = JobData.FindAll(column);
                ViewBag.title =  "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        //in the Jobs action, we take in two query parameters: column and value. We are searching for a particular value within a particular column and displaying jobs that match.
        public IActionResult Jobs(string column, string value)
        {
            List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
