using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly DatabaseContext _dbContext;
        public WatchlistRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        public IEnumerable<Watchlist> GetAll()
        {
            return _dbContext.Set<Watchlist>();
        }
        public IEnumerable<Watchlist> Get(Expression<Func<Watchlist, bool>> predicate)
        {
            return _dbContext.Set<Watchlist>().Where(predicate).AsEnumerable<Watchlist>();
        }
        public Watchlist GetOne(Expression<Func<Watchlist, bool>> predicate)
        {
            return _dbContext.Set<Watchlist>().Where(predicate).FirstOrDefault();
        }
        public Watchlist Insert(Watchlist entity)
        {
            if (entity != null)
            {
                var result = _dbContext.Set<Watchlist>().Add(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            }

            return null;
        }
        public void Delete(object id)
        {
            Watchlist entity = _dbContext.Set<Watchlist>().Find(id);
            _dbContext.Set<Watchlist>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
