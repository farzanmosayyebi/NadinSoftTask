using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using NadinSoftTask.Core.Dtos.Security;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Application.Services;
public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public AccountService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<Claim>> Login(UserLoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        
        if (user == null)
            throw new NullReferenceException();
        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            throw new UnauthorizedAccessException();

        var userRoles = await _userManager.GetRolesAsync(user);
        
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        authClaims.AddRange(
            userRoles.Select(r => new Claim(ClaimTypes.Role, r)));
        
        return authClaims;
    }

    public async Task Register(UserRegisterDto registerDto)
    {
        var user = await _userManager.FindByNameAsync(registerDto.UserName);

        if (user != null)
            throw new DuplicateNameException();

        ApplicationUser newUser = new ApplicationUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            CreatedProducts = new List<Product>()
        };

        var result = await _userManager.CreateAsync(newUser, registerDto.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException();

    }
}
