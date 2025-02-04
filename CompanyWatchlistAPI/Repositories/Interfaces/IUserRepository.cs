﻿using CompanyWatchlistAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Login(Login login);
        IEnumerable<User> GetAll();
        IEnumerable<User> Get(Expression<Func<User, bool>> predicate);
        User GetOne(Expression<Func<User, bool>> predicate);
        User Insert(User entity);
        void Delete(object id);
    }
}
