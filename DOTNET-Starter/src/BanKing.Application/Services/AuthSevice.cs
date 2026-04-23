using BanKing.Application.DTOs;
using BanKing.Domain.Interfaces;
using BanKing.Domain.Entities;

namespace BanKing.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public AuthResponse Login(LoginRequest request)
    {
        var user = _userRepository.GetByEmail(request.Email);

        if (user == null)
            return new AuthResponse { Success = false, Message = "Invalid email or password" };

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return new AuthResponse { Success = false, Message = "Invalid email or password" };

        var userRoles = _userRepository.GetUserRoles(user.Id);
        var token = _jwtTokenService.GenerateToken(user, userRoles);

        return new AuthResponse
        {
            Success = true,
            Token = token,
            User = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userRoles?.ToList() ?? new List<string>()
            }
        };
    }
}