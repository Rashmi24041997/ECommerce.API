using AutoMapper;
using ECommerce.Core.Dtos;
using ECommerce.Core.Entities;
using ECommerce.Core.RepositoryContracts;
using ECommerce.Core.ServiceContracts;

namespace ECommerce.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null) { return null; }
            var res = mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
            return res;
            //return new AuthenticationResponse(
            //    Email: loginRequest.Email,
            //    Gender: user.Gender,
            //    PersonName: user.PersonName,
            //    Sucess: true,
            //    Token: "token",
            //    UserID: user.UserID);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            //ApplicationUser user = new ApplicationUser()
            //{
            //    UserID = Guid.NewGuid(),
            //    PersonName = registerRequest.PersonName,
            //    Email = registerRequest.Email,
            //    Gender = registerRequest.Gender.ToString(),
            //    Password = registerRequest.Password
            //};
            ApplicationUser user = mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? res = await usersRepository.AddUser(user);
            if (res != null)
            {
                return mapper.Map<AuthenticationResponse>(res) with { Success = true, Token = "token" };
                //return new AuthenticationResponse(
                //    res.UserID, res.Email, res.PersonName, res.Gender, "token", true
                //    );
            }
            else return null;
        }
    }
}
