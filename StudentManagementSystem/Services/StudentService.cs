using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;
        
        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public async Task<List<Student>> GetAllAsync()
        {
            _logger.LogInformation("Getting all students");
            return await _repository.GetAllAsync();
        }
        
        public async Task<Student?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Getting student with ID: {StudentId}", id);
            return await _repository.GetByIdAsync(id);
        }
        
        public async Task<Student> CreateAsync(Student student)
        {
            _logger.LogInformation("Creating new student: {Name}", student.Name);
            return await _repository.AddAsync(student);
        }
        
        public async Task<Student?> UpdateAsync(int id, Student student)
        {
            _logger.LogInformation("Updating student with ID: {StudentId}", id);
            student.Id = id;
            return await _repository.UpdateAsync(student);
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting student with ID: {StudentId}", id);
            return await _repository.DeleteAsync(id);
        }
    }
}
