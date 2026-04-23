using BanKing.Domain.Entities;
using BanKing.Domain.Interfaces;
using BanKing.Infrastructure.Data;

namespace BanKing.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email) ?? null!;
    }

    public IList<string> GetUserRoles(int userId)
    {
        // For now, return a default role. In a real application, 
        // this would query a UserRoles table or similar
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return new List<string>();

        // Default role assignment - you can customize this logic
        if (user.Email.Contains("admin"))
            return new List<string> { "Admin", "User" };
        else if (user.Email.Contains("manager"))
            return new List<string> { "Manager", "User" };
        else
            return new List<string> { "User" };
    }
}