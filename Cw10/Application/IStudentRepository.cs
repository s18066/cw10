using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Entities;
using Application.QueryResults;

namespace Application
{
    public interface IStudentRepository
    {
        Task<IReadOnlyCollection<StudentQueryResult>> GetAllAsync();

        void Create(Student student);

        Task<Student> GetAsync(string indexNumber);

        void Delete(Student student);

        Task SaveChangesAsync();
    }
}