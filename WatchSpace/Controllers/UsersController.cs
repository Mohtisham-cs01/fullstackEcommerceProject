using EmailService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WatchSpace.Data;
using WatchSpace.WatchSpaceModels;
using WatchSpace.Models;
using WatchSpace.Helper;
using Microsoft.EntityFrameworkCore;

namespace WatchSpace.Controllers
{
    public class UsersController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _accessor;
        private readonly IApp_Config _appConfig;
        private readonly ApplicationDbContext _context;

        public UsersController(IEmailSender emailSender, ApplicationDbContext context, IHttpContextAccessor accessor, IApp_Config appConfig)
        {
            _emailSender = emailSender;
            _context = context;
            _accessor = accessor;
            _appConfig = appConfig;
        }

        public IActionResult Index()
        {
            return View();
        }


        // Login View

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        // User Login Function

        [HttpPost]
        public JsonResult Login(string TextContent)
        {
            bool IsUserExist = false;
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
            string userRole = string.Empty;
            if (!string.IsNullOrEmpty(TextContent))
            {
                userModel = JsonSerializer.Deserialize<UserModel>(TextContent);
                userData = GetUserByEmailandPassword(userModel.Email, userModel.Password);
                if (userData != null && userData.Id > 0)
                {
                    FillSession(userData);
                    //UserOrderList(userData);
                    IsUserExist = true;
                    userRole = userData.Role;
                }
            }
            return Json(new { IsUserExist, userRole });
        }


        // Get Login User Role

        public string GetUserRole()
        {
            //return _accessor.HttpContext.Session.GetString("UserRole");
            return _appConfig.UserRole;
        }


        // Login User See His Order List

        public IActionResult UserOrderList()
        {
            string role = GetUserRole();
            //var id = _accessor.HttpContext.Session.GetInt32("UserID");
            var id = _appConfig.UserID;

            List<User> user = new List<User>();
            user = _context.User.Where(o => o.Id == id).ToList();

            if (role !=null && role == "User" && role != "" && role != string.Empty || role == "Admin")
            { 
                List<Order> orderList = new List<Order>();
                orderList = _context.Order.Where(o => o.UserId == id).ToList();


                List<Product> products = new List<Product>();
                products = _context.Product.ToList();

                ViewData["products"] = products;
                ViewData["user"] = user;
                return View("UserOrderList" , orderList );
                
            }
            else { 
                return RedirectToAction("NotFound1" , "Admin");
            }

               
        }



        // Login User and Admin fill session 

        public void FillSession(Models.User userData)
        {
            _accessor.HttpContext.Session.SetInt32("UserID", userData.Id);
            _accessor.HttpContext.Session.SetString("UserFullName", userData.First_Name + " " + userData.Last_Name);
            _accessor.HttpContext.Session.SetString("UserAddress", userData.Address);
            _accessor.HttpContext.Session.SetString("UserPhoneNumber", userData.Phone_Number);
            _accessor.HttpContext.Session.SetString("UserEmail", userData.Email);
            _accessor.HttpContext.Session.SetString("UserRole", userData.Role);
        }


        //Login User and Admin Logout

        public IActionResult LogOut()
        {
            ClearSession();
            return RedirectToAction("Login", "Users");
        }


        //Clear Session

        public void ClearSession()
        {
            HttpContext.SignOutAsync();
            _accessor.HttpContext.Session.Clear();
        }


        //Forget Password View

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }



        [HttpPost]
        public JsonResult ForgotPassword(string TextContent)
        {
            bool IsEmailSended = false;
            string BaseURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string EncryptedUserID = string.Empty;
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
            if (!string.IsNullOrEmpty(TextContent))
            {
                userModel = JsonSerializer.Deserialize<UserModel>(TextContent);
                userData = CheckUserByEmail(userModel.Email);
                userData.Id += 1099956;
                if (userData.Id > 0)
                {
                    //EncryptedUserID = Helper.Common.EncryptString(Convert.ToString(userData.Id), Helper.Constants.KeyString);
                    //BaseURL = BaseURL + "/Users/ResetPassword?ID=" + EncryptedUserID;
                    BaseURL = BaseURL + "/Users/ResetPassword?ID=" + userData.Id;
                    BaseURL = "<a href='" + BaseURL + "'>Click Here</a>";
                    string Content = Helper.Common.DynamicResetPasswordEmailTemplate(userData.First_Name, userData.Last_Name, BaseURL);
                    var message = new Message(new string[] { userData.Email }, Helper.Constants.ResetPasswordSubject, Content);
                    _emailSender.SendEmail(message);
                    //TempData["SuccessResetPasswordMsg"] = Helper.Constants.ResetPasswordSuccessMessage;
                    IsEmailSended = true;
                }
                else
                {
                    //TempData["ErrorResetPasswordMsg"] = Helper.Constants.ErrorMessage;
                    IsEmailSended = false;
                }
            }
            return Json(IsEmailSended);       
        }

        [HttpGet]
        public IActionResult AddEditUser()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEditUser(string TextContent)
        {
            string result = string.Empty;
            string BaseURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string EncryptedUserID = string.Empty;
            Models.User UserData = new Models.User();
            if (!string.IsNullOrEmpty(TextContent))
            {
                UserData = JsonSerializer.Deserialize<WatchSpace.Models.User>(TextContent);
                UserData.Id = SaveUpdateUser(UserData);
                if (UserData.Id > 0)
                {
                    //EncryptedUserID = Helper.Common.EncryptString(Convert.ToString(UserData.Id), Helper.Constants.KeyString);
                    //BaseURL = BaseURL + "/Users/SetPassword?ID=" + EncryptedUserID;
                    UserData.Id += 1099956;
                    BaseURL = BaseURL + "/Users/SetPassword?ID=" + UserData.Id;
                    BaseURL = "<a href='" + BaseURL + "'>Click Here</a>";
                    string Content = Helper.Common.DynamicSetPasswordEmailTemplate(UserData.First_Name, UserData.Last_Name, BaseURL);
                    var message = new Message(new string[] { UserData.Email }, Helper.Constants.SetPasswordSubject, Content);
                    _emailSender.SendEmail(message);
                    result = Helper.Constants.RegisterSuccessMessage;
                }
                else
                {
                    result = Helper.Constants.ErrorMessage;
                }
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult CheckUserDuplicateEmail(string Email)
        {
            bool IsEmailMacthed = false;
            if (!string.IsNullOrEmpty(Email))
            {
                IsEmailMacthed = CheckUser_DuplicateEmail(Email);
            }
            return Json(IsEmailMacthed);
        }

        [HttpPost]
        public JsonResult IsAlreadyRegisterWithUs(string Email)
        {
            int userID = 0;
            if (!string.IsNullOrEmpty(Email))
            {
                userID = GetUserIDByEmail(Email);
            }
            return Json(userID);
        }

        [HttpGet]
        public IActionResult SetPassword(string ID)
        {

            Nullable<int> UserID = 0;
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
            if (!string.IsNullOrEmpty(ID))
            {
                //UserID = Convert.ToInt32(Helper.Common.DecryptString(ID, Helper.Constants.KeyString));
                //UserID = (int)double.Parse(ID);
                UserID = int.Parse(ID)- 1099956;
                if (UserID != null && UserID > 0)
                {
                    userData = GetUserByID(UserID);
                    userModel.ID = UserID;
                }
            }
            if (userData != null && string.IsNullOrEmpty(userData.Password) && UserID > 0)
            {
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index" , "Home");
            }

            //if (!string.IsNullOrEmpty(userData.Password))
            //{
            //    return RedirectToAction("Index" , "Home");
            //}
        }

        public IActionResult getInvoice(string refNum)
        {
            List<Order> ordersByRefNum = _context.Order.Where(o => o.RefrenceNumber == refNum).Include(x => x.Product).ToList();

            return View(ordersByRefNum);
        }

        [HttpPost]
        public JsonResult Set_Password(string TextContent)
        {
            bool IsSaved = false;
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
            
            if (!string.IsNullOrEmpty(TextContent))
            {
                userModel = JsonSerializer.Deserialize<UserModel>(TextContent);
                userData = GetUserByID(Convert.ToInt32(userModel.Str_ID));
                if (userData.Password == null)
                {
                    userData.Password = userModel.Password;
                    _context.User.Update(userData);
                    _context.SaveChanges();
                    IsSaved = true;
                }
                else
                {
                    IsSaved = false;
                }
            }
            return Json(IsSaved);
        }


        [HttpGet]
        public IActionResult ResetPassword(string ID)
        {
            Nullable<int> UserID = 0;
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
            if (!string.IsNullOrEmpty(ID))
            {
                //UserID = Convert.ToInt32(Helper.Common.DecryptString(ID, Helper.Constants.KeyString));
                UserID = Convert.ToInt32(ID)- 1099956;
                if (UserID != null && UserID > 0)
                {
                    userData = GetUserByID(UserID);
                    userModel.ID = UserID;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userModel);
        }


        // User Reset Password

        [HttpPost]
        public JsonResult Reset_Password(string TextContent)
        {
            bool IsSaved = false;
            int strId = JsonDocument.Parse(TextContent).RootElement.GetProperty("Str_ID").GetInt32();
            string password = JsonDocument.Parse(TextContent).RootElement.GetProperty("Password").ToString();
            UserModel userModel = new UserModel();
            Models.User userData = new Models.User();
           
            if (!string.IsNullOrEmpty(TextContent))
            {
                //userModel = JsonSerializer.Deserialize<UserModel>(TextContent);
                int userID = strId - 1099956;
                userData = GetUserByID(Convert.ToInt32(userID));
                userData.Password = password;
                _context.User.Update(userData);
                _context.SaveChanges();
                IsSaved = true;
            }
            return Json(IsSaved);
        }



        #region /// ::: ADD TO CART ::: ///


        [HttpPost]
        public JsonResult AddToCart(string UserTextContent, string AddToCartTextContent, string TotalBill)
        {
            Models.User userData = new Models.User();
            List<AddToCartModel> addToCartList = new List<AddToCartModel>();
            List<Models.Order> filledoderList = new List<Models.Order>();
            bool isDataSaved = false;
            if (!string.IsNullOrEmpty(UserTextContent) && !string.IsNullOrEmpty(AddToCartTextContent))
            {
                userData = JsonSerializer.Deserialize<Models.User>(UserTextContent);
                addToCartList = JsonSerializer.Deserialize<List<AddToCartModel>>(AddToCartTextContent);

                /// ::: First Saving User Data & Get saved user ID. Because it is necessary while saving data in order againts user. ::: ///
                SaveUpdateUser(userData);
                /// ::: Second Filling & Saving Orders ::: ///
                filledoderList = FillOrderList(addToCartList, userData.Id, TotalBill);
                IsOrderSaved(filledoderList);
                /// ::: Third Need to subtract the quantity of product from Product ::: ///
                UpdateProductsQuantity(addToCartList);
                isDataSaved = true;

                string Content = Helper.Common.DynamicOrderRefrenceNumberTemplate(userData.First_Name, userData.Last_Name, filledoderList.FirstOrDefault().RefrenceNumber);
                var message = new Message(new string[] { userData.Email }, "WatchSpace", Content);
                _emailSender.SendEmail(message);

                TempData["UserID"] = userData.Id;
            }
            return Json(isDataSaved);
        }

        [HttpPost]
        public JsonResult AddToCartForRegisteredUser(int UserID, string AddToCartTextContent, string TotalBill)
        {
            Models.User userData = new Models.User();
            List<AddToCartModel> addToCartList = new List<AddToCartModel>();
            List<Models.Order> filledoderList = new List<Models.Order>();
            bool isDataSaved = false;
            if (!string.IsNullOrEmpty(AddToCartTextContent))
            {
                addToCartList = JsonSerializer.Deserialize<List<AddToCartModel>>(AddToCartTextContent);

                /// ::: First Getting user data to sending email. ::: ///
                userData = GetUserByID(UserID);
                /// ::: Second Filling & Saving Orders ::: ///
                filledoderList = FillOrderList(addToCartList, UserID, TotalBill);
                IsOrderSaved(filledoderList);
                /// ::: Third Need to subtract the quantity of product from Product ::: ///
                UpdateProductsQuantity(addToCartList);
                isDataSaved = true;

                string Content = Helper.Common.DynamicOrderRefrenceNumberTemplate(userData.First_Name, userData.Last_Name, filledoderList.FirstOrDefault().RefrenceNumber);
                var message = new Message(new string[] { userData.Email }, "WatchSpace", Content);
                _emailSender.SendEmail(message);

                TempData["UserID"] = UserID;
            }
            return Json(isDataSaved);
        }

        #endregion

        #region /// ::: USER ADD/EDIT/READ/DELETE ::: ///

        public int SaveUpdateUser(Models.User UserData)
        {
            UserData.Role = Helper.Constants.WatchSpaceUser;
            _context.User.Add(UserData);
            _context.SaveChanges();
            return UserData.Id;
        }

        public bool CheckUser_DuplicateEmail(string Email)
        {
            bool IsEmailMacthed = false;
            return IsEmailMacthed = _context.User.Any(x => x.Email == Email);
        }

        public int GetUserIDByEmail(string Email)
        {
            int userID = 0;
            Models.User userData = new Models.User();
            userData = _context.User.Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefault();
            if (userData != null && userData.Id > 0)
            {
                userID = userData.Id;
            }
            return userID;
        }

        public Models.User GetUserByID(Nullable<int> ID)
        {
            Models.User userData = new Models.User();
            userData = _context.User.Where(x => x.Id == ID).FirstOrDefault();
            if (userData != null && userData.Id > 0)
            {
                return userData;
            }
            return userData;
        }

        public Models.User GetUserByEmailandPassword(string email, string password)
        {
            //bool isUserExist = false;
            Models.User userData = new Models.User();
            userData = _context.User.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if(userData != null && userData.Id > 0)
            {
                return userData;
                //isUserExist = true;
            }
            return userData;
        }


        public Models.User CheckUserByEmail(string email)
        {
            Models.User userData = new Models.User();
            userData = _context.User.Where(x => x.Email == email).FirstOrDefault();
            if (userData != null && userData.Id > 0)
            {
                return userData;
            }
            return userData;
        }

        #endregion

        #region /// ::: ORDER ::: ///

        /// ::: For Filling Order List ::: ///
        public List<Models.Order> FillOrderList(List<AddToCartModel> addToCartList, int UserID, string TotalBill)
        {
            List<Models.Order> oderList = new List<Models.Order>();
            Models.Product productData = new Models.Product();
            Random rnd = new Random();
            string refrenceNumber = "WatchSpace_" + Convert.ToString(rnd.Next());
            var currentDate = DateTime.Now;
            var date = currentDate.Date;
            if (addToCartList != null && addToCartList.Count > 0)
            {
                foreach (var item in addToCartList)
                {
                    productData = _context.Product.Where(x => x.Id == item.ProductID).FirstOrDefault();

                    oderList.Add(new Models.Order
                    {
                        UserId = UserID,
                        ProductId = item.ProductID,
                        PurchasedQuantity = item.Quantity,
                        Price = item.TotalAmount,
                        TotalBill = Convert.ToInt32(TotalBill),
                        Date = date,
                        //Date = DateTime.Now,
                        RefrenceNumber = refrenceNumber,
                        Original_Price = productData.Orig_Price,
                        Sale_Price = productData.Display_Price
                    });
                }
            }
            return oderList;
        }

        /// ::: For Saving Orders ::: ///
        public bool IsOrderSaved(List<Models.Order> filledoderList)
        {
            bool isSaved = false;
            if (filledoderList != null && filledoderList.Count > 0)
            {
                _context.Order.AddRange(filledoderList);
                _context.SaveChanges();
                isSaved = true;
            }
            return isSaved;
        }

        #endregion

        #region /// ::: PRODUCT ::: ///

        public bool UpdateProductsQuantity(List<AddToCartModel> addToCartList)
        {
            bool isSaved = false;
            Models.Product product = new Models.Product();
            if (addToCartList != null && addToCartList.Count > 0)
            {
                foreach (var item in addToCartList)
                {
                    product = _context.Product.Where(x => x.Id == item.ProductID).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    _context.Product.Update(product);
                    _context.SaveChanges();
                    isSaved = true;
                }
            }
            return isSaved;
        }

        #endregion
    }
}