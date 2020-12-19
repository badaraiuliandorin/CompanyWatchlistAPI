using CompanyWatchlistAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Get(Expression<Func<User, bool>> predicate);
        User GetOne(Expression<Func<User, bool>> predicate);
        void Insert(User entity);
        void Delete(object id);
    }
}
