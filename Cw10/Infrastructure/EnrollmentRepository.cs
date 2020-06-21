using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EnrollmentRepository : IEnrollmentsRepository
    {
        private readonly StudentContext _context;

        public EnrollmentRepository(StudentContext _context)
        {
            this._context = _context;
        }
        
        public async Task<Enrollment> GetAsync(Studies studies)
        {
            return await _context.Enrollment
                .SingleOrDefaultAsync(x => x.IdStudy == studies.IdStudy);
        }

        public void CreateAsync(Enrollment enrollment)
        {
            _context.Enrollment.Add(enrollment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}