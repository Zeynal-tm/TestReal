using System;
using System.ComponentModel.DataAnnotations;
using TestReal.Persistence.ValidationService;

namespace TestReal.Services.Interfaces.ViewModels
{
    public class UpdateUserRegistrationViewModel
    {
        public int UserId { get; set; }
        
        [ValidDate]
        public DateTime DateLastActivity { get; set; }
    }
}