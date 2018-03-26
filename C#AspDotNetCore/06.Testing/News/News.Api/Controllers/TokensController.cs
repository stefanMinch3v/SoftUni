namespace News.Api.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Models.Tokens;
    using News.Api.Infrastructure.Filters;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using static WebConstants;

    public class TokensController : BaseController
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public TokensController(
            IConfiguration configuration,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        [ValidateModelState]
        public async Task<IActionResult> Login([FromBody] LoginFormModel model)
        {
            var response = Unauthorized() as IActionResult;

            var result = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await this.userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var tokenString = this.BuildToken(user);
                    response = Ok(new { importantMessage = ImportantMessageSecurityToken, token = tokenString });
                }
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Register))]
        [ValidateModelState]
        public async Task<IActionResult> Register([FromBody] RegisterFormModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                PasswordHash = model.Password
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                var tokenString = this.BuildToken(user);

                return Ok(new { importantMessage = ImportantMessageSecurityToken, token = tokenString });
            }

            return BadRequest("Username already exists.");
        }

        private string BuildToken(User model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.NameId, model.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                this.configuration["Jwt:Issuer"],
                this.configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
