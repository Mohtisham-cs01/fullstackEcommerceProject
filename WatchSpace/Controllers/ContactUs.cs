//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WatchSpace.Controllers
//{
//    public class ContactUs : Controller
//    {
//        public IActionResult SaveMessage()
//        {
//            return View();
//        }
//    }
//}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WatchSpace.Data;
using WatchSpace.Models;

namespace WatchSpace.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                _context.ContactUs.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index" , "Home");
            }

            return RedirectToAction("Index", "Home");
        }


    }
}
