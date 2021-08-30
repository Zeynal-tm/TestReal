using System;

namespace TestReal.Services.Interfaces.Dtos
{
    public class UserRegistrationDto
    {
        public int UserId { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastActivity { get; set; }
    }
}