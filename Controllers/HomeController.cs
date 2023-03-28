using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartialViewModalPopup.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewModalPopup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PartialViewModalPopupDbContext _partialViewModalPopupDbContext;

        public HomeController(ILogger<HomeController> logger, PartialViewModalPopupDbContext partialViewModalPopupDbContext)
        {
            _logger = logger;
            _partialViewModalPopupDbContext = partialViewModalPopupDbContext;
        }

        public IActionResult Index()
        {
            List<Customer> customers = (from customer in this._partialViewModalPopupDbContext.Customers.Take(10)
                                        select customer).ToList();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Details(string customerId)
        {
            return PartialView("_Details", this._partialViewModalPopupDbContext.Customers.Find(customerId));
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
