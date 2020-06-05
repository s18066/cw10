using System.Threading.Tasks;
using Application.QueryResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StudentQueryResult>> GetStudentsAsync()
        {
            
        }
        
    }
}