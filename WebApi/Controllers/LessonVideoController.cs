using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonVideoController : ControllerBase
    {

        ILessonVideoManager _lessonVideoManager;
        IMapper _mapper;

        public LessonVideoController(ILessonVideoManager lessonVideoManager, IMapper mapper)
        {
            _lessonVideoManager = lessonVideoManager;
            _mapper = mapper;
        }



        // GET: api/<LessonVideoController>
        [HttpGet("getVideos")]
        public async Task<IEnumerable<LessonVideoDTO>> Get(int? lessonId)
        {
            var lessonvideo = await _lessonVideoManager.GetLessonVideos(lessonId);
            var _maplesson = _mapper.Map<IEnumerable<LessonVideo>, IEnumerable<LessonVideoDTO>>(lessonvideo);
            return _maplesson;
        }

        //[HttpGet("{instructorsId}")]
        //public async Task<IEnumerable<LessonVideoDTO>> GetByInstructorVideos(int? instructorId)
        //{
        //    var lessonvideo = await _lessonVideoManager.GetLessonVideos(instructorId);
        //    var _maplesson = _mapper.Map<IEnumerable<LessonVideo>, IEnumerable<LessonVideoDTO>>(lessonvideo);
        //    return _maplesson;
        //}

        // GET api/<LessonVideoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LessonVideoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LessonVideoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LessonVideoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
