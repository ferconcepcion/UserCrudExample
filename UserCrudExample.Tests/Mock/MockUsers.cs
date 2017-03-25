using System;
using System.Collections.Generic;
using UserCrudExample.Model;

namespace UserCrudExample.Tests.Mock
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains fake methods to get user lists
    /// </summary>
    public static class MockUsers
    {
        public static IList<User> GetInitialExampleUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Fernando",
                    Birthdate = new DateTime(1986, 1, 11)
                },
                new User
                {
                    UserId = 2,
                    Name = "Pepe",
                    Birthdate = new DateTime(1965, 2, 10)
                }
            };
        }
    }
}
