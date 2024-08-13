using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CampusEventMS.Controllers;
using CampusEventMS.Data.Models;
using CampusEventMS.Data.Repositories;
using CampusEventMS;

public class CategoriesControllerTests
{
    private readonly Mock<ICategoryRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly CategoriesController _controller;

    public CategoriesControllerTests()
    {
        // Initialize mock repository and auto-mapper configuration
        _mockRepo = new Mock<ICategoryRepository>();

        // Configure AutoMapper with the mapping profile used in the application
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = config.CreateMapper();

        // Create an instance of CategoriesController with the mocked repository and mapper
        _controller = new CategoriesController(_mockRepo.Object, _mapper);
    }

    [Fact]
    public async Task GetCategories_ReturnsOkResult_WithCategories()
    {
        // Arrange
        // Prepare a list of categories to be returned by the mocked repository
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" }
        };

        // Setup the mock repository to return the predefined categories list
        _mockRepo.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);

        // Act
        // Call the GetCategories method of the controller
        var result = await _controller.GetCategories();

        // Assert
        // Verify that the result is of type OkObjectResult
        var okResult = Assert.IsType<OkObjectResult>(result);

        // Verify that the result contains a list of CategoryDTO objects
        var returnValue = Assert.IsType<List<CategoryDTO>>(okResult.Value);

        // Check that the number of items in the returned list matches the number of items in the mock data
        Assert.Equal(2, returnValue.Count);
    }
}
