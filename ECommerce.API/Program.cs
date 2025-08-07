using ECommerce.Application.Mappings;
using ECommerce.Application.Features.Queries;
using ECommerce.Domain.UnitOfWork;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Features.Shared.Commands;
using ECommerce.Domain.Interfaces;
using ECommerce.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductDto).Assembly));
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
builder.Services.AddScoped(typeof(IRequestHandler<,>), typeof(CreateCommandHandler<,,>));
builder.Services.AddScoped(typeof(IRequestHandler<,>), typeof(UpdateCommandHandler<,>)); 
builder.Services.AddScoped(typeof(IRequestHandler<DeleteCommand<object>, Unit>), typeof(DeleteCommandHandler<>));
builder.Services.AddScoped(typeof(IRequestHandler<,>), typeof(GetAllQueryHandler<,>));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", context => {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();