using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos
{

    public class CreateOrderDto
    {
        

        [Required]
        [MinLength(1)]
        public List<CreateOrderItemDto> Items { get; set; }
    }

}
