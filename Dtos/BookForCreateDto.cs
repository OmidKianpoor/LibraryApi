namespace LibraryApi.Models
{
    public class BookForCreateDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Summary { get; set; }

        public string Author { get; set; } = string.Empty;

        public int Price { get; set; }

    }
}
