using Contract.Contract;
using Manager.IManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationManager _authenticationManager;
        public AuthenticationController(IUserManager userManager, IConfiguration configuration, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authenticationManager = authenticationManager;
        }

        public async Task<IActionResult> Register([FromBody] UserContract user)
        {
            if(await _userManager.CreateUser(user) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginContract loginUser)
        {
            int userId = _userManager.ValidateUser(loginUser.Username, loginUser.Password);
            if ( userId > 0)
            {
                var generatedToken = _authenticationManager.GenerateToken(_configuration["JWT:Secret"], 
                                                                 _configuration["JWT:ValidIssuer"], 
                                                                 _configuration["JWT:ValidAudience"], userId);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(generatedToken),
                    expires = generatedToken.ValidTo
                });
            }
            return BadRequest(new 
            {
                token = "",
                expires = (DateTime?) null
            });
        }
    }
}
