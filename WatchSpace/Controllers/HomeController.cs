using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WatchSpace.Data;
using WatchSpace.Models;

namespace WatchSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            List<Product> productList = await _context.Product.OrderByDescending(p => p.Id).Take(6).ToListAsync();
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }


        public IActionResult contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ContactUs(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                var Contact = new ContactUs
                {
                    Name = contact.Name,
                    Number = contact.Number,
                    Email = contact.Email,
                    Message = contact.Message,
                    Date = DateTime.Now
                };

                _context.Add(Contact);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View("contact", "Home");
        }

        public IActionResult testimonials()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PayNow(int TotalBill)
        {
            return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=zainasghar000@gmail.com&item_name=WatchSpace&return=https://localhost:44311/Products/ProductList&amount=" + TotalBill);
            //return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=zeeshan.arshad@pugc.edu.pk&item_name=TheWayShopProducts&amount=" + TotalAmount);
        }
    }
}
