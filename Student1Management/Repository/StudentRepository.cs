using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student1Management.Data;
using Student1Management.Model;

namespace Student1Management.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
        {
            var student = await _context.StudentDbSet.ToListAsync();
            return student;
        }
        public async Task<Student> Add(Student student)
        {
            _context.StudentDbSet.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> GetById(int id)
        {
            var student = await _context.StudentDbSet.FindAsync(id);
            if(student==null)
            {
                return null;
            }
            return student;

        }
        public async Task<Student> Update(int id, Student student)
        {
            var stud = await _context.StudentDbSet.FindAsync(id);
            if(student==null)
            {
                return null;
            }
            stud.Name = student.Name;
            stud.age = student.age;
            stud.email = student.email;
            await _context.SaveChangesAsync();
            return stud;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.StudentDbSet.FindAsync(id);
            if (student == null)
            {
                return false;
            }
            _context.StudentDbSet.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> GetNameById(int id)
        {
            var student = await _context.StudentDbSet.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            return student.Name;
        }
    }

}
