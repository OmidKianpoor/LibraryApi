using LibraryApi.Entities;

namespace LibraryApi.Repositories
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();


        Task<Category?> GetCategoryByIdAsync(int categoryId,bool includeBooks);

        void AddCategory(Category category);

        void DeleteCategory(Category category);

        Task<IEnumerable<Book>> GetAllBooksAsync(int categoryId);
        Task<Book?> GetBookByIdAsync(int categoryId,int bookId);

       // Task<Book> GetBookByNameAsync(string name);

        Task AddBookAsync(int categoryId,Book book);

        void DeletBook(Book book);

        Task<bool> CategoryExist(int categoryId);

        Task<bool> SaveChangesAsync();


    }
}
