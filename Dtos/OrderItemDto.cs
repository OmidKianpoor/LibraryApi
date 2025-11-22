namespace LibraryApi.Dtos
{
    public class OrderItemDto
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

    }
}

