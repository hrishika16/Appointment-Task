using Microsoft.EntityFrameworkCore;
using ProductDAL.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL
{
    
    public class UserRepository : IRepository<EntityLayer.User>
    {
        AppointmentDbContext dbContext;
        public UserRepository(AppointmentDbContext dbctx)
        {
            dbContext = dbctx;
        }

        public bool Add(User entity)
        {
            dbContext.users.Add(entity);
            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindByName(string email)
        {
            var obj = from User usr in dbContext.users
                      where usr.Email.ToLower().Equals(email.ToLower())
                      select usr;
            return obj;
        }

        public IEnumerable<User> GetAll()
        {
            var usr = from User apt in
                         dbContext.users
                       select apt;
            return usr;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
