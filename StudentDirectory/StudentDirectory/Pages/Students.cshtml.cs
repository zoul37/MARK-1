using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentPortal.Models;
using StudentDirectory.Services;


namespace StudentDirectory.Pages 
{
    public class StudentsModel : PageModel
    {
        private readonly StudentService _studentService;
        
        public List<Student> Students { get; set;  } = new List<Student>();
        public StudentsModel(StudentService studentService)
        {
            _studentService = studentService;
        }

       

        public async Task OnGetAsync()
        {

            Console.WriteLine(" OnGetAsync is executing...");
            Students = await _studentService.GetAllStudentsAsync();
        }
    }
}
