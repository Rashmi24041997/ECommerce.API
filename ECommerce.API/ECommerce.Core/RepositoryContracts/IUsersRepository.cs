using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Contract to be implemented by UsersRepository that contains data access logic of Users data store
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add a user to the data store and return the added user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);


        /// <summary>
        /// Method to retrieve existing user by their email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
