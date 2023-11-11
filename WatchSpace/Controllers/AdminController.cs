using EmailService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WatchSpace.Data;
using WatchSpace.Helper;
using WatchSpace.Models;


namespace WatchSpace.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmailSender _emailSender;

        private readonly ApplicationDbContext _context;

        private readonly IHttpContextAccessor _accessor;
        public AdminController(IEmailSender emailSender, ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _emailSender = emailSender;
            _context = context;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                return View();
            }
            else
            {
                //return View("NotFound1");
                return RedirectToAction("NotFound1", "Admin");
            }
        }









        //public void CreateProducts()
        //{

        //    string[] imageLinks = new string[]
        //    {
        //    "https://m.media-amazon.com/images/I/71aWDnZOfLL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/61IX7x2YwZL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61D44N16zDL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61IX7x2YwZL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/81IDdwuGEqL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/61Cmk-sFNWL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61s1Na3W61L._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/51VG5cWFoCL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/71XMTLtZd5L._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/71HvekeiFkL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61CZSoSnVPL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/61Sl+xoVHoL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61NPQ+Y13dL._AC_UL320_.jpg",
        //    "https://m.media-amazon.com/images/I/216-OX9rBaL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/71LMRTyNpML._AC_UL320_.jpg",
        //    "https://m.media-amazon.com/images/I/216-OX9rBaL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/71E2txVRtRL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61aGd0sn-aL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/61WpiPLatCL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/61W7OPrcGOL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/51iEj3EyzdL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/71DP0v5VqhL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png",
        //    "https://m.media-amazon.com/images/I/71Yczdqk0NL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/71CvQVR+BAL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61im3OsaksL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/61XEjAmK7uL._AC_UY218_.jpg",
        //    "https://m.media-amazon.com/images/I/11hfR5Cq9GL._SS200_.png"
        //    };


        //    for (int i = 0; i <= 25; i++)
        //    {
        //        var product = new Product
        //        {
        //            Name = "Watch " + i.ToString(),
        //            Image = imageLinks[i],
        //            Description = "description" + i.ToString(),
        //            Quantity = 5,
        //            Orig_Price = 10,
        //            Display_Price = 20,
        //            CompanyId = 1
        //        };

        //        _context.Product.Add(product);
        //    }

        //    for (int i = 0; i <= 25; i++)
        //    {
        //        var product = new Product
        //        {
        //            Name = "smartWatch " + i.ToString(),
        //            Image = imageLinks[i],
        //            Description = "description for smartWatch" + i.ToString(),
        //            Quantity = 10,
        //            Orig_Price = 11,
        //            Display_Price = 21,
        //            CompanyId = 2
        //        };

        //        _context.Product.Add(product);
        //    }

        //    _context.SaveChanges();
        //}




        //public void CreateContactUsEntries()
        //{
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        var contactUs = new ContactUs
        //        {
        //            Name = "Name " + i.ToString(),
        //            Number = "030089678"+i.ToString() + i.ToString()+1,
        //            Email = "email" + i.ToString() + "@yopmail.com",
        //            Message = "Message " + i.ToString(),
        //            Date = DateTime.Now
        //        };

        //        _context.ContactUs.Add(contactUs);
        //    }

        //    _context.SaveChanges();
        //}





        [HttpPost]
        public IActionResult downloadReport(DateTime dateFrom , DateTime dateTo)
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {

                List<Models.Order> orderList = new List<Models.Order>();
                if (dateFrom < dateTo)
                {
                    orderList = _context.Order.Where(o => o.Date >= dateFrom && o.Date <= dateTo).ToList();
                }
                else
                {
                    orderList = _context.Order.ToList();
                }
                return View(orderList);

            }
            else
            {
                //return View("NotFound1");
                return RedirectToAction("NotFound1", "Admin");
            }

        }


        [HttpPost]
        public IActionResult searchStatus(OrderStatus status)
        {

            List<Order> orderList = new List<Order>();
            orderList = _context.Order.Where(o => o.Status == status).Include(x => x.User).Include(x => x.Product).ToList();
            ViewData["Status"] = (int)status;
            return View("ConfirmedOrderList",orderList);

        }



        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string referenceNumber, OrderStatus status)
        {
            bool IsEmailSended = false;
            List<Models.Order> orderList = new List<Models.Order>();
            orderList = _context.Order.ToList();


            var ordersToUpdate = await _context.Order.Where(o => o.RefrenceNumber == referenceNumber).ToListAsync();

            if (ordersToUpdate == null || ordersToUpdate.Count == 0)
            {
                return NotFound();
            }

            ordersToUpdate.ForEach(o => o.Status = status);
            await _context.SaveChangesAsync();

            var user = _context.User
                  .Join(_context.Order,
                   u => u.Id,
                   o => o.UserId.Value,
                   (u, o) => new { User = u, Order = o })
                   .Where(x => x.Order.RefrenceNumber == referenceNumber)
                   .Select(x => new {
                       x.User.First_Name,
                       x.User.Last_Name,
                       x.User.Email
                   }).FirstOrDefault();


            string Content = Helper.Common.DynamicOrderStatus(user.First_Name, user.Last_Name, status.ToString(), referenceNumber);
            var message = new Message(new string[] { user.Email }, Helper.Constants.WatchSpace, Content);
            _emailSender.SendEmail(message);
            IsEmailSended = true;


            return RedirectToAction("Status");
        }


        public string GetAdminRole()
        {
            return _accessor.HttpContext.Session.GetString("UserRole");
        }


        public IActionResult NotFound1()
            {
                return View();
            }

        public IActionResult AdminIndex()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                List<Models.Order> orderList = new List<Models.Order>();
                orderList = _context.Order.ToList();


                // Getting Graph Sales and Dates
                // 

                DateTime currentDate = DateTime.Now.Date;
                List<DateTime> dates = new List<DateTime>();

                // Subtract one day from the current date iteratively and add it to the list until you have seven dates
                for (int i = 0; i < 7; i++)
                {
                    dates.Add(currentDate);
                    currentDate = currentDate.AddDays(-1);
                }

                List<int> sales = new List<int>();

                foreach (DateTime date in dates)
                {

                    int? totalSales = _context.Order.Where(o => o.Date == date).Sum(o => o.PurchasedQuantity * o.Sale_Price);
                    sales.Add(Convert.ToInt32(totalSales));
                }

                ViewData["Dates"] = dates;
                ViewData["Sales"] = sales;


                return View(orderList);
            }
            else
            {
                //return View("NotFound1");
                return RedirectToAction("NotFound1", "Admin");
            }
        }
       

        public IActionResult ReportSummary(DateTime dateFrom, DateTime dateTo)
        {
            List<Models.Order> orderList = _context.Order.Where(x => x.Date >= dateFrom && x.Date <= dateTo).ToList();

            // Getting Graph Sales and Dates
            // 

            DateTime currentDate = DateTime.Now.Date;
            List<DateTime> dates = new List<DateTime>();

            // Subtract one day from the current date iteratively and add it to the list until you have seven dates
            for (int i = 0; i < 7; i++)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(-1);
            }

            List<int> sales = new List<int>();

            foreach (DateTime date in dates)
            {

                int? totalSales = _context.Order.Where(o => o.Date == date).Sum(o => o.PurchasedQuantity * o.Sale_Price);
                sales.Add(Convert.ToInt32(totalSales));
            }
           

            ViewData["Dates"] = dates;
            ViewData["Sales"] = sales;
            return View("AdminIndex", orderList);
        }





        public IActionResult ConfirmedOrderList()
        {

            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            List<Models.Order> orderList = new List<Models.Order>();
            orderList = _context.Order.Include(x => x.User).Include(x => x.Product).ToList();
            return View(orderList);
            }
            else
            {
                //return View("NotFound1");
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        public IActionResult Reports()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            List<Models.Order> orderList = new List<Models.Order>();
            orderList = _context.Order.Include(x => x.User).Include(x => x.Product).ToList();
            return View(orderList);
            }
            else
            {
               
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        public IActionResult Message()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            List<Models.ContactUs> message = new List<Models.ContactUs>();
            message =_context.ContactUs.ToList();
            return View(message);
            }
            else
            {
                //return View("NotFound1");
                return RedirectToAction("NotFound1", "Admin");
            }
        }


        [HttpGet]
        public IActionResult FilterReport(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateTo == null)
            {
                dateTo = dateFrom;
            }
            if (dateFrom == null)
            {
                dateFrom = dateTo;
            }
            List<Models.Order> orderList = _context.Order.Include(x => x.Product).Where(x => x.Date >= dateFrom && x.Date <= dateTo).ToList();
            return View("_Reports", orderList);
        }

        [HttpPost]
        public JsonResult SendMail(string Message)
        {
            bool IsEmailSended = false;
            List<Models.User> User_List = new List<Models.User>();
            User_List = GetUsersForSendEmail();
            if (!string.IsNullOrEmpty(Message) && User_List != null && User_List.Count > 0)
            {
                foreach (var item in User_List)
                {
                    string Content = Helper.Common.DynamicSendEmailFromAdminToUsers(item.First_Name, item.Last_Name, Message);
                    var message = new Message(new string[] { item.Email }, Helper.Constants.WatchSpace, Content);
                    _emailSender.SendEmail(message);
                    IsEmailSended = true;
                }
            }
            return Json(IsEmailSended);
        }

        public List<Models.User> GetUsersForSendEmail()
        {
            List<Models.User> User_List = new List<Models.User>();
            User_List = _context.User.ToList();
            if (User_List != null && User_List.Count > 0)
            {
                return User_List;
            }
            return User_List;
        }

        public IActionResult Inventory()
        {
            return View();
        }

    }
}
