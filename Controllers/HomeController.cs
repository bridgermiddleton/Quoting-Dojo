using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult AddQuotePage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddQuote(Quote yourQuote)
        {
            if(ModelState.IsValid)
            {
            string query = $"INSERT INTO Quote (Name, TheQuote, created_at, updated_at) VALUES ('{yourQuote.Name}','{yourQuote.TheQuote}',NOW(),NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("AllTheQuotesPage");  
            }
            return View("AddQuotePage");

            
        }
        [HttpGet("quotes")]
        public IActionResult AllTheQuotesPage()
        {
            List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM Quote");
            ViewBag.ListofQuotes = AllQuotes;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
