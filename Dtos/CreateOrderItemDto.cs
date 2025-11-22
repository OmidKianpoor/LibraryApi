using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos
{
    public class CreateOrderItemDto
    {


        [Required]
        public int BookId { get; set; }

        [Required]
        [Range(1,5)]
        public int Quantity { get; set; }
    }   
}
