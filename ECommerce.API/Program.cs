// ECommerce.WebAPI/Program.cs
using ECommerce.Application.Mappings;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Interfaces;
using ECommerce.Persistence.Repositories;
using ECommerce.Domain.UnitOfWork;
using System.Reflection;
using ECommerce.Application.Configuration; //  √ﬂœ „‰ ≈÷«›… Â–« «·‹ using

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR (This is the new, simple call)
builder.Services.AddApplicationServices();

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