using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using FluentValidation;

using NadinSoftTask.Core.Dtos.Security;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Core.Exceptions;

namespace NadinSoftTask.Application.Services;
public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IValidator<UserRegisterDto> _userRegisterValidator;

    public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper,
                        IValidator<UserRegisterDto> userRegisterValidator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _userRegisterValidator = userRegisterValidator;
    }

    public async Task<List<Claim>> Login(UserLoginDto loginDto)
    {

        var user = await _userManager.FindByNameAsync(loginDto.UserName)
            ?? throw new UserNotFoundException("Invalid username");
        
        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            throw new UnauthorizedAccessException("Invalid password");

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
        await _userRegisterValidator.ValidateAndThrowAsync(registerDto);

        var user = await _userManager.FindByNameAsync(registerDto.UserName);

        if (user != null)
            throw new DuplicateNameException("Another user with the given username exists");

        ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerDto);

        var result = await _userManager.CreateAsync(newUser, registerDto.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException("User registeration failed.");

    }
}
