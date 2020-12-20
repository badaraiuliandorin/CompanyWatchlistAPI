using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using CompanyWatchlistAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyWatchlistAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly IEncryptionService _encryptionService;
        public UserRepository(DatabaseContext databaseContext, IEncryptionService encryptionService)
        {
            _dbContext = databaseContext;
            _encryptionService = encryptionService;
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
                var encryptedPassword = _encryptionService.Encrypt(entity.Password);
                entity.Password = encryptedPassword;
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

            var sameEmailUser = _dbContext.Set<User>().FirstOrDefault(x => x.Email == login.Email);

            if (sameEmailUser != null && login.Password.Equals(_encryptionService.Decrypt(sameEmailUser.Password)))
            {
                return sameEmailUser;
            }

            return null;
        }

        private string EncryptPassword(string password)
        {
            return "";
        }
    }
}
