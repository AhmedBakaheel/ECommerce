// ECommerce.WebAPI/Program.cs
using ECommerce.Application.Mappings;
using ECommerce.Application.Features.Queries;
using ECommerce.Domain.UnitOfWork;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Features.Shared.Commands;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Repositories;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR (This is the corrected registration that should solve all previous issues)
builder.Services.AddMediatR(cfg =>
{
    // Â–« «·”ÿ— Ì„”Õ ﬂ· «· Ã„Ì⁄«  –«  «·’·… ÊÌÃ» √‰ Ì”Ã· ﬂ· «·„⁄«·Ã«   ·ﬁ«∆Ì«
    cfg.RegisterServicesFromAssemblies(
        typeof(ProductProfile).Assembly,
        typeof(ApplicationDbContext).Assembly,
        typeof(GetAllQueryHandler<,>).Assembly // Â–« «·”ÿ— Ì÷„‰ „”Õ «· Ã„Ì⁄ «·–Ì ÌÕ ÊÌ ⁄·Ï «·„⁄«·Ã« 
    );
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

// Add Unit of Work and Generic Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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