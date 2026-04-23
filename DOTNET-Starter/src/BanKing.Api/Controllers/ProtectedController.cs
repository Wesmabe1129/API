using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BanKing.Api.Controllers;

[ApiController]
[Route("api/protected")]
public class ProtectedController : ControllerBase
{
    [HttpGet("user")]
    [Authorize]
    public IActionResult GetUserProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

        return Ok(new
        {
            UserId = userId,
            Email = email,
            Roles = roles,
            Message = "This is a protected endpoint"
        });
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly()
    {
        return Ok(new
        {
            Message = "This endpoint requires Admin role"
        });
    }

    [HttpGet("manager-or-admin")]
    [Authorize(Roles = "Manager,Admin")]
    public IActionResult ManagerOrAdmin()
    {
        return Ok(new
        {
            Message = "This endpoint requires Manager or Admin role"
        });
    }
}
