using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashine
{
   public class Worker
    {

        UserContext db = new UserContext();
        public List<User> GetUsers()
        {
           
            return db.UserTable.ToList<User>();
        }

        
        public Boolean CheckLogin(User user)
        {
            foreach(var item in GetUsers())
            {
                if (item.Mail == user.Mail && item.Password == user.Password)
                    return true;
            }
            return false;
        }

        public User GetUser(User user)
        {
            User u = db.UserTable.Where(d => d.Mail == user.Mail).First();
            return u;
        }

        public bool CreateANewUser(User user)
        {
            if(!CheckLogin(user))
                {
                db.UserTable.Add(user);
                db.SaveChanges();
                return true;
                }
            return false;
           
        }
    }
}
