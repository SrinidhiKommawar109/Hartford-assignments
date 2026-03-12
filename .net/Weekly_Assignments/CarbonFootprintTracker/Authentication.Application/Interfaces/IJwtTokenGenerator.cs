using Authentication.Domain.Entities;

namespace Authentication.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
