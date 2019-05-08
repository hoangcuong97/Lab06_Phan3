using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class UserDao
    {
        TrungTamX db = null;
        public UserDao()
        {
            db = new TrungTamX();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
