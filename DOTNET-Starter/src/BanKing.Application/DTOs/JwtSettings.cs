namespace BanKing.Application.DTOs;

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = "BanKingApi";
    public string Audience { get; set; } = "BanKingClient";
    public int ExpiryMinutes { get; set; } = 60;
}
