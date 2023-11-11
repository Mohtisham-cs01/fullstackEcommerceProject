using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Helper
{
    public class App_Config : IApp_Config
    {
        private readonly IHttpContextAccessor _accessor;

        public App_Config(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Int32 UserID
        {
            get { return _accessor.HttpContext.Session.GetInt32("UserID") != null ? Convert.ToInt32(_accessor.HttpContext.Session.GetInt32("UserID")) : 0; }
        }

        public string UserFullName
        {
            get { return _accessor.HttpContext.Session.GetString("UserFullName") != null ? _accessor.HttpContext.Session.GetString("UserFullName").ToString() : string.Empty; }
        }

        public string UserAddress
        {
            get { return _accessor.HttpContext.Session.GetString("UserAddress") != null ? _accessor.HttpContext.Session.GetString("UserAddress").ToString() : string.Empty; }
        }
        
        public string UserPhoneNumber
        {
            get { return _accessor.HttpContext.Session.GetString("UserPhoneNumber") != null ? _accessor.HttpContext.Session.GetString("UserPhoneNumber").ToString() : string.Empty; }
        }
        
        public string UserEmail
        {
            get { return _accessor.HttpContext.Session.GetString("UserEmail") != null ? _accessor.HttpContext.Session.GetString("UserEmail").ToString() : string.Empty; }
        }

        public string UserRole
        {
            get { return _accessor.HttpContext.Session.GetString("UserRole") != null ? _accessor.HttpContext.Session.GetString("UserRole").ToString() : string.Empty; }
        }

    }
}
