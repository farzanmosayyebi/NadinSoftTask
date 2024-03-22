using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NadinSoftTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserInfoController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize]
    [Route("me")]
    public async Task<IActionResult> Get()
    {
        //var userClaims = this.User.Claims;

        var jwtId = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var IsAuth = User.Identity.IsAuthenticated;
        var theUser = await _userManager.Users.Include(u => u.CreatedProducts).SingleOrDefaultAsync(u => u.Id == Guid.Parse(userId));
        var createdProducts = theUser.CreatedProducts.Count;
        //var theUser = await _userManager.FindByNameAsync(user);

        return Ok(new 
        {
            JwtId = jwtId,
            UserId = userId,
            UserName = username,
            Auth = IsAuth,
            TheUser = theUser,
            CreatedProducts = createdProducts
        });
    }
}
