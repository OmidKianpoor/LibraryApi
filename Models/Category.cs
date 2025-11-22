using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
     
        
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }

        public Category(string name)
        {
            this.Name = name;
        }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

