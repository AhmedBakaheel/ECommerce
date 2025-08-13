// ECommerce.WebAPI/Controllers/CategoriesController.cs
using ECommerce.Application.DTOs.Categories;
using ECommerce.Application.Features.Queries;
using ECommerce.Application.Features.Shared.Commands;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery<CategoryDto>();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdQuery<Category, CategoryDto>(id);
            var category = await _mediator.Send(query);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createDto)
        {
            var command = new CreateCommand<Category, CreateCategoryDto, CategoryDto> { Dto = createDto };
            var createdCategory = await _mediator.Send(command);
            return Ok(createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto updateDto)
        {
            var command = new UpdateCommand<Category, UpdateCategoryDto> { Id = id, Dto = updateDto };
            var updatedCategory = await _mediator.Send(command);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // تم تعديل هذا السطر ليستخدم object initializer بدلاً من constructor
            var command = new DeleteCommand<Category> { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}