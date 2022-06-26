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


    public class InstructotrController : ControllerBase
    {

        IInstructorManager _instructorManager;
        private readonly IMapper _mapper;
        public InstructotrController(IInstructorManager instructorManager, IMapper mapper)
        {
            _instructorManager = instructorManager;
            _mapper = mapper;
        }

        // GET: api/<InstructotrController>
        [HttpGet("getInstructers")]
        public async Task<IEnumerable<InstructorDTO>> Get()
        {
           var instructor=await _instructorManager.GetInstructors();
            var _mapInstructor=_mapper.Map<IEnumerable<Instructor>,IEnumerable<InstructorDTO>>(instructor);
            return _mapInstructor;
        }

        // GET api/<InstructotrController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstructotrController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstructotrController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstructotrController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
