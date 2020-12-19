using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private DatabaseContext _dbContext;
        public RoleRepository()
        {
        }
        public IEnumerable<Role> GetAll()
        {
            return _dbContext.Set<Role>();
        }
        public IEnumerable<Role> Get(Expression<Func<Role, bool>> predicate)
        {
            return _dbContext.Set<Role>().Where(predicate).AsEnumerable<Role>();
        }
        public Role GetOne(Expression<Func<Role, bool>> predicate)
        {
            return _dbContext.Set<Role>().Where(predicate).FirstOrDefault();
        }
        public void Insert(Role entity)
        {
            if (entity != null)
                _dbContext.Set<Role>().Add(entity);
        }
        public void Delete(object id)
        {
            Role entity = _dbContext.Set<Role>().Find(id);
            _dbContext.Set<Role>().Remove(entity);
        }
    }
}
