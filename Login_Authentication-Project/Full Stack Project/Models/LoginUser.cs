using System.ComponentModel.DataAnnotations;

namespace Full_Stack_Project.Models
{
    public class LoginUser
    {
        [Required]
        [Key]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{5,10}$")]
        public string Password { get; set; }


    }

    public class LoginUserResponse
    {
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }

    }
}
