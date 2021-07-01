using API.Entities;

namespace API.Interfeces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}