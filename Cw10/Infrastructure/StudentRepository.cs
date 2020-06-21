using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Entities;
using Application.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<IReadOnlyCollection<StudentQueryResult>> GetAllAsync()
        {
            return await _studentContext.Student.Select(student => new StudentQueryResult()
            {
                BirthDate = student.BirthDate,
                FirstName = student.FirstName,
                IndexNumber = student.IndexNumber,
                LastName = student.LastName
            }).ToListAsync();
        }

        public void Create(Student student)
        {
            _studentContext.Student.Add(student);
        }

        public async Task<Student> GetAsync(string indexNumber) => 
            await _studentContext.Student.SingleOrDefaultAsync(student => student.IndexNumber == indexNumber);

        public void  Delete(Student student)
        {
            _studentContext.Student.Remove(student);
        }

        public async Task SaveChangesAsync()
        {
            await _studentContext.SaveChangesAsync();
        }
    }
}