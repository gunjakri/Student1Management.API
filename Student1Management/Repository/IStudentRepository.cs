using Student1Management.Model;

namespace Student1Management.Repository
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAll();
        public Task<Student> Add(Student student);
        public Task<Student> GetById(int id);
        
        public Task<Student> Update(int id, Student student);
        public Task<bool> Delete(int id);

    }

}
