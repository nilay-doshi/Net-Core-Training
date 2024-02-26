﻿using System.ComponentModel.DataAnnotations;

namespace Team_Project.Models
{
    public class Coach
    {
        public Guid id { get; set; }

        [EmailAddress(ErrorMessage = "Email address is required")]
        [Key]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "FirstName is compulsory")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is compulsory")]
        public string LastName { get; set; } = null!;
        [Phone(ErrorMessage = "Contact Number is compulsory")]
        public string ContactNumber { get; set; } = null!;

        public DateOnly Dob { get; set; }

        public int? FlagRole { get; set; } = 5;

    }
}
