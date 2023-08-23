using DDD.Infra.MemoryDb.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.University.ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get() {
            return Ok(_studentRepository.GetStudents());
        }
    }
}
