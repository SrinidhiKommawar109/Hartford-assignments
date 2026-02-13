using Microsoft.AspNetCore.Mvc;
using StudentAPI_P1.Data;
using StudentAPI_P1.Models;
//handles API requests
namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        //dependency injection
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/students
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        // POST api/students
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _context.Students.Add(student);
            return Ok(student);
        }
    }
}