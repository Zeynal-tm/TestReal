using System;
using System.ComponentModel.DataAnnotations;

namespace TestReal.Services.Interfaces.Dtos
{
    public class UserRegistrationDto
    {
        public int UserId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.mm.yyyy}")]
        public DateTime DateRegistration { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.mm.yyyy}")]
        public DateTime DateLastActivity { get; set; }
    }
}