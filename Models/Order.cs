using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models
{
    public class Order
    {
        
        
            [Key]
            public int Id { get; set; }

            

            public DateTime OrderDate { get; set; } = DateTime.UtcNow;

            
            public int TotalPrice { get; set; }
        
            public int UserId { get; set; }

            // Navigation
            public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        
    }
}
