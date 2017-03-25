using System;
using System.Collections.Generic;
using System.Linq;
using UserCrudExample.Model;
using UserCrudExample.Repositories;

namespace UserCrudExample.Tests.Mock
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains a fake of a user repository
    /// </summary>
    public class MockRepository : IUserRepository
    {
        private int _incremental;
        private IList<User> _users;
        
        public MockRepository()
        {
            SetUserMocks();
        }

        private void SetUserMocks()
        {
            _users = MockUsers.GetInitialExampleUsers();
            _incremental = _users.Count();
        }

        public IList<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUser(int userId)
        {
            return _users.SingleOrDefault(x=>x.UserId == userId);
        }

        public User AddUser(string name, DateTime birthdate)
        {
            var user = new User
            {
                Name = name,
                Birthdate = birthdate,
                UserId = _incremental
            };

            _users.Add(user);

            _incremental++;

            return user;
        }

        public User EditUser(int userId, string name, DateTime birthdate)
        {
            var user = _users.SingleOrDefault(x => x.UserId == userId);

            _users.Remove(user);

            var newUser = new User
            {
                Name = name,
                Birthdate = birthdate,
                UserId = user.UserId
            };

            _users.Add(newUser);

            return user;
        }

        public void RemoveUser(int userId)
        {
            var user = _users.SingleOrDefault(x => x.UserId == userId);

            _users.Remove(user);
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _users.Clear();
                }

                disposedValue = true;
                GC.Collect();
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
