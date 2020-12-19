using CompanyWatchlistAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        IEnumerable<Role> Get(Expression<Func<Role, bool>> predicate);
        Role GetOne(Expression<Func<Role, bool>> predicate);
        void Insert(Role entity);
        void Delete(object id);
    }
}
