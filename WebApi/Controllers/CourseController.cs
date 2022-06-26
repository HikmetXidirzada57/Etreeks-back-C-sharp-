using Abp.Domain.Uow;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
        private readonly IMapper _mapper;
        public CourseController(ICourseManager courseManager, IMapper mapper)
        {
            _courseManager = courseManager;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet("getPopulars")]
        public async Task<List<CourseListDTO>> Get()
        {
            var courseList = await _courseManager.PopularCourses();
            var _mapperCourse = _mapper.Map<List<Course>,List<CourseListDTO>>(courseList);
            return _mapperCourse;
        }


        [HttpGet("filter")]
        public async Task<CourseListFilter>? GetFilteredCourse([FromBody] FilterCourseItem item)
        {
            var courseList = await _courseManager.FilterCourses(item);
            var allCourse = _courseManager.GetAll();
            var mapperCourse = _mapper.Map<List<CourseListDTO>>(courseList);
            var cs = new CourseListFilter
            {
                Courses = mapperCourse,
                MaxPrice=allCourse.Max(c=>c.Price)
            };
            return cs;
        }

        [HttpGet("getAllInclude/{instructorId}")]
        public async Task<List<CourseListDTO>> GetbyInst(int? instructorId)
        {
            var courses = await _courseManager.GetCoursesByInstructor(instructorId);
            var _mapperCourse = _mapper.Map<IEnumerable<Course>, List<CourseListDTO>>(courses);
            return _mapperCourse;
        }

        [HttpGet("GetbyCategory/{categoryId}")]
        public async Task<List<CourseListDTO>> GetbyCategory(int? categoryId)
        {
            var courses = await _courseManager.GetCoursesByCategory(categoryId);
            var _mapperCourse = _mapper.Map<IEnumerable<Course>, List<CourseListDTO>>(courses);
            return _mapperCourse;
        }
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<CourseDetailDTO>?  Get(int? id)
        {
            if (!id.HasValue) return null;
            var singleCourse = await _courseManager.CourseId(id.Value);
            var _courseMapper = _mapper.Map<CourseDetailDTO>(singleCourse);
            return _courseMapper;
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task  Post([FromBody] CourseDetailDTO  courseDetailDTO)
        {
            var _mapperCourse=_mapper.Map<Course>(courseDetailDTO);
            
            await _courseManager.CourseAdd(_mapperCourse);

        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
