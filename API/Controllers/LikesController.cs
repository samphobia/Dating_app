using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class LikesController : BaseApiController
  {
    private readonly IUserRepository _userRepository;
    private readonly ILikesRepository _likesRepository;
    public LikesController(IUserRepository userRepository, ILikesRepository likesRepository)
    {
      _likesRepository = likesRepository;
      _userRepository = userRepository;

    }
    
    [HttpPost("{username}")]
    public async Task<ActionResult> AddLike(string username)
    {
      var sourceUserId = int.Parse(User.GetUserId());
      var likedUser = await _userRepository.GetUserByUsernameAsync(username);
      var sourceUser = await _likesRepository.GetUserWithlikes(sourceUserId);

      if (likedUser == null) return NotFound();

      if (sourceUser.UserName == username) return BadRequest("You cannot like yourself");

      var userLike = await _likesRepository.GetUserLike(sourceUserId, likedUser.Id);

      if (userLike != null) return BadRequest("you already like this user");

      userLike = new UserLike
      {
        SourceUserId = sourceUserId,
        TargetUserId = likedUser.Id
      };

      sourceUser.LikedUsers.Add(userLike);

      if (await _userRepository.SaveAllAsync()) return Ok();

      return BadRequest("Failed to like user");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LikeDto>>> GetUserLikes(string predicate)
    {
      var users = await _likesRepository.GetUserLikes(predicate, int.Parse(User.GetUserId()));

      return Ok(users);
    }
  }
}