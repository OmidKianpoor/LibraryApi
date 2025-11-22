using LibraryApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models
{
    public class OrderItem
    {
        
        [Key]
        public int Id { get; set; }

        // FK to Order
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        // FK to Book
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Range(1, 5)]
        public int Quantity { get; set; }

        
        public int UnitPrice { get; set; }
    }
}
    

