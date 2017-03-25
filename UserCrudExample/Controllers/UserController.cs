using Autofac;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UserCrudExample.Code;
using UserCrudExample.Model;
using UserCrudExample.Models;
using UserCrudExample.Repositories;

namespace UserCrudExample.Controllers
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains the external facade of the REST API operations of users
    /// </summary>
    public class UserController : BaseController
    {
        // GET:

        /// <summary>
        /// Get an user information by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User´s information</returns>
        [HttpGet]
        [ResponseType(typeof(GetUserModel))]
        [Route("api/user/get/{id}")]
        public GetUserModel Get(int id)
        {
            User entity;

            try
            {
                using (var repository = _container.Resolve<IUserRepository>())
                {
                    entity = repository.GetUser(id);
                }

                return entity.ToViewModel();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>All user´s information</returns>
        [HttpGet]
        [ResponseType(typeof(GetUserModel))]
        [Route("api/user/getall")]
        public ICollection<GetUserModel> GetAll()
        {
            IList<User> entities;

            try
            {
                using (var repository = _container.Resolve<IUserRepository>())
                {
                    entities = repository.GetAllUsers();
                }

                return entities.ToViewModel();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        
        /// <summary>
        /// Remove an user
        /// </summary>
        /// <param name="id">User id</param>
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/user/remove/{id}")]
        public void Remove(int id)
        {
            try
            {
                using (var repository = _container.Resolve<IUserRepository>())
                {
                    repository.RemoveUser(id);
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // POST:

        /// <summary>
        /// Builds a new user and saves
        /// </summary>
        /// <param name="newUser">New user´s information</param>
        /// <returns>The created user</returns>
        [HttpPost]
        [ResponseType(typeof(GetUserModel))]
        [Route("api/user/create")]
        public GetUserModel Create(CreateUserModel newUser)
        {
            User entity;

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {

                using (var repository = _container.Resolve<IUserRepository>())
                {
                    entity = repository.AddUser(
                        newUser.Name,
                        newUser.Birthdate);
                }

                return entity.ToViewModel();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Edits a user and saves
        /// </summary>
        /// <param name="updateUser">User´s information</param>
        /// <returns>The edited user</returns>
        [HttpPost]
        [ResponseType(typeof(GetUserModel))]
        [Route("api/user/update")]
        public GetUserModel Update(UpdateUserModel updateUser)
        {
            User entity;

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                using (var repository = _container.Resolve<IUserRepository>())
                {
                    entity = repository.EditUser(
                        updateUser.Id,
                        updateUser.Name,
                        updateUser.Birthdate);
                }

                return entity.ToViewModel();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}
