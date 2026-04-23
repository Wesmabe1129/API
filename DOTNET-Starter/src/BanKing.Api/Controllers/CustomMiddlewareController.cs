using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BanKing.Api.Middlewares;

namespace BanKing.Api.Controllers;

[ApiController]
[Route("api/custom")]
public class CustomMiddlewareController : ControllerBase
{
    [HttpGet("authenticate-only")]
    public IActionResult AuthenticateOnly()
    {
        var userId = User.Identity?.IsAuthenticated == true ? "Authenticated" : "Not Authenticated";
        return Ok(new
        {
            Message = "This endpoint uses standard authentication",
            Authenticated = User.Identity?.IsAuthenticated ?? false
        });
    }

    [HttpGet("admin-authorization")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminAuthorization()
    {
        return Ok(new
        {
            Message = "This endpoint uses standard authorization for Admin role",
            User = User.Identity?.Name ?? "Unknown"
        });
    }

    [HttpGet("manager-authorization")]
    [Authorize(Roles = "Manager")]
    public IActionResult ManagerAuthorization()
    {
        return Ok(new
        {
            Message = "This endpoint uses standard authorization for Manager role",
            User = User.Identity?.Name ?? "Unknown"
        });
    }

    [HttpGet("multi-role-authorization")]
    [Authorize(Roles = "Admin,Manager,User")]
    public IActionResult MultiRoleAuthorization()
    {
        return Ok(new
        {
            Message = "This endpoint uses standard authorization for multiple roles",
            User = User.Identity?.Name ?? "Unknown"
        });
    }
}
