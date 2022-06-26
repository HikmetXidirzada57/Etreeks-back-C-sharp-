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
    public class LessonController : ControllerBase
    {
        ILessonManager _lessonManager;
        IMapper _mapper;
        public LessonController(ILessonManager lessonManager, IMapper mapper)
        {
            _lessonManager = lessonManager;
            _mapper = mapper;
        }

        // GET: api/<LessonController>
        [HttpGet("getLessons")]
        public async Task<IEnumerable<LessonDTO>> Get(int? courseId)
        {
            var lesson = await _lessonManager.GetLessons(courseId);
            var _maplesson = _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDTO>>(lesson);
            return _maplesson;
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
