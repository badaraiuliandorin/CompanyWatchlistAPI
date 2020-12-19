using CompanyWatchlistAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories.Interfaces
{
    public interface IWatchlistRepository
    {
        IEnumerable<Watchlist> GetAll();
        IEnumerable<Watchlist> Get(Expression<Func<Watchlist, bool>> predicate);
        Watchlist GetOne(Expression<Func<Watchlist, bool>> predicate);
        void Insert(Watchlist entity);
        void Delete(object id);
    }
}
