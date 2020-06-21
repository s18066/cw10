using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Application.DTO;
using Application.Entities;

namespace Application.Services
{
    public interface IEnrollmentsService
    {
        Task<(int? enrollmnentId, bool studiesExists)> EnrollStudent(EnrollmentDto enrollmentDto);

        Task<(bool studiesExists, bool enrollmentExists)> PromoteAsync(int semester, string studiesName);
    }

    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudiesRepository _studiesRepository;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public EnrollmentsService(
            IStudentRepository studentRepository,
            IStudiesRepository studiesRepository,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _studentRepository = studentRepository;
            _studiesRepository = studiesRepository;
            _enrollmentsRepository = enrollmentsRepository;
        }
        
        public async Task<(int? enrollmnentId, bool studiesExists)> EnrollStudent(EnrollmentDto enrollmentDto)
        {
            var student = new Student()
            {
                BirthDate = enrollmentDto.Birthdate, 
                FirstName = enrollmentDto.FirstName, 
                IndexNumber = enrollmentDto.IndexNumber, 
                LastName = enrollmentDto.LastName, 
            };
            
            _studentRepository.Create(student);

            var studies = await _studiesRepository.GetAsync(enrollmentDto.Studies);
            if (studies is null)
                return (0, false);

            var enrollment = await _enrollmentsRepository.GetAsync(studies);

            if (enrollment is null)
            {
                 enrollment = new Enrollment()
                {
                    Semester = 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.UtcNow,
                    Student = new List<Student>()
                };

                _enrollmentsRepository.CreateAsync(enrollment);
            }

            enrollment.Student.Add(student);

            await _enrollmentsRepository.SaveChangesAsync();
            return (enrollment.IdEnrollment, true);
        }

        public async Task<(bool studiesExists, bool enrollmentExists)> PromoteAsync(int semester, string studiesName)
        {
            var studies = await _studiesRepository.GetAsync(studiesName);
            if (studies is null)
                return (false, false);

            var enrollment = await _enrollmentsRepository.GetAsync(studies);
            if (enrollment is null)
                return (true, false);

            enrollment.Semester += 1;

            await _enrollmentsRepository.SaveChangesAsync();
            return (true, true);
        }
    }
}