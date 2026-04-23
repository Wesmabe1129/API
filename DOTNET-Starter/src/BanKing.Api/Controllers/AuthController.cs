using Microsoft.AspNetCore.Mvc;
using BanKing.Application.DTOs;
using BanKing.Application.Services;

namespace BanKing.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authService.Login(request);

        if (!result.Success)
            return Unauthorized(result.Message);

        return Ok(result);
    }
}