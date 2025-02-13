using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using StudentPortal.Data;

namespace StudentPortal.Controllers
{
    // Marks this class as an API controller, enabling features like automatic model validation.
    [ApiController]

    // Defines the route for this controller as "api/student".
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        // Injects the AppDbContext dependency, allowing database operations.
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // Handles HTTP GET requests to retrieve all students from the database.
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students); // Returns the list of students with a 200 OK status.
        }

        // Handles HTTP PUT requests to update an existing student's details.
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent(int Id, [FromBody] Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;

            await _context.SaveChangesAsync();
            return Ok(student);// Returns the updated student object.
        }

        // Handles HTTP DELETE requests to remove a student by ID.
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent(); // Returns the deleted student object.
        }

        // Handles HTTP POST requests to add a new student.
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student); // Adds the new student to the database.
            await _context.SaveChangesAsync(); // Saves changes.

            return NoContent(); // Returns 204 No Content after successful insertion.
        }
    }
}
