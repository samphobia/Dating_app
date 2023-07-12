using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
  public class TokenService : ITokenService
  {
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        
    }
    public string CreateToken(AppUser user)
    {
      throw new NotImplementedException();
    }
  }
}