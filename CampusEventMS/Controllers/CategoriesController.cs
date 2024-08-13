using AutoMapper;
using CampusEventMS.Data.Models;
using CampusEventMS.Data.Repositories;
using CampusEventMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CampusEventMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        // Dependency Injection of ICategoryRepository and IMapper
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        // Constructor to initialize the repository and mapper through dependency injection
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: api/categories
        // This method retrieves all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            // Fetch all categories from the repository
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            // Map the list of Category entities to CategoryDTOs
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            // Return the list of CategoryDTOs as a response
            return Ok(categoryDTOs);
        }

        // POST: api/categories
        // This method creates a new category
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryCreateDTO categoryDTO)
        {
            // Validate the input model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map the CategoryCreateDTO to a Category entity
            var category = _mapper.Map<Category>(categoryDTO);

            // Add the new category to the repository
            await _categoryRepository.AddCategoryAsync(category);

            // Map the created Category entity back to CategoryDTO
            var createdCategoryDTO = _mapper.Map<CategoryDTO>(category);

            // Return a response with the created category's details and the route to access it
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, createdCategoryDTO);
        }

        // GET: api/categories/{id}
        // This method retrieves a single category by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            // Fetch the category by ID from the repository
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            // If the category does not exist, return a NotFound response
            if (category == null)
            {
                return NotFound();
            }

            // Map the Category entity to CategoryDTO
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            // Return the CategoryDTO as a response
            return Ok(categoryDTO);
        }

        // PUT: api/categories/{id}
        // This method updates an existing category by its ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateDTO categoryDTO)
        {
            // Check if the category exists in the repository
            var categoryExists = await _categoryRepository.CategoryExistsAsync(id);
            if (!categoryExists)
            {
                return NotFound();
            }

            // Retrieve the category from the repository
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Map the updated fields from CategoryCreateDTO to the Category entity
            _mapper.Map(categoryDTO, category);

            try
            {
                // Update the category in the repository
                await _categoryRepository.UpdateCategoryAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues by checking if the category still exists
                if (!await _categoryRepository.CategoryExistsAsync(id))
                {
                    return NotFound();
                }
                throw;
            }

            // Return a NoContent response indicating successful update
            return NoContent();
        }

        // DELETE: api/categories/{id}
        // This method deletes a category by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // Fetch the category by ID from the repository
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            // If the category does not exist, return a NotFound response
            if (category == null)
            {
                return NotFound();
            }

            // Delete the category from the repository
            await _categoryRepository.DeleteCategoryAsync(id);
            // Return a NoContent response indicating successful deletion
            return NoContent();
        }
    }

    // Data Transfer Object (DTO) for Category
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required] // Name is required
        [StringLength(100)] // Max length of 100 characters for Name
        public string Name { get; set; }

        [StringLength(255)] // Max length of 255 characters for Description
        public string Description { get; set; }
    }
}


