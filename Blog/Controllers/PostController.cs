using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.Model;
using DomainLayer.PostDto;
using DomainLayer.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _ipostService;
        IMapper _imapper;

        public PostController(IPostService ipostService, IMapper imapper)
        {
            _ipostService = ipostService;
            _imapper = imapper;
        }

        //endpoint to get all posts
        [HttpGet]
        public IActionResult GetPost()
        {
            return Ok(_imapper.Map<List<PostDto>>(_ipostService.GetAllPost()));

        }

        //endpoint to get one post
        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromQuery] bool withLikes = false, [FromQuery] bool withComments = false, [FromQuery] bool withTags = false)
        {
            Post? post =  _ipostService.GetPost(id, withLikes, withComments, withTags);

            if (post == null)
            {
                return NotFound();
            }

            PostDto existingPost = _imapper.Map<PostDto>(post);

            return Ok(existingPost);
        }

        //endpoint to create post
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostDto postdto)
        {
            Post newPost = _imapper.Map<Post>(postdto);

            Post? craetePost = _ipostService.CreatePost(newPost, postdto.TagIds, out string message);

            if (craetePost == null)
            {
                return BadRequest(message);
            }

            PostDto existingPost = _imapper.Map<PostDto>(craetePost);

            return Ok(existingPost);
        }

        //endpoint to update a post
        [HttpPut]
        public IActionResult UpdatePost([FromBody] UpdatePostDto postdto)
        {
            Post existingPost = _imapper.Map<Post>(postdto);
            
            Post? postUpdate = _ipostService.UpdatePost(existingPost, out string message);

            if (postUpdate is null)
            {
                return BadRequest(message);
            }

            PostDto newPost = _imapper.Map<PostDto>(postUpdate);

            return Ok(newPost);
        }

        //endpoint to delete a post
        [HttpDelete("{id}")]
        public IActionResult DeletePost(string id)
        {
            string message;
            bool isDeleted =  _ipostService.DeletePost(int.Parse(id), out message);
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Deleted successfully" });
        }
    }
}
