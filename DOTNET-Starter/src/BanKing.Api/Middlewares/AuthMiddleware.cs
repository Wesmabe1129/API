using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BanKing.Application.Services;

namespace BanKing.Api.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthMiddleware(RequestDelegate next, IJwtTokenService jwtTokenService)
    {
        _next = next;
        _jwtTokenService = jwtTokenService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = ExtractTokenFromRequest(context);
        
        if (!string.IsNullOrEmpty(token))
        {
            var principal = _jwtTokenService.GetPrincipalFromToken(token);
            if (principal != null)
            {
                context.User = principal;
            }
        }

        await _next(context);
    }

    private string? ExtractTokenFromRequest(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();
        
        if (authHeader != null && authHeader.StartsWith("Bearer "))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }

        return null;
    }
}

public static class AuthMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthentication(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthMiddleware>();
    }
}
