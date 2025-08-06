using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Features.Products.Commands;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.Shared.Commands;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var command = new CreateCommand<Product, ProductDto> { Dto = dto };
            var createdProduct = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var command = new UpdateCommand<Product, UpdateProductDto> { Id = id, Dto = dto };

            try
            {
                var updatedProduct = await _mediator.Send(command);
                return Ok(updatedProduct);
            }
            catch (EntityNotFoundException<Product> ex)
            {
                return NotFound(ex.Message);
            }
        }
     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {           
            var command = new DeleteCommand<Product> { Id = id };

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (EntityNotFoundException<Product> ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}