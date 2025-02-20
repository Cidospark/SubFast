﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SubFast.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; } = "";
    }
}
