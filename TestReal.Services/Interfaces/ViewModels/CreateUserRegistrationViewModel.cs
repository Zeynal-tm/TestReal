using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper.Configuration.Annotations;
using TestReal.Persistence.ValidationService;

namespace TestReal.Services.Interfaces.ViewModels
{
    public class CreateUserRegistrationViewModel
    {
        public int UserId { get; set; }
        [ValidDate]
        public DateTime DateRegistration { get; set; }
        [ValidDate]
        public DateTime DateLastActivity { get; set; }
    }
}