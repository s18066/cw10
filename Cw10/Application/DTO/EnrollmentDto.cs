using System;

namespace Application.DTO
{
    public class EnrollmentDto
    {
        public string IndexNumber { get; set; }

        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public string Studies { get; set; }
        
    }
}