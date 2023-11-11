using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchSpace.Data;

namespace WatchSpace.BAL
{
    public class User
    {
        private readonly ApplicationDbContext _context;

        public User(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddEditUser(Models.User UserData)
        {
            _context.User.Add(UserData);
            _context.SaveChanges();
            return UserData.Id;
        }
    }
}
