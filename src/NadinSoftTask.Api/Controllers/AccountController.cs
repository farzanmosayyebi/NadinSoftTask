using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NadinSoftTask.Core.Dtos.Security;
using NadinSoftTask.Core.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NadinSoftTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IConfiguration configuration, IMapper mapper, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromQuery] UserLoginDto loginCredentials)
    {
        var user = await _userManager.FindByNameAsync(loginCredentials.UserName);
        if (user == null)
            return NotFound(new ResponseDto { Status = "Error", Message = "No user with the entered username was found" });
        if (!await _userManager.CheckPasswordAsync(user, loginCredentials.Password))
            return Unauthorized();

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        authClaims.AddRange(
            userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

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
    public async Task<IActionResult> SignUp([FromQuery] UserRegisterDto registerInfo)
    {
        var user = await _userManager.FindByNameAsync(registerInfo.UserName);

        if (user != null)
            return StatusCode(StatusCodes.Status400BadRequest, 
                new ResponseDto { Status = "Error", Message = "A user with entered username already exists" });

        ApplicationUser newUser = new ApplicationUser
        {
            UserName = registerInfo.UserName,
            Email = registerInfo.Email,
        };

        var result = await _userManager.CreateAsync(newUser, registerInfo.Password);
        
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseDto { Status = "Error", Message = "User creation failed please try again." });

        return Ok();
    }
}
