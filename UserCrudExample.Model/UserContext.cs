using System;
using System.Data.Entity;

/// <summary>
/// UserCrudExample
/// Author: Fernando Concepción Gutiérrez
/// http://www.fconcepcion.com
/// </summary>
namespace UserCrudExample.Model
{
    /// <summary>
    /// This interface represents a context to build a user´s DbSet, a save operation and
    /// a Disposable option
    /// </summary>
    public interface IUserContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }

    /// <summary>
    /// This class represents a simple DbContext to build a user´s DbSet
    /// in a database.
    /// </summary>
    public class UserContext : DbContext, IUserContext
    {
        public UserContext() : base("UserCrudExampleDB")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
