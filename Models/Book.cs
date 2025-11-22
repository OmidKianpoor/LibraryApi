using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(400)]
        public string? Summary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        
        public int ? PublicationYear { get; set; }

        [Required]
        public int Price { get; set; }



        //Relation
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int CategoryId { get; set; }
        //----------------
        public Book(string title,string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
