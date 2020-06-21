using System.Threading.Tasks;
using Application;
using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudiesRepository : IStudiesRepository
    {
        private readonly StudentContext _context;

        public StudiesRepository(StudentContext context)
        {
            _context = context;
        }
        
        public Task<Studies> GetAsync(string studies)
        {
            return _context.Studies.SingleOrDefaultAsync(x => x.Name == studies);
        }
    }
}