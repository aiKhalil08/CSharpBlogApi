using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.Model;
using DomainLayer.TagDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class TagController : ControllerBase
    {
        ITagService _itagService;
        IMapper _imapper;

        public TagController(ITagService itagService, IMapper imapper)
        {
            _itagService = itagService;
            _imapper = imapper;
        }

        //endpoint to get all tags
        [HttpGet]
        public IActionResult GetTag()
        {
            return Ok(_imapper.Map<List<TagDto>>(_itagService.GetAllTag()));

        }

        //endpoint to get one tag
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Tag? tag = _itagService.GetTag(id);

            if (tag == null)
            {
                return NotFound();
            }

            TagDto existingTag = _imapper.Map<TagDto>(tag);

            return Ok(existingTag);
        }

        //endpoint to create tag
        [HttpPost]
        public IActionResult CreateTag([FromBody] CreateTagDto tagdto)
        {
            Tag newTag = _imapper.Map<Tag>(tagdto);

            Tag? craeteTag = _itagService.CreateTag(newTag, out string message);

            if (craeteTag == null)
            {
                return BadRequest(message);
            }

            TagDto existingTag = _imapper.Map<TagDto>(craeteTag);

            return Ok(existingTag);
        }

        //endpoint to update a tag
        [HttpPut]
        public IActionResult UpdateTag([FromBody] UpdateTagDto tagdto)
        {
            Tag existingTag = _imapper.Map<Tag>(tagdto);

            Tag? tagUpdate = _itagService.UpdateTag(existingTag, out string message);

            if (tagUpdate is null)
            {
                return BadRequest(message);
            }

            TagDto newTag = _imapper.Map<TagDto>(tagUpdate);

            return Ok(newTag);
        }

        //endpoint to delete a tag
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(string id)
        {
            string message;
            bool isDeleted = _itagService.DeleteTag(int.Parse(id), out message);
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Deleted successfully" });
        }
    }
}
