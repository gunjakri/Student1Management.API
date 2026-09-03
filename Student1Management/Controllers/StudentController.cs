using Microsoft.AspNetCore.Mvc;
using Student1Management.Data;
using Student1Management.Model;
using Microsoft.EntityFrameworkCore;
using Student1Management.Repository;
namespace Student1Management.Controllers;
[Route("api/[Controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IStudentRepository _studentRepository;
    public StudentController(AppDbContext context, IStudentRepository repository)
    {
        _context = context;
        _studentRepository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetStudent()
    {
        var student = await _studentRepository.GetAll();
        return Ok(student);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentRepository.GetById(id);
        if (student == null)
        {
            return NotFound("No student found with given id");
        }
        return Ok(student);
        //var Student = await _context.StudentDbSet.FindAsync(id);
        //if(Student==null)
        //{
        //    return NotFound("student not found");
        //}
        //return Ok(Student);
    }
    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        var result = await _studentRepository.Add(student);
        return Ok(result);

    }

    [HttpGet("GetName/{id}")]
    public async Task<IActionResult> GetNameById(int id)
    {
        var name = await _studentRepository.GetNameById(id);
        if (name == null)
        {
            return NotFound();
        }

        return Ok(name);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        var result = await _studentRepository.Update(id, student);
        if (result == null)
        {
            return NotFound("Student with given id does not exist");
        }
        return Ok(result);
       
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var isDeleted = await _studentRepository.Delete(id);
        if (!isDeleted)
        {
            return NotFound("student not found");
        }
        return Ok("deleted");

        
    }

    
}


