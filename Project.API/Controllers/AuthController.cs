using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Auth İşlemlerini(login,register) Katmanlı mimariye uygun olarak yapmaya çalıştım ama uygulayamadım...
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost(template: "login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Mail);

            if (user is null)
                throw new NotFoundException("user not found!");

            if (await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(type:ClaimTypes.Name,value:loginModel.Mail)
                };
                authClaims.AddRange(collection: userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var authSinginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSinginKey, SecurityAlgorithms.HmacSha256)

                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Şifrede Bir büyük harf ,bir küçük harf ,bir sayı ve bir karakter olma zorunluluğu vardır...
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel model)
        {
            if (model.Password != model.Password)
                throw new InvalidOperationException("Password are not equal");

            var userExist = await _userManager.FindByEmailAsync(model.Mail);
            if (userExist != null)

                throw new InvalidOperationException("User already exist");

            User user = new User
            {
                Email = model.Mail,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new InvalidOperationException("user did not created");

            if (!await _roleManager.RoleExistsAsync("Member"))
                await _roleManager.CreateAsync(new IdentityRole("Member"));

            if (await _roleManager.RoleExistsAsync("Member"))
                await _userManager.AddToRoleAsync(user, "Member");

            return Ok("Register Success");
        }

    }


}
