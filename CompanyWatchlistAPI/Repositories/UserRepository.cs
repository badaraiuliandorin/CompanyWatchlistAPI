using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Set<User>();
        }
        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Where(predicate).AsEnumerable();
        }
        public User GetOne(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Where(predicate).FirstOrDefault();
        }
        public User Insert(User entity)
        {
            if (entity != null)
            {
                var result = _dbContext.Set<User>().Add(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            }

            return null;
        }
        public void Delete(object id)
        {
            User entity = _dbContext.Set<User>().Find(id);
            _dbContext.Set<User>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public User Login(Login login)
        {
            if (login == null || login.Email == null || login.Password == null)
            {
                return null;
            }


            return _dbContext.Set<User>().FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
        }

        private string EncryptPassword(string password)
        {
            return "";
        }
    }
}
