using System.Collections.Generic;
using System.Linq;
using UserCrudExample.Model;
using UserCrudExample.Models;

namespace UserCrudExample.Code
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains extensions methods to transforms the user entity to models
    /// </summary>
    public static class ModelConverterExtension
    {
        /// <summary>
        /// Get the equivalent user model
        /// </summary>
        /// <param name="entity">User entity</param>
        /// <returns>Equivalent user model</returns>
        public static GetUserModel ToViewModel(this User entity)
        {
            return new GetUserModel
            {
                Id = entity.UserId,
                Birthdate = entity.Birthdate,
                Name = entity.Name
            };
        }

        /// <summary>
        /// Get the equivalent user model collections
        /// </summary>
        /// <param name="entities">User entity list</param>
        /// <returns>Equivalent user model collection</returns>
        public static ICollection<GetUserModel> ToViewModel(this IEnumerable<User> entities)
        {
            return entities.Select(x => x.ToViewModel()).ToList();
        }
    }
}