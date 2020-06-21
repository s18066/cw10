using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.QueryResults;

namespace Application.Services
{
    public interface IStudentService
    {
        Task<IReadOnlyCollection<StudentQueryResult>> GetAllAsync();
        Task<bool> ModifyAsync(StudentDto modifiedStudent);
        Task<bool> DeleteAsync(string indexNumber);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IReadOnlyCollection<StudentQueryResult>> GetAllAsync() =>
            await _studentRepository.GetAllAsync();

        public async Task<bool> ModifyAsync(StudentDto modifiedStudent)
        {
            var student = await _studentRepository.GetAsync(modifiedStudent.IndexNumber);

            if (student is null)
                return false;

            student.BirthDate = modifiedStudent.BirthDate;
            student.FirstName = modifiedStudent.FirstName;
            student.LastName = modifiedStudent.LastName;

            await _studentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string indexNumber)
        {
            var student = await _studentRepository.GetAsync(indexNumber);

            if (student is null)
                return false;

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
            
            return true;
        }
    }
}