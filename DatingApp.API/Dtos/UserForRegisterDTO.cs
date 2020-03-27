using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "you must specify password betwwen 4 and 8")]
        public string Password { get; set; }
    }
}