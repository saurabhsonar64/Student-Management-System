using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var created = await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var updated = await _studentService.UpdateAsync(id, student);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
