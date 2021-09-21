using System;

namespace TestReal.Services.Interfaces.ViewModels
{
    public class UpdateUserRegistrationViewModel
    {
        public int UserId { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastActivity { get; set; }
    }
}