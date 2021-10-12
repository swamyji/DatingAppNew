using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfeces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LikesController: BaseController
    {
        private readonly IUserRepository _userRepository;

        private readonly ILikedReposity _likedRepository;

        public LikesController(IUserRepository userRepository, ILikedReposity likedRepository)
        {
            _userRepository = userRepository;
            _likedRepository = likedRepository;
        }   

        [HttpPost("{username}")]
        public async Task<ActionResult> AddLike(string username)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await _userRepository.GetUserByNameAsync(username);
            var souceUser = await _likedRepository.GetUserWithLikes(sourceUserId);

            if(likedUser == null) return NotFound();

            if(souceUser.UserName == username) return BadRequest("You cannot like yourself");

            var userLike = await _likedRepository.GetUserLike(sourceUserId, likedUser.Id);

            if(userLike !=null) return BadRequest("You already like this user");

            userLike = new UserLike
            {
                SourceUserId = sourceUserId,
                LikedUserId = likedUser.Id
            };

            souceUser.LikedUsers.Add(userLike);
            if(await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to like user");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetUserLikes([FromQuery] LikesParams likesParams)
        {
            likesParams.UserId = User.GetUserId();
            var users = await _likedRepository.GetUserLikes(likesParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.Totalcount, users.TotalPages);

            return Ok(users);
        }
    }
}