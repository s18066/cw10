﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class EnrollmentModel
    {
        public string IndexNumber { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage ="Musisz podać imię")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        [Required]
        public string Studies { get; set; }
    }
}