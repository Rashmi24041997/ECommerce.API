using ECommerce.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ServiceContracts
{
    public interface IUsersService
    {
        public Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        public Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
