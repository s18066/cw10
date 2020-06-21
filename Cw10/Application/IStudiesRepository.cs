using System.Threading.Tasks;
using Application.Entities;

namespace Application
{
    public interface IStudiesRepository
    {
        Task<Studies> GetAsync(string studies);
    }
}