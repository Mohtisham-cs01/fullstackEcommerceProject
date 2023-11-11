using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Helper
{
    public interface IApp_Config
    {
        int UserID { get; }
        string UserFullName { get; }
        string UserAddress { get; }
        string UserPhoneNumber { get; }
        string UserEmail { get; }
        string UserRole { get; }
    }
}
