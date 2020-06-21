using System.Threading.Tasks;
using Application.Entities;

namespace Application
{
    public interface IEnrollmentsRepository
    {
        Task<Enrollment> GetAsync(Studies studies);
        
        void CreateAsync(Enrollment enrollment);

        Task SaveChangesAsync();
    }
}