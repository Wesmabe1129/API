using System.Security.Claims;

namespace BanKing.Api.Middlewares;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string[] _requiredRoles;

    public AuthorizationMiddleware(RequestDelegate next, params string[] requiredRoles)
    {
        _next = next;
        _requiredRoles = requiredRoles;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User?.Identity?.IsAuthenticated != true)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Authentication required");
            return;
        }

        if (_requiredRoles.Length > 0)
        {
            var userRoles = context.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            var hasRequiredRole = _requiredRoles.Any(role => userRoles.Contains(role));

            if (!hasRequiredRole)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync($"Access denied. Required roles: {string.Join(", ", _requiredRoles)}");
                return;
            }
        }

        await _next(context);
    }
}

public static class AuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthorization(this IApplicationBuilder builder, params string[] requiredRoles)
    {
        return builder.UseMiddleware<AuthorizationMiddleware>(requiredRoles);
    }
}
