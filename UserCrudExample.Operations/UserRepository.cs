using System;
using System.Collections.Generic;
using System.Linq;
using UserCrudExample.Model;

/// <summary>
/// UserCrudExample
/// Author: Fernando Concepción Gutiérrez
/// http://www.fconcepcion.com
/// </summary>
namespace UserCrudExample.Repositories
{
    /// <summary>
    /// This interface represents a operation set to work with an independent
    /// user context with the disposable pattern.
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        IList<User> GetAllUsers();
        User GetUser(int userId);
        User AddUser(string name, DateTime birthdate);
        User EditUser(int userId, string name, DateTime birthdate);
        void RemoveUser(int userId);
    }

    /// <summary>
    /// This class works with a user context to do many operations.
    /// Implements dispose pattern to clean the user context.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private IUserContext _context;

        /// <summary>
        /// User repository constructor by an user context
        /// </summary>
        /// <param name="context">User context</param>
        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        #region Operations

        /// <summary>
        /// Get all users of database
        /// </summary>
        /// <returns>All user entity list</returns>
        public IList<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User entity</returns>
        public User GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="birthdate">User birthdate</param>
        /// <returns>Added user entity</returns>
        public User AddUser(string name, DateTime birthdate)
        {
            var newUser = new User
            {
                Name = name,
                Birthdate = birthdate
            };
            
            _context.Users.Add(newUser);

            if (_context.SaveChanges() > 0)
                return newUser;
            else throw new Exception("Error saving model");
        }

        /// <summary>
        /// Edit an existent user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="name">User name</param>
        /// <param name="birthdate">User birthdate</param>
        /// <returns>Edited user entity</returns>
        public User EditUser(int userId, string name, DateTime birthdate)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new Exception("User doesn´t exist");
            }

            user.Name = name;
            user.Birthdate = birthdate;

            if (_context.SaveChanges() > 0)
                return user;
            else throw new Exception("Error saving model");
        }

        /// <summary>
        /// Remove an existent user
        /// </summary>
        /// <param name="userId">User id</param>
        public void RemoveUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new Exception("User doesn´t exist");
            }

            _context.Users.Remove(user);

            if (_context.SaveChanges() <= 0)
                throw new Exception("Error saving model");
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                GC.Collect();
                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
