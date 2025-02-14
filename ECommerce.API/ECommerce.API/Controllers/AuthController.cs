using ECommerce.Core.Dtos;
using ECommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService usersService;

        public AuthController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpGet]
        public IActionResult Default()
        {
            return Ok("Hi");
        }

        [HttpPost("Register")]
        //[Route]
        public async Task<IActionResult> Register(Core.Dtos.RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest(ModelState);
            }

            AuthenticationResponse? authResponse = await usersService.Register(registerRequest);
            if (authResponse == null || !authResponse.Sucess)
            {
                return BadRequest(ModelState);
            }
            return Ok(authResponse);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Core.Dtos.LoginRequest loginRequest)
        {

            if (loginRequest == null)
            {
                return BadRequest(ModelState);
            }

            AuthenticationResponse? authResponse = await usersService.Login(loginRequest);
            if (authResponse == null || !authResponse.Sucess)
            {
                return Unauthorized(authResponse);
            }
            return Ok(authResponse);
        }

    }
}
