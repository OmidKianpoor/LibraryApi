using AutoMapper;
using Azure;
using LibraryApi.Entities;
using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/categories/{categoryId}/books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryRepository _Repository;
        private readonly IMapper _Mapper;
        private readonly ILogger<BooksController> _Logger;

        public BooksController(ILibraryRepository repository, IMapper mapper, ILogger<BooksController> logger)
        {
            _Logger = logger;
            _Repository = repository;
            _Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks(int categoryId)
        {


            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }
            var booksForCategoriy = await _Repository.GetAllBooksAsync(categoryId);

            return Ok(_Mapper.Map<IEnumerable<BookDto>>(booksForCategoriy));

        }

        [HttpGet("{bookId}")]

        public async Task<IActionResult> GetOneBook(int categoryId, int bookId)
        {
            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }

            var book = await _Repository.GetBookByIdAsync(categoryId, bookId);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(_Mapper.Map<BookDto>(book));


        }

        [HttpPost]

        public async Task<ActionResult> AddingNewBook(int categoryId, [FromBody] BookForCreateDto bookForCreateDto)
        {
            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }
            var bookToCreate = _Mapper.Map<Book>(bookForCreateDto);

            await _Repository.AddBookAsync(categoryId, bookToCreate);
            await _Repository.SaveChangesAsync();

            return Created();

        }

        [HttpPut("{bookId}")]

        public async Task<ActionResult> EditBookInfo(int categoryId,int bookId, [FromBody] BookForEditDto bookForEdit)
        {
            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }
            var book = await _Repository.GetBookByIdAsync(categoryId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            _Mapper.Map(bookForEdit, book);

            return NoContent();

        }

        [HttpDelete("{bookId}")]

        public async Task<ActionResult> DeletOneBook(int categoryId,int bookId)
        {
            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }
            var book = await _Repository.GetBookByIdAsync(categoryId, bookId);
            if (book == null)
            {
                return NotFound();
            }
             _Repository.DeletBook(book);
            await _Repository.SaveChangesAsync();
            _Logger.LogWarning($"Book With UserId {bookId} Deleted!");
            return NoContent();
        }

        [HttpPatch("{bookId}")]

        public async Task<IActionResult> PartialEditForBook
            (int categoryId,int bookId, [FromBody]JsonPatchDocument<BookForEditDto> patchDocument)
        {
            if (!await _Repository.CategoryExist(categoryId))
            {

                return NotFound();
            }
            var book = await _Repository.GetBookByIdAsync(categoryId, bookId);
            if (book == null)
            {
                return NotFound();
            }

            var bookToPatch = _Mapper.Map<BookForEditDto>(book);

            patchDocument.ApplyTo(bookToPatch);
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (!TryValidateModel(bookToPatch))
            { return BadRequest(ModelState); }

            _Mapper.Map(bookToPatch, book);

           await _Repository.SaveChangesAsync();

            return NoContent();

        }


    }
}
