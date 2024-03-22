using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using NadinSoftTask.Core.Dtos.Security;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAccountService _accountService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
                            IAccountService accountService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _accountService = accountService;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromQuery] UserLoginDto loginDto)
    {
        var authClaims = await _accountService.Login(loginDto);

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromQuery] UserRegisterDto registerDto)
    {
        await _accountService.Register(registerDto);
        
        return Ok();
    }
}
