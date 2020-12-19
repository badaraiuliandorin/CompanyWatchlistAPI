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
        private DatabaseContext _dbContext;
        public UserRepository()
        {
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Set<User>();
        }
        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Where(predicate).AsEnumerable<User>();
        }
        public User GetOne(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Where(predicate).FirstOrDefault();
        }
        public void Insert(User entity)
        {
            if (entity != null)
                _dbContext.Set<User>().Add(entity);
        }
        public void Delete(object id)
        {
            User entity = _dbContext.Set<User>().Find(id);
            _dbContext.Set<User>().Remove(entity);
        }
    }
}
