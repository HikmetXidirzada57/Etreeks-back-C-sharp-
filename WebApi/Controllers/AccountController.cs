using AutoMapper;
using Business.Concrete;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AccountController : ControllerBase
    {
       private readonly  UserManager<T110User> _usermanager;
       private readonly IMapper _mapper;
       private readonly IConfiguration _config;
        private readonly TokenManager _tokenManager;
        public AccountController(UserManager<T110User> usermanager, IMapper mapper, IConfiguration config, TokenManager tokenManager)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _config = config;
            _tokenManager = tokenManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {

            //if (ModelState.IsValid)
            //{
            //    res.Value = ModelState.IsValid;
            //    return res;
            //}
            var user = new T110User
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
            };
            user.UserName = registerDTO.Email;
            var result=await _usermanager.CreateAsync(user,registerDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }
                return ValidationProblem();
            }
         
            await _usermanager.AddToRoleAsync(user, "Visitor");
            return Ok(new {status=200, message="istifadeci ugurla elave edildi"});
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
             
            var findUser = await _usermanager.FindByEmailAsync(loginDTO.Email);
            var checkPass = await _usermanager.CheckPasswordAsync(findUser,loginDTO.Password);

            if (findUser == null || !checkPass)
            {
                return Unauthorized();
                //var claims = new[]
                //{
                //    new Claim (JwtRegisteredClaimNames.Sub, _config["Jwt_Subject"]),
                //    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //    new Claim (JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                //    new Claim("UserId",findUser.Id.ToString()),
                //    new Claim("LastName",findUser.LastName.ToString()),
                //    new Claim("FirstName",findUser.FirstName.ToString()),
                //    new Claim("Email",findUser.Email.ToString()),

                //};
                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                //var sign=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                //var token = new JwtSecurityToken(
                // _config["Jwt:Issuer"],
                // _config["Jwt:Audence"],
                // claims,
                // expires: DateTime.UtcNow.AddMinutes(10),
                // signingCredentials: sign
                // );
                //var writeToken = new JwtSecurityToken();

                //var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier , findUser));
                //identity.AddClaim(new Claim(ClaimTypes.Email, loginDTO.Email)); 
            }
            var token = await _tokenManager.GenerateToken(findUser);
            return Ok(new { email=findUser.Email,token});
        }
    }
}
