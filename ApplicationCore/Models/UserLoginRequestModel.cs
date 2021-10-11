using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class UserLoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        // [StringLength(50)] public string FirstName { get; set; }
        //
        // [StringLength(50)] public string LastName { get; set; }
        //
        // [DataType(DataType.Date)]
        // // [MaximumYear(1910)]
        // // [MinimumAge(18)]
        // public DateTime DateOfBirth { get; set; }
    }
}