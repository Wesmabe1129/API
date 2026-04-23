using BanKing.Domain.Entities;

namespace BanKing.Domain.Interfaces;

public interface IUserRepository
{
    User GetByEmail(string email);
    IList<string> GetUserRoles(int userId);
}