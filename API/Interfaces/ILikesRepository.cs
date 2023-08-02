using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
  public interface ILikesRepository
    {
    Task<UserLike> getUserLike(int sourceUserId, int targetUserId);
    Task<AppUser> GetUserWithlikes(int userId);
    Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
  }
}