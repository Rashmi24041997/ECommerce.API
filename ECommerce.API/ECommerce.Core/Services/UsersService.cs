using ECommerce.Core.Dtos;
using ECommerce.Core.Entities;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Core.ServiceContracts;

namespace ECommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null) { return null; }
            return new AuthenticationResponse(
                Email: loginRequest.Email,
                Gender: user.Gender,
                PersonName: user.PersonName,
                Sucess: true,
                Token: "token",
                UserID: user.UserID);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Gender = registerRequest.Gender.ToString(),
                Password = registerRequest.Password
            };
            ApplicationUser? res = await usersRepository.AddUser(user);
            if (res != null)
            {
                return new AuthenticationResponse(
                    res.UserID, res.Email, res.PersonName, res.Gender, "token", true
                    );
            }
            else return null;
        }
    }
}
