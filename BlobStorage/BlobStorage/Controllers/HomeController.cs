using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlobStorage.Models;
using Microsoft.AspNetCore.Http;


namespace BlobStorage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Mofidy the action method to upload new files
        /// a new container is added everyday to keep the files
        /// The path of the newly added file todaysDate/unique-id/filename, for example "18-12-2018/b944d993-3ac7-419f-9427-537016b7e9e0/myfile.doc"
        /// use GUID to generate a new unique-id
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ActionResult> Upload(IFormFile file)
        {
        
            //add you code here
       
            return RedirectToAction("Index");
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
