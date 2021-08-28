using System;
using System.ComponentModel.DataAnnotations;
using TestReal.Persistence.ValidationService;

namespace TestReal.Persistence.Domain
{
    public class UserRegistration
    {
        [Key]
        public int UserId { get; set; }
        [ValidDate]
        public DateTime DateRegistration { get; set; }
        [ValidDate]
        public DateTime DateLastActivity { get; set; }
    }
}