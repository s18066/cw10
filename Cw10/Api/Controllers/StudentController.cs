using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Application.DTO;
using Application.QueryResults;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentQueryResult>>> GetStudentsAsync()
        {
            var result = await _studentService.GetAllAsync();
            return result.ToArray();
        }

        [HttpPut("{studentIndex}")]
        public async Task<IActionResult> Modify(string studentIndex, [FromBody] StudentModel studentModel)
        {
            var dto = new StudentDto()
            {
                BirthDate = studentModel.BirthDate,
                FirstName = studentModel.FirstName,
                IndexNumber = studentIndex,
                LastName = studentModel.LastName
            };

            var result = await _studentService.ModifyAsync(dto);
            return result ? NoContent() : NotFound() as IActionResult;
        }
        
        [HttpDelete("{studentIndex}")]
        public async Task<IActionResult> Modify(string studentIndex)
        {
            var result = await _studentService.DeleteAsync(studentIndex);
            return result ? NoContent() : NotFound() as IActionResult;
        }
    }
}