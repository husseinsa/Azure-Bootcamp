using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CosmoDBApp.Models;

namespace CosmoDBApp.Controllers
{
    public class HomeController : Controller
    {
        protected readonly Services.ItemsStore itemsStore;
        public HomeController(Services.ItemsStore itemsStore)
        {
            this.itemsStore = itemsStore;
        }
        public async Task<IActionResult> Index()
        {
            var model = await itemsStore.GetAllItems();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            var itemsData = Models.ItemsSampleData.GetItems();
            await itemsStore.InsertItems(itemsData);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
