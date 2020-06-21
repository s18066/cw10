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
    namespace Api.Controllers
    {
        [ApiController]
        [Route("/api/students")]
        public class EnrollmentController : ControllerBase
        {
            private readonly IEnrollmentsService _enrollmentsService;

            public EnrollmentController(IEnrollmentsService enrollmentsService)
            {
                _enrollmentsService = enrollmentsService;
            }

            [HttpPost]
            public async Task<IActionResult> EnrollStudent(EnrollmentModel model)
            {
                var enrollment = new EnrollmentDto()
                {
                    Birthdate = model.Birthdate,
                    Email = model.Email,
                    Studies = model.Studies,
                    FirstName = model.FirstName,
                    IndexNumber = model.IndexNumber,
                    LastName = model.LastName
                };

                var result = await _enrollmentsService.EnrollStudent(enrollment);

                if (result.studiesExists is false)
                    return BadRequest("Studies does not exist");

                return Ok();
            }
        
            [HttpPost("promotions")]
            public async Task<IActionResult> GetStudentsAsync(PromotionModel model)
            {
                var result = await _enrollmentsService.PromoteAsync(model.Semester, model.Studies);

                if (result.studiesExists is false)
                    return BadRequest("Studies does not exists");
                
                if (result.enrollmentExists is false)
                    return BadRequest("Enrollment does not exists");

                return NoContent();
            }
        }
    }
}