using DigiCash.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigiCash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtModel _jwtModel;
        private readonly SignInManager<User> _signInManager;
        public AuthenticationController(IOptions<JwtModel> jwtModel, SignInManager<User> signInManager)
        {
            _jwtModel = jwtModel.Value;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user.TcKimlikNo, user.Password, isPersistent: false, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                var token = createToken(user);
                return Ok(token);
            }
            else
            {
                return Unauthorized(new { message = "Yanlis bilgiler girildi." });
            }
        }

        private User? authenticateUser(User user) {
            throw new NotImplementedException();
        }

        private string createToken(User user)
        {
            if (_jwtModel.Key == null) throw new Exception("JWT Key değeri null olamaz.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimList = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.TcKimlikNo!),
                new Claim(ClaimTypes.NameIdentifier , user.FirstName),
                new Claim(ClaimTypes.NameIdentifier , user.LastName)
            };
            var token = new JwtSecurityToken(_jwtModel.Issuer, _jwtModel.Audience, claimList, expires: DateTime.Now.AddMonths(3) , signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
