using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Full_Stack_Project.Models
{
    public class Users
    {
        [Key]
        public int Userid { get; set; }


        [Required]
        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{5,10}$")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int IsActive { get; set; } = 1;

    }

    public class RegisterUser
    {
        public bool IsSuccess { get; set; } 
        public string message { get; set; }

    }



}
