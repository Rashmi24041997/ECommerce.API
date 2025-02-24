using ECommerce.Core.Dtos;
using ECommerce.Core.Entities;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Infra.DbContext;
using System.Data;
using Dapper;

namespace ECommerce.Infra
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDBContext dbContext;

        public UsersRepository(DapperDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //Generate a new unique user ID for the user
            user.UserID = Guid.NewGuid();

            // SQL Query to insert user data into the "Users" table.
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

            int rowCountAffected = await dbContext.Connection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "Select * from public.\"Users\" where \"Email\"=@Email and \"Password\"=@Password";

            ApplicationUser? user = await dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { email, password });

            return user;
        }
    }
}
