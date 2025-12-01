using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models.AuthenticateModels
{
    public class LibraryUsersDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }

        public LibraryUsersDto
            (string userName, string firstName,
            string lastName, string userEmail, string userPhone, string city, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            UserEmail = userEmail;
            UserPhone = userPhone;
            City = city;
            Password = password;
        }
    }
}
