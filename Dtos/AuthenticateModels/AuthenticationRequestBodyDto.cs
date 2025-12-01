using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.AuthenticateModels
{
    public class AuthenticationRequestBodyDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
