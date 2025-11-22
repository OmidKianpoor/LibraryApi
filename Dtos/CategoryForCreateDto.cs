using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class CategoryForCreateDto
    {
        [Required(ErrorMessage = "Please Enter Name Of Category")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
