using LibraryApi.DbContexts;
using LibraryApi.Entities;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LibraryApi.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        public LibraryDbContext _context {  get; set; }

        public LibraryRepository(LibraryDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.OrderBy(p  => p.Id).ToListAsync();
        }


        public async Task<Category?> GetCategoryByIdAsync(int categoryId, bool includebook)
        {
            if (includebook)
            {
                return await _context.Categories.Include(b => b.Books).Where(p => p.Id == categoryId).FirstOrDefaultAsync();
            }
            return await _context.Categories.Where(p => p.Id == categoryId).FirstOrDefaultAsync();


        }
        public void AddCategory(Category category)
        {
      
                _context.Categories.Add(category);
              
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(int categoryId)
        {
            return await _context.Books.Where(c => c.CategoryId==categoryId).OrderBy(p=> p.Id).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int categoryId, int bookId)
        {
            return await _context.Books.Where(p => p.CategoryId == categoryId && p.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task AddBookAsync(int categoryId, Book book)
        {
            var category =await  _context.Categories.Where(p => p.Id == categoryId).FirstOrDefaultAsync();
            
            if (category != null)
            {
                category.Books.Add(book);
            }
        }

        public void DeletBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<bool> CategoryExist(int categoryId)
        {
            return await _context.Categories.AnyAsync(p => p.Id == categoryId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
