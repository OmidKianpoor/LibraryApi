using AutoMapper;
using LibraryApi.Entities;
using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{

    [ApiController]
    [Route("api/Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILibraryRepository _Repository;
        private readonly IMapper _Mapper;
        private readonly ILogger<CategoriesController> _Logger;

        public CategoriesController(ILibraryRepository repository, IMapper mapper, ILogger<CategoriesController> logger)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _Logger = logger;
        }

    



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _Repository.GetCategoriesAsync();

            return Ok(_Mapper.Map<IEnumerable<CategoryWithoutBooksDto>>(categories));
        }


        [Authorize]
        [HttpGet("{categoryId}")]

        public async Task<IActionResult> GetOneCategoryById(int categoryId)
        {
            var category = await _Repository.GetCategoryByIdAsync(categoryId,true);
            if (category == null) {return NotFound();}

            return Ok(_Mapper.Map<CategoryDto>(category));

        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreateDto category)
        {
            var categoryToCreate = _Mapper.Map<Entities.Category>(category);
            _Repository.AddCategory(categoryToCreate);
           
            await _Repository.SaveChangesAsync();
            
            var createdCategory = _Mapper.Map<CategoryWithoutBooksDto>(categoryToCreate);

            return Created();
        }

        [Authorize]
        [HttpPut("{categoryId}")]

        public async Task<IActionResult> UpdateCategory(int categoryId, CategoryForUpdateDto categoryForUpdate)
        {
            var categoryToUpdate = await _Repository.GetCategoryByIdAsync(categoryId,false);
            if (categoryToUpdate == null) { return NotFound();}

            _Mapper?.Map(categoryForUpdate, categoryToUpdate);
            await _Repository.SaveChangesAsync();

            return NoContent();


        }

        [Authorize]
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeletCategory(int categoryId)
        {
            var category = await _Repository.GetCategoryByIdAsync(categoryId,false);
            if (category == null) return NotFound();

            _Repository.DeleteCategory(category);

            await _Repository.SaveChangesAsync();

            _Logger.LogWarning($"Category With UserId {categoryId} Deleted!");
          
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{categoryId}")]
        public async Task<IActionResult> PartialEditCategory(int categoryId, 
            [FromBody]JsonPatchDocument<CategoryForUpdateDto> patchDocument)
        {
            var category = await _Repository.GetCategoryByIdAsync(categoryId, false );
            if (category == null)
            {
                return NotFound();
            }
            var categoryToPatch = _Mapper.Map<CategoryForUpdateDto>(category);
            patchDocument.ApplyTo(categoryToPatch);

            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (!TryValidateModel(categoryToPatch))
            { return BadRequest(ModelState); }

            _Mapper?.Map(categoryToPatch, category);
            await _Repository.SaveChangesAsync();

            return NoContent();



        }
    }
}
