using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchSpace.Data;
using WatchSpace.Models;

namespace WatchSpace.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        public ProductsController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public string GetAdminRole()
        {
            return _accessor.HttpContext.Session.GetString("UserRole");
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            ViewData["CompanyId"] = await _context.Company.ToListAsync();
            var applicationDbContext = _context.Product.Include(p => p.Company);
            return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("NotFound" ,"Admin");
            }
        }


        public async Task<IActionResult> ProductList()
        {
            return View(await _context.Product.ToListAsync());
        }


        public async Task<IActionResult> searchByName(string name)
        {
            var searchResult = (await _context.Product.Where(a => a.Name == name).ToListAsync());
            return View("ProductList", searchResult);
        }


        [HttpGet]
        public IActionResult searchByPrice(string name, int min = 0, int max = 1000000)
        {
            if (name != null && name != "" && name != string.Empty)
            {
                List<Models.Product> productList = _context.Product.Where(x => x.Display_Price >= min && x.Display_Price <= max && x.Name.Contains(name)).ToList();
                return View("ProductList", productList);
            }

            if (name == null )
            {
                List<Models.Product> productList = _context.Product.Where(x => x.Display_Price >= min && x.Display_Price <= max).ToList();
                return View("ProductList", productList);
            }


            return View("ProductList","Products");
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = await _context.Product
                    .Include(p => p.Company)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
            return View();
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Description,Quantity,Orig_Price,Display_Price,CompanyId")] Product product)
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", product.Company);
                return View(product);
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }
        
       

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
            return View(product);
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Description,Quantity,Orig_Price,Display_Price,CompanyId")] Product product)
        {
            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                if (id != product.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
                return View(product);
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = await _context.Product
                    .Include(p => p.Company)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");

                return View(product);
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string role = GetAdminRole();
            if (role != null && role == "Admin" && role != "" && role != string.Empty)
            {
                List<Models.Order> orderList = new List<Models.Order>();
                orderList = _context.Order.Include(x => x.Product).ToList();
                var product = await _context.Product.FindAsync(id);

                var orders = _context.Order.ToList();
                var ordercount = orders.Count(o => o.ProductId == id);
                //int? orderCount = orderList.Count(o => o.ProductId == product);

                if (ordercount > 0)
                {
                    ViewBag.count = ordercount;
                    return View("deleteConfirmPage");
                }

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("NotFound1", "Admin");
            }
          
        }
       
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
        //////////////////

        //public void UpdateOrderDatesWeek()
        //{
        //    // Retrieve the existing orders from the database
        //    List<Order> orders = _context.Order.OrderByDescending(o => o.OrderId).ToList();

        //    // Group orders by reference number
        //    var ordersByReference = orders.GroupBy(o => o.RefrenceNumber);

        //    // Calculate the start date and end date for the last 8 consecutive days
        //    DateTime endDate = DateTime.Now.Date;
        //    DateTime startDate = endDate.AddDays(-7);

        //    // Assign the last 8 consecutive dates to the orders, grouped by reference number
        //    foreach (var group in ordersByReference)
        //    {
        //        DateTime groupDate = startDate;

        //        foreach (Order order in group)
        //        {
        //            order.Date = groupDate;
        //            groupDate = groupDate.AddDays(1);
        //        }
        //    }

        //    // Save changes to the database
        //    _context.SaveChanges();
        //}

        //////////////////for 3-4 months
        //public void UpdateOrderDates()
        //{
        //    // Retrieve the existing orders from the database
        //    List<Order> orders = _context.Order.ToList();

        //    // Group orders by reference number
        //    var ordersByReference = orders.GroupBy(o => o.RefrenceNumber);

        //    // Generate random dates within the desired range
        //    DateTime startDate = new DateTime(2023, 2, 1);
        //    DateTime endDate = new DateTime(2023, 5, 31);
        //    Random random = new Random();

        //    foreach (var group in ordersByReference)
        //    {
        //        DateTime groupDate = GetRandomDate(startDate, endDate, random);

        //        foreach (Order order in group)
        //        {
        //            order.Date = groupDate;
        //        }
        //    }

        //    // Save changes to the database
        //    _context.SaveChanges();
        //}

        //// Method to generate random dates within a specified range
        //private static DateTime GetRandomDate(DateTime startDate, DateTime endDate, Random random)
        //{
        //    TimeSpan timeSpan = endDate - startDate;
        //    TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
        //    return startDate + newSpan;
        //}














        /////////////////

    }
    
}
