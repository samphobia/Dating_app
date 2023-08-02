using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
  public class LikesRepository : ILikesRepository
  {
    public Task<UserLike> getUserLike(int sourceUserId, int targetUserId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
    {
      throw new NotImplementedException();
    }

    public Task<AppUser> GetUserWithlikes(int userId)
    {
      throw new NotImplementedException();
    }
  }
}