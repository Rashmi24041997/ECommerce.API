using ECommerce.Core.Dtos;
using ECommerce.Core.Entities;
using ECommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = new Guid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Person1",
                Gender = GenderOptions.Female.ToString()
            };
        }
    }
}
