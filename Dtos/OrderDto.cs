namespace LibraryApi.Dtos
{
    public class OrderDto
    {


        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderItemDto> Items { get; set; }

    }
}

