using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

            //Add results action method 
            //Method takes two parameters
            //In order for the parameters to be properly passed in by the MVC Framework, they need to be named appropriately
            // based on the corresponding form field names
        public IActionResult Results(string searchType, string searchTerm)
        {            

           
            ViewBag.jobs = JobData.FindByValue(searchTerm);
            ViewBag.searchTerm = searchTerm;

            //pass ListController.columnChoicess to the view
            ViewBag.columns = ListController.columnChoices;

            // passing the search results into Views/Search/Index.cshtml
            return View("Index");

        }
    }
}
