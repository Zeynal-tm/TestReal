using System;
using System.ComponentModel.DataAnnotations;

namespace TestReal.Persistence.Domain
{
    public class UserRegistration
    {
        [Key]
        public int UserId { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastActivity { get; set; }
    }
}